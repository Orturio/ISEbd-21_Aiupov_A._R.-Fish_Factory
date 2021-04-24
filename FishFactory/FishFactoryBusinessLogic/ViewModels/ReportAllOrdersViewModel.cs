using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryBusinessLogic.ViewModels
{
    public class ReportAllOrdersViewModel
    {
        public DateTime DateCreate { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
