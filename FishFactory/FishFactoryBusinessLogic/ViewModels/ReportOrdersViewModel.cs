using System;
using System.Collections.Generic;
using System.Text;
using FishFactoryBusinessLogic.Enums;

namespace FishFactoryBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }

        public string CannedName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }
    }
}
