namespace FishFactoryView
{
    partial class FormMails
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPage1 = new System.Windows.Forms.Button();
            this.buttonPage3 = new System.Windows.Forms.Button();
            this.buttonPage5 = new System.Windows.Forms.Button();
            this.buttonPage4 = new System.Windows.Forms.Button();
            this.buttonPage2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(629, 256);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(75, 264);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.Text = "Назад";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(489, 264);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Вперёд";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPage1
            // 
            this.buttonPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage1.Location = new System.Drawing.Point(176, 264);
            this.buttonPage1.Name = "buttonPage1";
            this.buttonPage1.Size = new System.Drawing.Size(46, 23);
            this.buttonPage1.TabIndex = 3;
            this.buttonPage1.Text = "1";
            this.buttonPage1.UseVisualStyleBackColor = false;
            this.buttonPage1.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage3
            // 
            this.buttonPage3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage3.Location = new System.Drawing.Point(302, 264);
            this.buttonPage3.Name = "buttonPage3";
            this.buttonPage3.Size = new System.Drawing.Size(46, 23);
            this.buttonPage3.TabIndex = 4;
            this.buttonPage3.Text = "3";
            this.buttonPage3.UseVisualStyleBackColor = false;
            this.buttonPage3.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage5
            // 
            this.buttonPage5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage5.Location = new System.Drawing.Point(428, 264);
            this.buttonPage5.Name = "buttonPage5";
            this.buttonPage5.Size = new System.Drawing.Size(46, 23);
            this.buttonPage5.TabIndex = 5;
            this.buttonPage5.Text = "5";
            this.buttonPage5.UseVisualStyleBackColor = false;
            this.buttonPage5.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage4
            // 
            this.buttonPage4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage4.Location = new System.Drawing.Point(366, 264);
            this.buttonPage4.Name = "buttonPage4";
            this.buttonPage4.Size = new System.Drawing.Size(46, 23);
            this.buttonPage4.TabIndex = 6;
            this.buttonPage4.Text = "4";
            this.buttonPage4.UseVisualStyleBackColor = false;
            this.buttonPage4.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage2
            // 
            this.buttonPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage2.Location = new System.Drawing.Point(240, 264);
            this.buttonPage2.Name = "buttonPage2";
            this.buttonPage2.Size = new System.Drawing.Size(46, 23);
            this.buttonPage2.TabIndex = 7;
            this.buttonPage2.Text = "2";
            this.buttonPage2.UseVisualStyleBackColor = false;
            this.buttonPage2.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // FormMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 290);
            this.Controls.Add(this.buttonPage2);
            this.Controls.Add(this.buttonPage4);
            this.Controls.Add(this.buttonPage5);
            this.Controls.Add(this.buttonPage3);
            this.Controls.Add(this.buttonPage1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMails";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPage1;
        private System.Windows.Forms.Button buttonPage3;
        private System.Windows.Forms.Button buttonPage5;
        private System.Windows.Forms.Button buttonPage4;
        private System.Windows.Forms.Button buttonPage2;
    }
}