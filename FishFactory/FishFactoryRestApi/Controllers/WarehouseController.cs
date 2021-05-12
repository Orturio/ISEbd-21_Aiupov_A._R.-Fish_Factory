using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FishFactoryBusinessLogic.BusinessLogics;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryBusinessLogic.BindingModels;

namespace FishFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly WarehouseLogic _warehouse;

        private readonly ComponentLogic _component;

        public WarehouseController(WarehouseLogic warehouseLogic, ComponentLogic componentLogic)
        {
            _warehouse = warehouseLogic;
            _component = componentLogic;
        }

        [HttpGet]
        public List<WarehouseViewModel> GetWarehouseList() => _warehouse.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateWarehouse(WarehouseBindingModel model)
            => _warehouse.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouse.Delete(model);

        [HttpPost]
        public void Restoking(WarehouseRestokingBindingModel model)
            => _warehouse.Restocking(model);

        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId)
            => _warehouse.Read(new WarehouseBindingModel { Id = warehouseId })?[0];

        [HttpGet]
        public List<ComponentViewModel> GetComponentList()
            => _component.Read(null);
    }
}
