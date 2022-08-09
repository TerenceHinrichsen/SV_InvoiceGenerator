namespace SV_InventoryInvoiceGenerator
{
    partial class InvoicePrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicePrint));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BatchNumberLabel = new System.Windows.Forms.ToolStripLabel();
            this.BatchIDText = new System.Windows.Forms.ToolStripTextBox();
            this.LoadInvoices = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.printOne = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.InvoiceListing = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceListing)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BatchNumberLabel,
            this.BatchIDText,
            this.LoadInvoices,
            this.toolStripSeparator4,
            this.printOne,
            this.toolStripSeparator3,
            this.PrintAll,
            this.toolStripSeparator1,
            this.BtnClose,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1139, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BatchNumberLabel
            // 
            this.BatchNumberLabel.Name = "BatchNumberLabel";
            this.BatchNumberLabel.Size = new System.Drawing.Size(85, 22);
            this.BatchNumberLabel.Text = "Batch number:";
            // 
            // BatchIDText
            // 
            this.BatchIDText.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.BatchIDText.Name = "BatchIDText";
            this.BatchIDText.Size = new System.Drawing.Size(100, 25);
            this.BatchIDText.ToolTipText = "Enter the batch number to filter by";
            // 
            // LoadInvoices
            // 
            this.LoadInvoices.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._001_analytic;
            this.LoadInvoices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadInvoices.Name = "LoadInvoices";
            this.LoadInvoices.Size = new System.Drawing.Size(86, 22);
            this.LoadInvoices.Text = "Load batch";
            this.LoadInvoices.Click += new System.EventHandler(this.LoadInvoices_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // printOne
            // 
            this.printOne.Enabled = false;
            this.printOne.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._002_atm;
            this.printOne.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printOne.Name = "printOne";
            this.printOne.Size = new System.Drawing.Size(98, 22);
            this.printOne.Text = "Print selected";
            this.printOne.Click += new System.EventHandler(this.printOne_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // PrintAll
            // 
            this.PrintAll.Enabled = false;
            this.PrintAll.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._009_calendar;
            this.PrintAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintAll.Name = "PrintAll";
            this.PrintAll.Size = new System.Drawing.Size(67, 22);
            this.PrintAll.Text = "Print all";
            this.PrintAll.Click += new System.EventHandler(this.PrintAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnClose
            // 
            this.BtnClose.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._016_investment;
            this.BtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(56, 22);
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // InvoiceListing
            // 
            this.InvoiceListing.AllowUserToAddRows = false;
            this.InvoiceListing.AllowUserToDeleteRows = false;
            this.InvoiceListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvoiceListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceListing.Location = new System.Drawing.Point(0, 25);
            this.InvoiceListing.Name = "InvoiceListing";
            this.InvoiceListing.Size = new System.Drawing.Size(1139, 692);
            this.InvoiceListing.TabIndex = 1;
            // 
            // InvoicePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 717);
            this.Controls.Add(this.InvoiceListing);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvoicePrint";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvoicePrint";
            this.Load += new System.EventHandler(this.InvoicePrint_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceListing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnClose;
        private System.Windows.Forms.ToolStripLabel BatchNumberLabel;
        private System.Windows.Forms.ToolStripTextBox BatchIDText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton LoadInvoices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton printOne;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton PrintAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView InvoiceListing;
    }
}