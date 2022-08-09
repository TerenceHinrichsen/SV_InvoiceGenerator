namespace SV_InventoryInvoiceGenerator
{
    partial class InvoiceGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceGenerate));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnGenerate = new System.Windows.Forms.ToolStripButton();
            this.BtnPrint = new System.Windows.Forms.ToolStripButton();
            this.BtnClose = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.SelectedInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressIndicator = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnGenerate,
            this.BtnPrint,
            this.BtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(565, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._034_strategy;
            this.BtnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(120, 22);
            this.BtnGenerate.Text = "Generate invoices";
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._007_briefcase;
            this.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(52, 22);
            this.BtnPrint.Text = "Print";
            this.BtnPrint.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label,
            this.StatusLabel,
            this.ProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(565, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Label
            // 
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(42, 17);
            this.Label.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(164, 17);
            this.StatusLabel.Text = "Ready... click generate to start";
            // 
            // ProgressBar
            // 
            this.ProgressBar.AutoSize = false;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(300, 16);
            // 
            // SelectedInvoiceDate
            // 
            this.SelectedInvoiceDate.Location = new System.Drawing.Point(349, 5);
            this.SelectedInvoiceDate.Name = "SelectedInvoiceDate";
            this.SelectedInvoiceDate.Size = new System.Drawing.Size(216, 20);
            this.SelectedInvoiceDate.TabIndex = 4;
            this.SelectedInvoiceDate.Value = new System.DateTime(2019, 2, 16, 9, 19, 30, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(268, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Invoice date";
            // 
            // ProgressIndicator
            // 
            this.ProgressIndicator.AcceptsTab = true;
            this.ProgressIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressIndicator.Location = new System.Drawing.Point(0, 25);
            this.ProgressIndicator.Name = "ProgressIndicator";
            this.ProgressIndicator.ReadOnly = true;
            this.ProgressIndicator.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ProgressIndicator.Size = new System.Drawing.Size(565, 494);
            this.ProgressIndicator.TabIndex = 6;
            this.ProgressIndicator.Text = "";
            // 
            // InvoiceGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 541);
            this.Controls.Add(this.ProgressIndicator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedInvoiceDate);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvoiceGenerate";
            this.ShowInTaskbar = false;
            this.Text = "Invoice generator";
            this.Load += new System.EventHandler(this.InvoiceGenerate_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnGenerate;
        private System.Windows.Forms.ToolStripButton BtnClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Label;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.DateTimePicker SelectedInvoiceDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ProgressIndicator;
        private System.Windows.Forms.ToolStripButton BtnPrint;
    }
}