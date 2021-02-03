namespace FishFactoryView
{
    partial class FormCanned
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBoxComponents = new System.Windows.Forms.GroupBox();
			this.buttonRef = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.idComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBoxComponents.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(89, 20);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(193, 20);
			this.textBoxName.TabIndex = 0;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(89, 54);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(99, 20);
			this.textBoxPrice.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Название:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Цена:";
			// 
			// groupBoxComponents
			// 
			this.groupBoxComponents.Controls.Add(this.buttonRef);
			this.groupBoxComponents.Controls.Add(this.buttonDel);
			this.groupBoxComponents.Controls.Add(this.buttonUpd);
			this.groupBoxComponents.Controls.Add(this.buttonAdd);
			this.groupBoxComponents.Controls.Add(this.dataGridView);
			this.groupBoxComponents.Location = new System.Drawing.Point(26, 99);
			this.groupBoxComponents.Name = "groupBoxComponents";
			this.groupBoxComponents.Size = new System.Drawing.Size(633, 339);
			this.groupBoxComponents.TabIndex = 4;
			this.groupBoxComponents.TabStop = false;
			this.groupBoxComponents.Text = "Компоненты";
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(492, 159);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(114, 38);
			this.buttonRef.TabIndex = 4;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(493, 118);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(113, 35);
			this.buttonDel.TabIndex = 3;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(492, 77);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(114, 35);
			this.buttonUpd.TabIndex = 2;
			this.buttonUpd.Text = "Изменить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(492, 37);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(114, 34);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComponent,
            this.component,
            this.Count});
			this.dataGridView.Location = new System.Drawing.Point(6, 19);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(467, 314);
			this.dataGridView.TabIndex = 0;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(443, 447);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(88, 34);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(537, 447);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(95, 33);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// idComponent
			// 
			this.idComponent.HeaderText = "idComponent";
			this.idComponent.Name = "idComponent";
			this.idComponent.ReadOnly = true;
			this.idComponent.Visible = false;
			// 
			// component
			// 
			this.component.HeaderText = "Компонент";
			this.component.Name = "component";
			this.component.ReadOnly = true;
			this.component.Width = 300;
			// 
			// Count
			// 
			this.Count.HeaderText = "Количество";
			this.Count.Name = "Count";
			this.Count.ReadOnly = true;
			this.Count.Width = 150;
			// 
			// FormCanned
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(697, 493);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBoxComponents);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxName);
			this.Name = "FormCanned";
			this.Text = "Изделие";
			this.Load += new System.EventHandler(this.FormProduct_Load);
			this.groupBoxComponents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridViewTextBoxColumn idComponent;
		private System.Windows.Forms.DataGridViewTextBoxColumn component;
		private System.Windows.Forms.DataGridViewTextBoxColumn Count;
	}
}