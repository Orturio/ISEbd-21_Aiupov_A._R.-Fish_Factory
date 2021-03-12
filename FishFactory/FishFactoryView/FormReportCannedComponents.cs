using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace FishFactoryView
{
    public partial class FormReportCannedComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportCannedComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormReportProductComponents_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetProductComponent();

                if (dict != null)
                {
                    dataGridView.Rows.Clear();

                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.ComponentName, "", "" });

                        foreach (var listElem in elem.Canneds)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount});
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveCannedComponentToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
