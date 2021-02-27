using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Enums;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace FishFactoryBusinessLogic.BusinessLogics
{
    public class WarehouseLogic
    {
        private readonly IWarehouseStorage _warehouseStorage;

        public WarehouseLogic(IWarehouseStorage warehouseStorage)
        {
            _warehouseStorage = warehouseStorage;
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return _warehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WarehouseViewModel> { _warehouseStorage.GetElement(model) };
            }
            return _warehouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                WarehouseName = model.WarehouseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _warehouseStorage.Update(model);
            }
            else
            {
                _warehouseStorage.Insert(model);
            }
        }

        public void Restocking(WarehouseBindingModel model, int WarehouseId, int ComponentId, int Count, string ComponentName)
        {
            WarehouseViewModel view = Read(new WarehouseBindingModel
            {
                Id = WarehouseId
            })?[0];

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
            CreateOrUpdate(model);
        }    

        public void Delete(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _warehouseStorage.Delete(model);
        }
    }
}