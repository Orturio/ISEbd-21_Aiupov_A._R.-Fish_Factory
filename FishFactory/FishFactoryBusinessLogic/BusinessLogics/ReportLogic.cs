using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.HelperModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishFactoryBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ICannedStorage _cannedStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IWarehouseStorage _warehouseStorage;

        public ReportLogic(ICannedStorage cannedStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage)
        {
            _warehouseStorage = warehouseStorage;
            _cannedStorage = cannedStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportCannedComponentViewModel> GetCannedComponent()
        {
            var canneds = _cannedStorage.GetFullList();
            var list = new List<ReportCannedComponentViewModel>();
            foreach (var canned in canneds)
            {
                var record = new ReportCannedComponentViewModel
                {
                    CannedName = canned.CannedName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in canned.CannedComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportComponentWarehouseViewModel> GetComponentWarehouse()
        {
            var warehouses = _warehouseStorage.GetFullList();
            var list = new List<ReportComponentWarehouseViewModel>();
            foreach (var warehouse in warehouses)
            {
                var record = new ReportComponentWarehouseViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in warehouse.WarehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom =model.DateFrom,
                DateTo = model.DateTo
            }).Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                CannedName = x.CannedName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString()
            }).ToList();
        }

        public List<ReportAllOrdersViewModel> GetOrdersGroupByDate()
        {
            return _orderStorage.GetFullList().GroupBy(x => x.DateCreate.Date)
            .Select(x => new ReportAllOrdersViewModel
            {
                DateCreate = x.Key,
                Count = x.Count(),
                Sum = x.Sum(rec => rec.Sum),
            }).ToList();
        }

        public void SaveCannedsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocCanned(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Canneds = _cannedStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение изделие с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>       
        public void SaveCannedToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                CannedComponents = GetCannedComponent()
            });
        }

        public void SaveComponentWarehouseToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                ComponentWarehouses = GetComponentWarehouse()
            });
        }

        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocWarehouse(new WordInfoWarehouse
            {
                FileName = model.FileName,
                Title = "Таблица складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

        public void SaveAllOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocAllOrders(new PdfInfoAllOrders
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersGroupByDate()
            });
        }
    }
}
