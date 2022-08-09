using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV_InventoryInvoiceGenerator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            ConfigMenu cf = new ConfigMenu();
            cf.ShowDialog();

        }

        private void BtnImportSalesMaster_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will import the Sales master to the screen, please be patient");
            SalesMasterImport sm = new SalesMasterImport();
            sm.Show();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            InvoiceGenerate ig = new InvoiceGenerate();
            ig.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();

        }
    }
}
