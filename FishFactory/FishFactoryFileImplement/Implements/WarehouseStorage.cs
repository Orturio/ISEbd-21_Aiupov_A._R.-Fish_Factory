using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishFactoryFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses.Select(CreateModel).ToList();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses.Where(rec => rec.WarehouseName.Contains(model.WarehouseName)).Select(CreateModel).ToList();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var warehouse = source.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);

            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;

            var element = new Warehouse { Id = maxId + 1, WarehouseComponents = new Dictionary<int, int>() };
            source.Warehouses.Add(CreateModel(model, element));
        }

        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
        }

        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public void Restocking(WarehouseBindingModel model, int WarehouseId, int ComponentId, int Count, string ComponentName)
        {
            WarehouseViewModel view = GetElement( new WarehouseBindingModel
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

        //public bool Unrestocking(int CannedCount, int CannedId)
        //{
        //    {
        //        var list = GetFullList();

        //        int Count = source.Canneds.FirstOrDefault(rec => rec.Id == CannedId).CannedComponents[CannedId] * CannedCount;

        //        if (list.Sum(rec => rec.WarehouseComponents.Values.Sum(item => item.Item2)) / list.Count() < Count)
        //        {
        //            return false;
        //        }

        //        List<WarehouseBindingModel> models = new List<WarehouseBindingModel>();

        //        foreach (var view in list)
        //        {
        //            var warehouseComponents = view.WarehouseComponents;
        //            foreach (var key in view.WarehouseComponents.Keys.ToArray())
        //            {
        //                var value = view.WarehouseComponents[key];
        //                if (value.Item2 >= Count)
        //                {
        //                    warehouseComponents[key] = (value.Item1, value.Item2 - Count);
        //                }
        //                else
        //                {
        //                    warehouseComponents[key] = (value.Item1, 0);
        //                    Count -= value.Item2;
        //                }
        //                Update(new WarehouseBindingModel
        //                {
        //                    Id = view.Id,
        //                    DateCreate = view.DateCreate,
        //                    Responsible = view.Responsible,
        //                    WarehouseName = view.WarehouseName,
        //                    WarehouseComponents = warehouseComponents
        //                });
        //            }
        //        }
        //        return true;
        //    }
        //}

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
                    warehouse.WarehouseComponents[component.Key] = model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
                }
            }

            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                Responsible = warehouse.Responsible,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents.ToDictionary(recPC => recPC.Key, recPC =>
(source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
