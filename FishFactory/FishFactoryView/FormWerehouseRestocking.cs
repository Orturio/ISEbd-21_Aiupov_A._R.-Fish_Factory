using System.Collections.Generic;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryBusinessLogic.BusinessLogics;
using System;
using FishFactoryBusinessLogic.BindingModels;
using FishFactoryDatabaseImplement;
using FishFactoryDatabaseImplement.Implements;
using FishFactoryDatabaseImplement.Models;
using System.Windows.Forms;
using Unity;
using System.Linq;

namespace FishFactoryView
{
    public partial class FormWarehouseRestocking : Form
    {
        WarehouseLogic logic;

        public string ComponentName { get { return comboBoxComponent.Text; } }

        public int ComponentId
        {
            get { return Convert.ToInt32(comboBoxComponent.SelectedValue); }
            set { comboBoxComponent.SelectedValue = value; }
        }

        public int WarehouseId
        {
            get { return Convert.ToInt32(comboBoxWarehouse.SelectedValue); }
            set { comboBoxWarehouse.SelectedValue = value; }
        }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormWarehouseRestocking(ComponentLogic componentlogic, WarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            logic = warehouseLogic;
            List<ComponentViewModel> listComponent = componentlogic.Read(null);
            if (listComponent != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = listComponent;
                comboBoxComponent.SelectedItem = null;
            }

            List<WarehouseViewModel> listWarehouse = warehouseLogic.Read(null);
            if (listWarehouse != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = listWarehouse;
                comboBoxWarehouse.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            logic.Restocking(new WarehouseRestokingBindingModel
            {
                WarehouseId = WarehouseId,
                ComponentId = ComponentId,
                Count = Count
            });
            MessageBox.Show("Склад пополнен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}