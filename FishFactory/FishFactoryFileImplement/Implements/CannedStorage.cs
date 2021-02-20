using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishFactoryFileImplement.Implements
{
    public class CannedStorage : ICannedStorage
    {
        private readonly FileDataListSingleton source;

        public CannedStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<CannedViewModel> GetFullList()
        {
            return source.Canneds.Select(CreateModel).ToList();
        }

        public List<CannedViewModel> GetFilteredList(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Canneds.Where(rec => rec.CannedName.Contains(model.CannedName)).Select(CreateModel).ToList();
        }

        public CannedViewModel GetElement(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var canned = source.Canneds.FirstOrDefault(rec => rec.CannedName == model.CannedName || rec.Id == model.Id);

            return canned != null ? CreateModel(canned) : null;
        }

        public void Insert(CannedBindingModel model)
        {
            int maxId = source.Canneds.Count > 0 ? source.Components.Max(rec => rec.Id): 0;

            var element = new Canned { Id = maxId + 1, CannedComponents = new Dictionary<int, int>()};
            source.Canneds.Add(CreateModel(model, element));
        }

        public void Update(CannedBindingModel model)
        {
            var element = source.Canneds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
        }

        public void Delete(CannedBindingModel model)
        {
            Canned element = source.Canneds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Canneds.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Canned CreateModel(CannedBindingModel model, Canned canned)
        {
            canned.CannedName = model.CannedName;
            canned.Price = model.Price;
            // удаляем убранные
            foreach (var key in canned.CannedComponents.Keys.ToList())
            {
                if (!model.CannedComponents.ContainsKey(key))
                {
                    canned.CannedComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.CannedComponents)
            {
                if (canned.CannedComponents.ContainsKey(component.Key))
                {
                    canned.CannedComponents[component.Key] = model.CannedComponents[component.Key].Item2;
                }
                else
                {
                    canned.CannedComponents.Add(component.Key, model.CannedComponents[component.Key].Item2);
                }
            }

            return canned;
        }

        private CannedViewModel CreateModel(Canned canned)
        {
            return new CannedViewModel
            {
                Id = canned.Id,
                CannedName = canned.CannedName,
                Price = canned.Price,
                CannedComponents = canned.CannedComponents.ToDictionary(recPC => recPC.Key, recPC => 
(source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
