using FishFactoryBusinessLogic.Enums;
using System;

namespace FishFactoryBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }

        public int? ClientId { get; set; }

        public int CannedId { get; set; }

        public int? ImplementerId { get; set; }

        public bool? FreeOrders { get; set; }

        public bool? NeedComponentOrders { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
