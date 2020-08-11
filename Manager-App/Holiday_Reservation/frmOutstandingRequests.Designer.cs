namespace Holiday_Reservation
{
    partial class frmOutstandingRequests
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
            this.dgOutstandingRequests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgOutstandingRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(12, 32);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(133, 41);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "Go Back";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // dgOutstandingRequests
            // 
            this.dgOutstandingRequests.AllowUserToAddRows = false;
            this.dgOutstandingRequests.AllowUserToDeleteRows = false;
            this.dgOutstandingRequests.AllowUserToOrderColumns = true;
            this.dgOutstandingRequests.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgOutstandingRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOutstandingRequests.Location = new System.Drawing.Point(12, 102);
            this.dgOutstandingRequests.Name = "dgOutstandingRequests";
            this.dgOutstandingRequests.ReadOnly = true;
            this.dgOutstandingRequests.RowHeadersWidth = 51;
            this.dgOutstandingRequests.RowTemplate.Height = 24;
            this.dgOutstandingRequests.Size = new System.Drawing.Size(871, 698);
            this.dgOutstandingRequests.TabIndex = 1;
            this.dgOutstandingRequests.SelectionChanged += new System.EventHandler(this.dgOutstandingRequests_SelectionChanged);
            // 
            // frmOutstandingRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 812);
            this.Controls.Add(this.dgOutstandingRequests);
            this.Controls.Add(this.materialRaisedButton1);
            this.Name = "frmOutstandingRequests";
            this.Text = "                                                                Outstanding Reque" +
    "st";
            this.Load += new System.EventHandler(this.frmOutstandingRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOutstandingRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.DataGridView dgOutstandingRequests;
    }
}