using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishFactoryListImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly DataListSingleton source;

        public WarehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                result.Add(CreateModel(warehouse));
            }
            return result;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.WarehouseName.Contains(model.WarehouseName))
                {
                    result.Add(CreateModel(warehouse));
                }
            }
            return result;
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id || warehouse.WarehouseName.Equals(model.WarehouseName))
                {
                    return CreateModel(warehouse);
                }
            }
            return null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = new Warehouse
            {
                Id = 1,
                WarehouseComponents = new Dictionary<int, int>()
            };
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = warehouse.Id + 1;
                }
            }
            source.Warehouses.Add(CreateModel(model, tempWarehouse));
        }
        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = null;
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id)
                {
                    tempWarehouse = warehouse;
                }
            }
            if (tempWarehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempWarehouse);
        }

        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.Responsible = model.Responsible;
            warehouse.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] =
                    model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key,
                    model.WarehouseComponents[component.Key].Item2);
                }
            }
            return warehouse;
        }

        public void Restocking(WarehouseBindingModel model, int WarehouseId, int ComponentId, int Count, string ComponentName)
        {
            WarehouseViewModel view = GetElement(new WarehouseBindingModel
            {
                Id = WarehouseId
            });

            if (view != null)
            {
                model.WarehouseComponents = view.WarehouseComponents;
                model.DateCreate = view.DateCreate;
                model.Id = view.Id;
                model.Responsible = view.Responsible;
                model.WarehouseName = view.WarehouseName;
            }

            if (model.WarehouseComponents.ContainsKey(ComponentId))
            {
                int count = model.WarehouseComponents[ComponentId].Item2;
                model.WarehouseComponents[ComponentId] = (ComponentName, count + Count);
            }
            else
            {
                model.WarehouseComponents.Add(ComponentId, (ComponentName, Count));
            }
            Update(model);
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            Dictionary<int, (string, int)> warehouseComponents = new
            Dictionary<int, (string, int)>();
            foreach (var pc in warehouse.WarehouseComponents)
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
                warehouseComponents.Add(pc.Key, (componentName, pc.Value));
            }

            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                Responsible = warehouse.Responsible,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            };
        }
    }
}