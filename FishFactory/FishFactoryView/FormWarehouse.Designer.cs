namespace FishFactoryView
{
    partial class FormWarehouse
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxResponsible = new System.Windows.Forms.TextBox();
            this.labelResponseble = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.idComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(72, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(148, 34);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(193, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxResponsible
            // 
            this.textBoxResponsible.Location = new System.Drawing.Point(177, 75);
            this.textBoxResponsible.Name = "textBoxResponsible";
            this.textBoxResponsible.Size = new System.Drawing.Size(164, 20);
            this.textBoxResponsible.TabIndex = 2;
            // 
            // labelResponseble
            // 
            this.labelResponseble.AutoSize = true;
            this.labelResponseble.Location = new System.Drawing.Point(72, 78);
            this.labelResponseble.Name = "labelResponseble";
            this.labelResponseble.Size = new System.Drawing.Size(89, 13);
            this.labelResponseble.TabIndex = 3;
            this.labelResponseble.Text = "Ответственный:";
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
            this.dataGridView.Location = new System.Drawing.Point(75, 124);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(467, 314);
            this.dataGridView.TabIndex = 4;
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
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(148, 472);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 34);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(371, 473);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 33);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 515);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelResponseble);
            this.Controls.Add(this.textBoxResponsible);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "FormWarehouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxResponsible;
        private System.Windows.Forms.Label labelResponseble;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}