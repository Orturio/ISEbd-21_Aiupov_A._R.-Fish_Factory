﻿using FishFactoryBusinessLogic.BindingModels;
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

        public void Restocking(WarehouseBindingModel warehouseBindingModel, int WarehouseId, int ComponentId, int Count, string ComponentName)
        {
            WarehouseViewModel view = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                Id = WarehouseId
            });

            if (view != null)
            {
                warehouseBindingModel.WarehouseComponents = view.WarehouseComponents;
                warehouseBindingModel.DateCreate = view.DateCreate;
                warehouseBindingModel.Id = view.Id;
                warehouseBindingModel.Responsible = view.Responsible;
                warehouseBindingModel.WarehouseName = view.WarehouseName;
            }

            if (warehouseBindingModel.WarehouseComponents.ContainsKey(ComponentId))
            {
                int count = warehouseBindingModel.WarehouseComponents[ComponentId].Item2;
                warehouseBindingModel.WarehouseComponents[ComponentId] = (ComponentName, count + Count);
            }
            else
            {
                warehouseBindingModel.WarehouseComponents.Add(ComponentId, (ComponentName, Count));
            }
            _warehouseStorage.Update(warehouseBindingModel);
        }
    }
}