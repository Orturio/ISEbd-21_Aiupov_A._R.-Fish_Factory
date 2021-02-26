using FishFactoryListImplement.Models;
using System.Collections.Generic;

namespace FishFactoryListImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Canned> Canneds { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Canneds = new List<Canned>();
            Warehouses = new List<Warehouse>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}
