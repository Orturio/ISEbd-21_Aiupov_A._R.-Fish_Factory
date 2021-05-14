using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.HelperModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using FishFactoryBusinessLogic.Enums;
using System.Linq;

namespace FishFactoryBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ICannedStorage _cannedStorage;
        private readonly IOrderStorage _orderStorage;

        public ReportLogic(ICannedStorage cannedStorage, IComponentStorage componentStorage, IOrderStorage orderStorage)
        {
            _cannedStorage = cannedStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>

        public List<ReportCannedComponentViewModel> GetComponentCanned()
        {
            var components = _componentStorage.GetFullList();

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

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            }).Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                CannedName = x.CannedName,
                Count = x.Count,
                Sum = x.Sum,

                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString(),
            }).ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>


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

        public void SaveCannedInfoToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocCanned(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                CannedComponents = GetCannedComponent()
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
    }
}
