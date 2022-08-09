namespace SV_InventoryInvoiceGenerator
{
    partial class InvoicePrintPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicePrintPreview));
            this.InvoicePreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.InvoiceReport1 = new SV_InventoryInvoiceGenerator.InvoiceReport();
            this.SuspendLayout();
            // 
            // InvoicePreview
            // 
            this.InvoicePreview.ActiveViewIndex = 0;
            this.InvoicePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvoicePreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.InvoicePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoicePreview.Location = new System.Drawing.Point(0, 0);
            this.InvoicePreview.Name = "InvoicePreview";
            this.InvoicePreview.ReportSource = this.InvoiceReport1;
            this.InvoicePreview.Size = new System.Drawing.Size(1102, 733);
            this.InvoicePreview.TabIndex = 0;
            this.InvoicePreview.Load += new System.EventHandler(this.InvoicePreview_Load);
            // 
            // InvoicePrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 733);
            this.Controls.Add(this.InvoicePreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvoicePrintPreview";
            this.Text = "Print Preview";
            this.Load += new System.EventHandler(this.InvoicePrintPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer InvoicePreview;
        private InvoiceReport InvoiceReport1;
    }
}