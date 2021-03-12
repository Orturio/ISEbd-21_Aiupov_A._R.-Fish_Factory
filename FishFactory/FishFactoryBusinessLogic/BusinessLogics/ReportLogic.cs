using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.HelperModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
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
        public List<ReportCannedComponentViewModel> GetCannedComponent()
        {
            var components = _componentStorage.GetFullList();

            var canneds = _cannedStorage.GetFullList();

            var list = new List<ReportCannedComponentViewModel>();

            foreach (var component in components)
            {
                var record = new ReportCannedComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Canneds = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                foreach (var canned in canneds)
                {
                    if (canned.CannedComponents.ContainsKey(component.Id))
                    {
                        record.Canneds.Add(new Tuple<string, int>(canned.CannedName,
                       canned.CannedComponents[component.Id].Item2));
                        record.TotalCount +=
                       canned.CannedComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

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
                foreach (var component in components)
                {
                    if (canned.CannedComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName,
                        canned.CannedComponents[component.Id].Item2));
                        record.TotalCount += canned.CannedComponents[component.Id].Item2;
                    }
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
                Status = x.Status
            }).ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = _componentStorage.GetFullList()
            });
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
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveCannedComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                CannedComponents = GetCannedComponent()
            });
        }

        public void SaveCannedInfoToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocCanned(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                CannedComponents = GetComponentCanned()
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
