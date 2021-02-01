using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FishFactoryListImplement.Implements
{
    public class CannedStorage : ICannedStorage
    {
        private readonly DataListSingleton source;

        public CannedStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CannedViewModel> GetFullList()
        {
            List<CannedViewModel> result = new List<CannedViewModel>();
            foreach (var component in source.Products)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }

        public List<CannedViewModel> GetFilteredList(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<CannedViewModel> result = new List<CannedViewModel>();
            foreach (var product in source.Products)
            {
                if (product.ProductName.Contains(model.ProductName))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }

        public CannedViewModel GetElement(CannedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id || product.ProductName ==
                model.ProductName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }

        public void Insert(CannedBindingModel model)
        {
            Canned tempProduct = new Canned
            {
                Id = 1,
                ProductComponents = new
            Dictionary<int, int>()
            };
            foreach (var product in source.Products)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Products.Add(CreateModel(model, tempProduct));
        }

        public void Update(CannedBindingModel model)
        {
            Canned tempProduct = null;
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }

        public void Delete(CannedBindingModel model)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
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
                    product.ProductComponents[component.Key] =
                    model.ProductComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key,
                    model.ProductComponents[component.Key].Item2);
                }
            }
            return product;
        }

        private CannedViewModel CreateModel(Canned product)
        {
            
            Dictionary<int, (string, int)> productComponents = new
Dictionary<int, (string, int)>();
            foreach (var pc in product.ProductComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new CannedViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductComponents = productComponents
            };
        }
    }
}
