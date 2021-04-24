namespace FishFactoryView
{
    partial class FormReportAllOrders
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportAllOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.ReportOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportAllOrdersViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "FishFactoryView.ReportAllOrders.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(1, 3);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(761, 445);
            this.reportViewer.TabIndex = 0;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(768, 12);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(105, 35);
            this.buttonMake.TabIndex = 1;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(768, 64);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(105, 38);
            this.buttonSaveToPdf.TabIndex = 2;
            this.buttonSaveToPdf.Text = "Сохранить в пдф";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.buttonSaveToPdf_Click);
            // 
            // ReportOrdersViewModelBindingSource
            // 
            this.ReportOrdersViewModelBindingSource.DataSource = typeof(FishFactoryBusinessLogic.ViewModels.ReportOrdersViewModel);
            // 
            // FormReportAllOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.buttonSaveToPdf);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportAllOrders";
            this.Text = "Отчёт по всем заказам";
            this.Load += new System.EventHandler(this.FormReportAllOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportAllOrdersViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Button buttonSaveToPdf;
        private System.Windows.Forms.BindingSource ReportAllOrdersViewModelBindingSource;
        private System.Windows.Forms.BindingSource ReportOrdersViewModelBindingSource;
    }
}