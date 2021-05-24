using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryBusinessLogic.BusinessLogics;
using FishFactoryBusinessLogic.BindingModels;
using System.Reflection;

namespace FishFactoryView
{
    public partial class FormReportAllOrders : Form
    {
        private readonly ReportLogic logic;

        public FormReportAllOrders(ReportLogic reportLogic)
        {
            logic = reportLogic;
            InitializeComponent();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetOrdersGroupByDate");
                List<ReportOrdersViewModel> dataSource = (List<ReportOrdersViewModel>)method.Invoke(logic, new object[] { });
                ReportDataSource source = new ReportDataSource("DataSetOrders",
                dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveAllOrdersToPdfFile");
                        method.Invoke(logic, new object[] { new ReportBindingModel
                        {
                             FileName = dialog.FileName
                        }});                    
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportAllOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
