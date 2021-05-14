using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;
using Microsoft.Reporting.WinForms;
using FishFactoryBusinessLogic.BusinessLogics;
using FishFactoryBusinessLogic.BindingModels;

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
                var dataSource = logic.GetOrdersGroupByDate();
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
                        logic.SaveAllOrdersToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });
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
    }
}
