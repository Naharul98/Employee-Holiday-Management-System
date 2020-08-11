namespace Holiday_Reservation
{
    partial class frmFilterByDate
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
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.dgWorkingEmployee = new System.Windows.Forms.DataGridView();
            this.dgOnHoliday = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkingEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOnHoliday)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(2, 36);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(126, 37);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "Go Back";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(886, 41);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(101, 24);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Date Filter:";
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.Location = new System.Drawing.Point(993, 41);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.Size = new System.Drawing.Size(286, 22);
            this.dtpDateFilter.TabIndex = 2;
            this.dtpDateFilter.ValueChanged += new System.EventHandler(this.dtpDateFilter_ValueChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(200, 106);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(169, 24);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Working Employee";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(873, 106);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(103, 24);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "On Holiday";
            // 
            // dgWorkingEmployee
            // 
            this.dgWorkingEmployee.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgWorkingEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWorkingEmployee.Location = new System.Drawing.Point(12, 143);
            this.dgWorkingEmployee.Name = "dgWorkingEmployee";
            this.dgWorkingEmployee.RowHeadersWidth = 51;
            this.dgWorkingEmployee.RowTemplate.Height = 24;
            this.dgWorkingEmployee.Size = new System.Drawing.Size(560, 638);
            this.dgWorkingEmployee.TabIndex = 5;
            // 
            // dgOnHoliday
            // 
            this.dgOnHoliday.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgOnHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOnHoliday.Location = new System.Drawing.Point(578, 143);
            this.dgOnHoliday.Name = "dgOnHoliday";
            this.dgOnHoliday.RowHeadersWidth = 51;
            this.dgOnHoliday.RowTemplate.Height = 24;
            this.dgOnHoliday.Size = new System.Drawing.Size(701, 638);
            this.dgOnHoliday.TabIndex = 6;
            // 
            // frmFilterByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 800);
            this.Controls.Add(this.dgOnHoliday);
            this.Controls.Add(this.dgWorkingEmployee);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dtpDateFilter);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialRaisedButton1);
            this.Name = "frmFilterByDate";
            this.Text = "                       Filter By Date";
            this.Load += new System.EventHandler(this.frmFilterByDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkingEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOnHoliday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DataGridView dgWorkingEmployee;
        private System.Windows.Forms.DataGridView dgOnHoliday;
    }
}