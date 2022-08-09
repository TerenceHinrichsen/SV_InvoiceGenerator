namespace SV_InventoryInvoiceGenerator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnImportSalesMaster = new System.Windows.Forms.Button();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.BtnConfig = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.BtnImportSalesMaster);
            this.MainPanel.Controls.Add(this.BtnGenerate);
            this.MainPanel.Controls.Add(this.BtnConfig);
            this.MainPanel.Controls.Add(this.BtnClose);
            this.MainPanel.Controls.Add(this.button1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(703, 499);
            this.MainPanel.TabIndex = 0;
            // 
            // BtnImportSalesMaster
            // 
            this.BtnImportSalesMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImportSalesMaster.Image = ((System.Drawing.Image)(resources.GetObject("BtnImportSalesMaster.Image")));
            this.BtnImportSalesMaster.Location = new System.Drawing.Point(3, 3);
            this.BtnImportSalesMaster.Name = "BtnImportSalesMaster";
            this.BtnImportSalesMaster.Size = new System.Drawing.Size(328, 228);
            this.BtnImportSalesMaster.TabIndex = 0;
            this.BtnImportSalesMaster.Text = "Import sales master";
            this.BtnImportSalesMaster.UseVisualStyleBackColor = true;
            this.BtnImportSalesMaster.Click += new System.EventHandler(this.BtnImportSalesMaster_Click);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerate.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._001_analytic;
            this.BtnGenerate.Location = new System.Drawing.Point(337, 3);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(328, 228);
            this.BtnGenerate.TabIndex = 1;
            this.BtnGenerate.Text = "Generate invoices";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // BtnConfig
            // 
            this.BtnConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfig.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._033_statement;
            this.BtnConfig.Location = new System.Drawing.Point(3, 237);
            this.BtnConfig.Name = "BtnConfig";
            this.BtnConfig.Size = new System.Drawing.Size(328, 228);
            this.BtnConfig.TabIndex = 3;
            this.BtnConfig.Text = "Configuration / Setup";
            this.BtnConfig.UseVisualStyleBackColor = true;
            this.BtnConfig.Click += new System.EventHandler(this.BtnConfig_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Image = global::SV_InventoryInvoiceGenerator.Properties.Resources._002_atm;
            this.BtnClose.Location = new System.Drawing.Point(337, 237);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(328, 228);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(3, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Help / About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 499);
            this.Controls.Add(this.MainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Success Ventures invoice import tool";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.Button BtnImportSalesMaster;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Button BtnConfig;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button button1;
    }
}

