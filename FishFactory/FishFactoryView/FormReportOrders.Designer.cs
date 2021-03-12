namespace FishFactoryView
{
    partial class FormReportOrders
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
            this.panel = new System.Windows.Forms.Panel();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.LabelFrom = new System.Windows.Forms.Label();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonToPdf);
            this.panel.Controls.Add(this.buttonMake);
            this.panel.Controls.Add(this.dateTimePickerTo);
            this.panel.Controls.Add(this.labelTo);
            this.panel.Controls.Add(this.dateTimePickerFrom);
            this.panel.Controls.Add(this.LabelFrom);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(801, 39);
            this.panel.TabIndex = 0;
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(661, 9);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(127, 20);
            this.buttonToPdf.TabIndex = 5;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(386, 8);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(162, 21);
            this.buttonMake.TabIndex = 4;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(203, 9);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(137, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(178, 12);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(19, 13);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "по";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(32, 9);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // LabelFrom
            // 
            this.LabelFrom.AutoSize = true;
            this.LabelFrom.Location = new System.Drawing.Point(12, 12);
            this.LabelFrom.Name = "LabelFrom";
            this.LabelFrom.Size = new System.Drawing.Size(14, 13);
            this.LabelFrom.TabIndex = 0;
            this.LabelFrom.Text = "С";
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "FishFactoryView.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 35);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(801, 418);
            this.reportViewer.TabIndex = 1;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panel);
            this.Name = "FormReportOrders";
            this.Text = "Заказы клиентов";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label LabelFrom;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelTo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}