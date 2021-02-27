using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishFactoryDatabaseImplement.Implements
{
    public class CannedStorage : ICannedStorage
    {
        public List<CannedViewModel> GetFullList()
        {
            using (var context = new FishFactoryDatabase())
            {
                return context.Canneds.Include(rec => rec.CannedComponents).ThenInclude(rec => rec.Component)
.ToList().Select(rec => new CannedViewModel
                {
                   Id = rec.Id,
                   CannedName = rec.CannedName,
                   Price = rec.Price,
                   CannedComponents = rec.CannedComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                }).ToList();
            }
        }

        public List<CannedViewModel> GetFilteredList(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FishFactoryDatabase())
            {
                return context.Canneds.Include(rec => rec.CannedComponents).ThenInclude(rec => rec.Component)
.Where(rec => rec.CannedName.Contains(model.CannedName)).ToList().Select(rec => new CannedViewModel
                {
                   Id = rec.Id,
                   CannedName = rec.CannedName,
                   Price = rec.Price,
                  
                }).ToList();
            }
        }

        public CannedViewModel GetElement(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new FishFactoryDatabase())
            {
                var canned = context.Canneds.Include(rec => rec.CannedComponents).ThenInclude(rec => rec.Component)
.FirstOrDefault(rec => rec.CannedName == model.CannedName || rec.Id == model.Id);
                return canned != null ?
                new CannedViewModel
                {
                    Id = canned.Id,
                    CannedName = canned.CannedName,
                    Price = canned.Price,
                    CannedComponents = canned.CannedComponents.ToDictionary(recPC => recPC.ComponentId, recPC =>(recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }

        public void Insert(CannedBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Canned canned = CreateModel(model, new Canned());
                        context.Canneds.Add(canned);
                        context.SaveChanges();
                        CreateModel(model, canned, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(CannedBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Canneds.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(CannedBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                Canned element = context.Canneds.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Canneds.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Canned CreateModel(CannedBindingModel model, Canned canned) 
        {
            canned.CannedName = model.CannedName;
            canned.Price = model.Price;
            return canned;
        }

        private Canned CreateModel(CannedBindingModel model, Canned canned, FishFactoryDatabase context)
        {
            canned.CannedName = model.CannedName;
            canned.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.CannedComponents.Where(rec => rec.CannedId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.CannedComponents.RemoveRange(productComponents.Where(rec => !model.CannedComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count = model.CannedComponents[updateComponent.ComponentId].Item2;
                    model.CannedComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.CannedComponents)
            {
                context.CannedComponents.Add(new CannedComponent
                {
                    CannedId = canned.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return canned;
        }
    }
}
