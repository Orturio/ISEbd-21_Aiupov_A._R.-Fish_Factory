namespace FishFactoryView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИзделийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияПоКомпонентамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.создатьБэкапToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.письмаToolStripMenuItem,
            this.создатьБэкапToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.ИзделияToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click_1);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click_1);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокИзделийToolStripMenuItem,
            this.изделияПоКомпонентамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокИзделийToolStripMenuItem
            // 
            this.списокИзделийToolStripMenuItem.Name = "списокИзделийToolStripMenuItem";
            this.списокИзделийToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.списокИзделийToolStripMenuItem.Text = "Список изделий";
            this.списокИзделийToolStripMenuItem.Click += new System.EventHandler(this.CannedsToolStripMenuItem_Click);
            // 
            // изделияПоКомпонентамToolStripMenuItem
            // 
            this.изделияПоКомпонентамToolStripMenuItem.Name = "изделияПоКомпонентамToolStripMenuItem";
            this.изделияПоКомпонентамToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.изделияПоКомпонентамToolStripMenuItem.Text = "Изделия по компонентам";
            this.изделияПоКомпонентамToolStripMenuItem.Click += new System.EventHandler(this.изделияПоКомпонентамToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click_1);
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.письмаToolStripMenuItem.Text = "Письма";
            this.письмаToolStripMenuItem.Click += new System.EventHandler(this.письмаToolStripMenuItem_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(634, 27);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(134, 34);
            this.buttonCreateOrder.TabIndex = 7;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(634, 190);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(134, 37);
            this.buttonPayOrder.TabIndex = 10;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(634, 242);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(134, 39);
            this.buttonRef.TabIndex = 11;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(628, 421);
            this.dataGridView.TabIndex = 12;
            // 
            // создатьБэкапToolStripMenuItem
            // 
            this.создатьБэкапToolStripMenuItem.Name = "создатьБэкапToolStripMenuItem";
            this.создатьБэкапToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.создатьБэкапToolStripMenuItem.Text = "Создать бэкап";
            this.создатьБэкапToolStripMenuItem.Click += new System.EventHandler(this.создатьБэкапToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Рыбный завод";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИзделийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияПоКомпонентамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem письмаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьБэкапToolStripMenuItem;
    }
}