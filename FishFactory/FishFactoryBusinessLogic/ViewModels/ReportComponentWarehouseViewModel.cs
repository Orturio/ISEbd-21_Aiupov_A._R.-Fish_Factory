using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryBusinessLogic.ViewModels
{
    public class ReportComponentWarehouseViewModel
    {
        public string WarehouseName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; } // ComponentName, Count
    }
}
