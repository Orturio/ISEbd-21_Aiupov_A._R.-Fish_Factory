using FishFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace FishFactoryBusinessLogic.HelperModels
{
    public class PdfInfoAllOrders
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportAllOrdersViewModel> Orders { get; set; }
    }
}
