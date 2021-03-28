using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.BusinessLogics;
using FishFactoryBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FishFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;

        private readonly CannedLogic _canned;

        private readonly OrderLogic _main;

        public MainController(OrderLogic order, CannedLogic canned, OrderLogic main)
        {
            _order = order;
            _canned = canned;
            _main = main;
        }

        [HttpGet]
        public List<CannedViewModel> GetProductList() => _canned.Read(null)?.ToList();

        [HttpGet]
        public CannedViewModel GetProduct(int cannedId) => _canned.Read(new CannedBindingModel { Id = cannedId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
