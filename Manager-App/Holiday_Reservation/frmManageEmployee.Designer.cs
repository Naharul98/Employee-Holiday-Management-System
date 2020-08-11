namespace Holiday_Reservation
{
    partial class frmManageEmployee
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
            this.dgEmployee = new System.Windows.Forms.DataGridView();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEmployee
            // 
            this.dgEmployee.AllowUserToAddRows = false;
            this.dgEmployee.AllowUserToDeleteRows = false;
            this.dgEmployee.AllowUserToOrderColumns = true;
            this.dgEmployee.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployee.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgEmployee.Location = new System.Drawing.Point(12, 112);
            this.dgEmployee.Name = "dgEmployee";
            this.dgEmployee.ReadOnly = true;
            this.dgEmployee.RowHeadersWidth = 51;
            this.dgEmployee.RowTemplate.Height = 24;
            this.dgEmployee.Size = new System.Drawing.Size(861, 663);
            this.dgEmployee.TabIndex = 0;
            this.dgEmployee.SelectionChanged += new System.EventHandler(this.dgEmployee_SelectionChanged);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(2, 34);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(168, 41);
            this.materialRaisedButton1.TabIndex = 1;
            this.materialRaisedButton1.Text = "Go Back";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(727, 34);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(168, 41);
            this.materialRaisedButton2.TabIndex = 2;
            this.materialRaisedButton2.Text = "Add Employee";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // frmManageEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 812);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.dgEmployee);
            this.Name = "frmManageEmployee";
            this.Text = "                                                                   Employee List";
            this.Load += new System.EventHandler(this.frmManageEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEmployee;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}