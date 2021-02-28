using FishFactoryBusinessLogic.Enums;
using FishFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FishFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string CannedFileName = "Canned.xml";

        private readonly string WarehouseFileName = "Warehouse.xml";

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Canned> Canneds { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Canneds = LoadCanneds();
            Warehouses = LoadWarehouses();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveCanneds();
            SaveWarehouses();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);

                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);

                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    DateTime? dateImplement = null;
                    if (elem.Element("DateImplement").Value != "")
                    {
                        dateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value);
                    }

                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CannedId = Convert.ToInt32(elem.Element("CannedId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = dateImplement
                    });
                }
            }
            return list;
        }

        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();
            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);

                var xElements = xDocument.Root.Elements("Warehouse").ToList();

                foreach (var elem in xElements)
                {
                    var warhComp = new Dictionary<int, int>();
                    foreach (var component in
elem.Element("WarehouseComponents").Elements("WarehouseComponent").ToList())
                    {
                        warhComp.Add(Convert.ToInt32(component.Element("Key").Value),
Convert.ToInt32(component.Element("Value").Value));
                    }

                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value,
                        Responsible = elem.Element("Responsible").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        WarehouseComponents = warhComp
                    });
                }
            }
            return list;
        }

        private List<Canned> LoadCanneds()
        {
            var list = new List<Canned>();

            if (File.Exists(CannedFileName))
            {
                XDocument xDocument = XDocument.Load(CannedFileName);

                var xElements = xDocument.Root.Elements("Canned").ToList();

                foreach (var elem in xElements)
                {
                    var prodComp = new Dictionary<int, int>();
                    foreach (var component in
elem.Element("CannedComponent").Elements("CannedComponents").ToList())
                    {
                        prodComp.Add(Convert.ToInt32(component.Element("Key").Value),
Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Canned
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CannedName = elem.Element("CannedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        CannedComponents = prodComp
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");

                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("CannedId", order.CannedId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveWarehouses()
        {
            if (Warehouses != null )
            {
                var xElement = new XElement("Warehouses");

                foreach (var warehouse in Warehouses)
                {
                    var compElement = new XElement("WarehouseComponents");

                    foreach (var component in warehouse.WarehouseComponents)
                    {
                        compElement.Add(new XElement("WarehouseComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }

                    xElement.Add(new XElement("Warehouse",
                        new XAttribute("Id", warehouse.Id),
                        new XElement("WarehouseName", warehouse.WarehouseName),
                        new XElement("Responsible", warehouse.Responsible),
                        new XElement("DateCreate", warehouse.DateCreate),
                        compElement));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }

        private void SaveCanneds()
        {
            if (Canneds != null)
            {
                var xElement = new XElement("Canneds");

                foreach (var canned in Canneds)
                {
                    var compElement = new XElement("CannedComponent");

                    foreach (var component in canned.CannedComponents)
                    {
                        compElement.Add(new XElement("CannedComponents",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }

                    xElement.Add(new XElement("Canned",
                        new XAttribute("Id", canned.Id),
                        new XElement("CannedName", canned.CannedName),
                        new XElement("Price", canned.Price),
                        compElement));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(CannedFileName);
            }
        }
    }
}