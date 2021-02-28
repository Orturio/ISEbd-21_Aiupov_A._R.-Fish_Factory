using System;
using System.Collections.Generic;
using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;
using System.Text;

namespace FishFactoryBusinessLogic.Interfaces
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();

        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);

        WarehouseViewModel GetElement(WarehouseBindingModel model);

        void Restocking(WarehouseBindingModel model, int WarehouseId, int ComponentId, int Count, string ComponentName);

        void Insert(WarehouseBindingModel model);

        void Update(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);
    }
}