using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.BusinessLogics;
using FishFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace FishFactoryView
{
    public partial class FormWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly WarehouseLogic logic;

        private int? id;

        private Dictionary<int, (string, int)> warehouseComponents;

        public FormWarehouse(WarehouseLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    WarehouseViewModel view = logic.Read(new WarehouseBindingModel { Id = id.Value })?[0];

                    if (view != null)
                    {
                        textBoxName.Text = view.WarehouseName;
                        textBoxResponsible.Text = view.Responsible.ToString();
                        warehouseComponents = view.WarehouseComponents;
                        LoadData();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }

            else
            {
                warehouseComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (warehouseComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in warehouseComponents)
                    {
                        dataGridView.Rows.Add(new object[] {pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxResponsible.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new WarehouseBindingModel
                {
                    Id = id,
                    WarehouseName = textBoxName.Text,
                    Responsible = textBoxResponsible.Text,
                    WarehouseComponents = warehouseComponents,
                    DateCreate = DateTime.Now
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}