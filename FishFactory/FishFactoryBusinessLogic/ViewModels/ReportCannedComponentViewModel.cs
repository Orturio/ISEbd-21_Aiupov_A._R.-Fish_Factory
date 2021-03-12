using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryBusinessLogic.ViewModels
{
    public class ReportCannedComponentViewModel
    {
        public string ComponentName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Canneds { get; set; }
    }
}
