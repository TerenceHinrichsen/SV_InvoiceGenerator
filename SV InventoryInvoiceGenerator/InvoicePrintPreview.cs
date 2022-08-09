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
    public partial class InvoicePrintPreview : Form
    {
        List<InvoiceLineToPrint> _lines;

        String BatchNumber;

        public InvoicePrintPreview(String batchNumber, List<InvoiceLineToPrint> lines)
        {
            InitializeComponent();
            BatchNumber = batchNumber;
            _lines = lines;
        }
        public InvoicePrintPreview(Int64 invoiceID, List<InvoiceLineToPrint> lines)
        {
            InitializeComponent();

            _lines = lines;
        }
        private void InvoicePreview_Load(object sender, EventArgs e)
        {

        }

        private void InvoicePrintPreview_Load(object sender, EventArgs e)
        {
            InvoiceReport1.SetDataSource(_lines);

        }
    }
}
