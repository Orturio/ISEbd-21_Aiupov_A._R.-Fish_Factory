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
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new FishFactoryDatabase())
            {
                return context.Orders.Include(rec => rec.Canned).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CannedName = context.Canneds.FirstOrDefault(r => r.Id == rec.CannedId).CannedName,
                    CannedId = rec.CannedId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            if (model.DateFrom != null && model.DateTo != null)
            {
                using (var context = new FishFactoryDatabase())
                {
                    return context.Orders.Include(rec => rec.Canned).Where(rec => rec.DateCreate >= model.DateFrom && rec.DateImplement <= model.DateTo).Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        CannedName = context.Canneds.FirstOrDefault(r => r.Id == rec.CannedId).CannedName,
                        CannedId = rec.CannedId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                    }).ToList();
                }
            }

            using (var context = new FishFactoryDatabase())
            {
                return context.Orders.Include(rec => rec.Canned).Where(rec => rec.Id.Equals(model.Id)).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CannedName = context.Canneds.FirstOrDefault(r => r.Id == rec.CannedId).CannedName,
                    CannedId = rec.CannedId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new FishFactoryDatabase())
            {
                var order = context.Orders.Include(rec => rec.Canned).FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    CannedName = context.Canneds.FirstOrDefault(r => r.Id == order.CannedId).CannedName,
                    CannedId = order.CannedId,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement
                } : null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(CreateModel(model, new Order(), context));
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

        public void Update(OrderBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
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

        public void Delete(OrderBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order, FishFactoryDatabase context)
        {
            order.CannedId = model.CannedId;          
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
