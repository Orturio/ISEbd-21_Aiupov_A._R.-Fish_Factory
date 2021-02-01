using System.Collections.Generic;

namespace FishFactoryBusinessLogic.BindingModels
{
    public class CannedBindingModel
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
