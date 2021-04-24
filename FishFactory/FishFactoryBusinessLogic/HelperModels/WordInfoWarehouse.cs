using System;
using System.Collections.Generic;
using FishFactoryBusinessLogic.ViewModels;

namespace FishFactoryBusinessLogic.HelperModels
{
    public class WordInfoWarehouse
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
