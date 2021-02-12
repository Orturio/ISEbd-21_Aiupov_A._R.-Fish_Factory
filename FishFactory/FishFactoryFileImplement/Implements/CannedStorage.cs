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
            return source.Products.Select(CreateModel).ToList();
        }

        public List<CannedViewModel> GetFilteredList(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Products.Where(rec => rec.ProductName.Contains(model.ProductName)).Select(CreateModel).ToList();
        }

        public CannedViewModel GetElement(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var product = source.Products.FirstOrDefault(rec => rec.ProductName == model.ProductName || rec.Id == model.Id);

            return product != null ? CreateModel(product) : null;
        }

        public void Insert(CannedBindingModel model)
        {
            int maxId = source.Products.Count > 0 ? source.Components.Max(rec => rec.Id): 0;

            var element = new Canned { Id = maxId + 1, ProductComponents = new Dictionary<int, int>()};
            source.Products.Add(CreateModel(model, element));
        }

        public void Update(CannedBindingModel model)
        {
            var element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
        }

        public void Delete(CannedBindingModel model)
        {
            Canned element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Canned CreateModel(CannedBindingModel model, Canned product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.ProductComponents.Keys.ToList())
            {
                if (!model.ProductComponents.ContainsKey(key))
                {
                    product.ProductComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.ProductComponents)
            {
                if (product.ProductComponents.ContainsKey(component.Key))
                {
                    product.ProductComponents[component.Key] = model.ProductComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key, model.ProductComponents[component.Key].Item2);
                }
            }

            return product;
        }

        private CannedViewModel CreateModel(Canned product)
        {
            return new CannedViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductComponents = product.ProductComponents.ToDictionary(recPC => recPC.Key, recPC => 
(source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
