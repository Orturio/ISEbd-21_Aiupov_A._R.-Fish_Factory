using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryBusinessLogic.BindingModels
{
    public class WarehouseRestokingBindingModel
    {
        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
