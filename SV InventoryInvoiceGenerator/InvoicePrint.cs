using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace SV_InventoryInvoiceGenerator
{
    public partial class InvoicePrint : Form
    {
        public InvoicePrint(Int64 BatchNumber)
        {
            InitializeComponent();
            BatchIDText.Text = BatchNumber.ToString();
            InvoiceListing.DataSource = getInvoiceList();
            PrintAll.Enabled = true;
            printOne.Enabled = true;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadInvoices_Click(object sender, EventArgs e)
        {
            InvoiceListing.DataSource = getInvoiceList();
            PrintAll.Enabled = true;
            printOne.Enabled = true;
        }

        private DataTable getInvoiceList()
        {
            DataTable dtInvoices = new DataTable();
            String dbName = ConfigurationManager.AppSettings["DBName"];
            String DBServer = ConfigurationManager.AppSettings["DBServerName"];
            String DBUser = ConfigurationManager.AppSettings["DBUserName"];
            String DBPassword = ConfigurationManager.AppSettings["DBPassword"];

            String sqlCon = "Data Source=" + DBServer + ";Initial Catalog=" + dbName + ";User Id=" + DBUser + ";Password=" + DBPassword + ";Integrated Security=False;TrustServerCertificate=True;ConnectRetryCount=2";
            try
            {
                using (SqlConnection cn = new SqlConnection(sqlCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cn.Open();

                        String Query = @"SELECT    [SalesRepCode]
                                                  ,[InvoiceNumber]
                                                  ,[EvoInvoiceID]
                                                  ,[SalesRepName]
                                                  ,[CustomerAccountNumber]
                                                  ,[CustomerAccountname]
                                                  ,[CustomerAccountDescription]
                                                  ,[CustomerGPS]
                                                  ,[CustomerTelephone]
                                                  ,[CustomerContactPerson]
                                                  ,[CustomerAreaCode]
                                                  ,[CustomerAccountTerms]
                                                  ,[CustomerTermsDescription]
                                                  ,[InvDate]
                                                  ,[OrderNum]
                                                  ,[DeliveryNote]
                                                  ,[ExtOrderNum]
                                                  ,[BatchNumber]
                                                  ,[CreatedByUser]
                                                  ,[StagingID]
                                              FROM [SV_InvoiceHeaderForPrint]" +
                                              $"where BatchNumber = {BatchIDText.Text} ORDER BY StagingID ;"
                                        ;
                        cmd.CommandText = Query;

                        SqlDataReader reader = cmd.ExecuteReader();
                        dtInvoices.Load(reader);
                        cn.Close();                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtInvoices;

        }

        private void PrintAll_Click(object sender, EventArgs e)
        {
            //get list of invoice headers to print and pass this to invoice print
            List<InvoiceLineToPrint> lines = GetInvoiceLines(BatchIDText.Text);
            InvoicePrintPreview pp = new InvoicePrintPreview(BatchIDText.Text, lines);
            pp.ShowDialog();
        }

        private void printOne_Click(object sender, EventArgs e)
        {
            //get list of invoice headers to print and pass this to invoice print
            InvoiceHeader ih = new InvoiceHeader();
            int selectedrowindex = InvoiceListing.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = InvoiceListing.Rows[selectedrowindex];
            //            MessageBox.Show(Convert.ToString(selectedRow.Cells["EvoInvoiceID"].Value));
            //            InvoicePrintPreview pp = new InvoicePrintPreview();
            //           pp.ShowDialog();

            List<InvoiceLineToPrint> lines = GetInvoiceLines (Convert.ToInt64(selectedRow.Cells["EvoInvoiceID"].Value));
            InvoicePrintPreview pp = new InvoicePrintPreview(Convert.ToInt64(selectedRow.Cells["EvoInvoiceID"].Value), lines);
            pp.ShowDialog();
        }

        private List<InvoiceLineToPrint> GetInvoiceLines (Int64 invoiceID)
        {
            List<InvoiceLineToPrint> lines = new List<InvoiceLineToPrint>();

                String dbName = ConfigurationManager.AppSettings["DBName"];
                String DBServer = ConfigurationManager.AppSettings["DBServerName"];
            String DBUser = ConfigurationManager.AppSettings["DBUserName"];
            String DBPassword = ConfigurationManager.AppSettings["DBPassword"];

            String sqlCon = "Data Source=" + DBServer + ";Initial Catalog=" + dbName + ";User Id=" + DBUser + ";Password=" + DBPassword + ";Integrated Security=False;TrustServerCertificate=True;ConnectRetryCount=2";
            try
            {
                    using (IDbConnection cn = new SqlConnection(sqlCon))
                    {
                        if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                            String Query = @"SELECT *
                                          FROM [SV_InvoiceLinesForPrint]" +
                                          $"WHERE EvoInvoiceID = {invoiceID} ORDER BY StagingID;";
                        lines = cn.Query<InvoiceLineToPrint>(Query, commandType: CommandType.Text).ToList();
                    }


                }
            }
                catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            return lines;
        }
    private List<InvoiceLineToPrint> GetInvoiceLines (String batchNr)
    {
        List<InvoiceLineToPrint> lines = new List<InvoiceLineToPrint>();

        String dbName = ConfigurationManager.AppSettings["DBName"];
        String DBServer = ConfigurationManager.AppSettings["DBServerName"];
            String DBUser = ConfigurationManager.AppSettings["DBUserName"];
            String DBPassword = ConfigurationManager.AppSettings["DBPassword"];

            String sqlCon = "Data Source=" + DBServer + ";Initial Catalog=" + dbName + ";User Id=" + DBUser + ";Password=" + DBPassword + ";Integrated Security=False;TrustServerCertificate=True;ConnectRetryCount=2";
            try
            {
            using (IDbConnection cn = new SqlConnection(sqlCon))
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    String Query = @"SELECT  *
                                          FROM [SV_InvoiceLinesForPrint]" +
                                  $"WHERE BatchNumber = {batchNr} ORDER BY StagingID;";
                    lines = cn.Query<InvoiceLineToPrint>(Query, commandType: CommandType.Text).ToList();
                }


            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return lines;
    }

        private void InvoicePrint_Load(object sender, EventArgs e)
        {

        }
    }
}
