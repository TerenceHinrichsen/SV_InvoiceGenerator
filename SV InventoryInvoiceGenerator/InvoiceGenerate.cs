using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Pastel.Evolution;

namespace SV_InventoryInvoiceGenerator
{
    public partial class InvoiceGenerate : Form
    {
        public InvoiceGenerate()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Int64 BatchNumber { get; set; }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (SelectedInvoiceDate.Value < DateTime.Now.AddDays(-7))
            {
                MessageBox.Show("You have not selected a valid date! \n\nPlease select a date not older than 1 week from today.", "Invalid date selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String invoiceDate = SelectedInvoiceDate.Value.ToString("dd/MM/yyyy");
            if (MessageBox.Show("Invoices will be generated with an invoice date of: " + invoiceDate +"\nAre you sure!", "Are you sure?"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question) == DialogResult.Yes)
            {

                StatusLabel.Text = "Validating data";
            ProgressIndicator.AppendText("Process initialised, please do not close this window untill process completed!");
//            ProgressBar.Value = 1;

            DataTable InvoiceHeader = getInvoiceHeaders();
            DataTable InvoiceLines = getInvoiceLines(SelectedInvoiceDate.Value);
            int NumberOfInvoicesToGenerate = InvoiceHeader.Rows.Count;
            int NumberOfInvoiceLinesToGenerate = InvoiceLines.Rows.Count;

            ProgressIndicator.AppendText("\r\nFound " + NumberOfInvoicesToGenerate + " invoice(s) to generate.");
            ProgressIndicator.AppendText("\r\nFound " + NumberOfInvoiceLinesToGenerate + " lines to generate.");

            if(NumberOfInvoicesToGenerate > 0 )
            {

                Int64 BatchNumber = GetNextBatchNumber(NumberOfInvoicesToGenerate);

                ProgressIndicator.SelectionColor = Color.Blue;
                ProgressIndicator.AppendText("\r\nBATCH NUMBER: " + BatchNumber + " ;");
                ProgressIndicator.SelectionColor = Color.Black;


                int steps = NumberOfInvoicesToGenerate / 101;
//                    ProgressBar.Maximum = NumberOfInvoicesToGenerate + 100;
 //                   ProgressBar.Value = 5;
                foreach( DataRow customer in InvoiceHeader.Rows) // customers
                {
                    String customerAccountNumber = customer["Account"].ToString();
                    String ExternalOrderNumber = customer["ExternalOrderNumber"].ToString();
                    String DeliverToAccount = customer["DeliveryAccount"].ToString();
                    String SalesRep = customer["SalesRep"].ToString();

                        ProgressIndicator.AppendText("\r\n\tCustomer: " + customerAccountNumber);
                        StatusLabel.Text = "Processing " + customerAccountNumber;

                    // initialise SDK and create invoice object
                    String dbName = ConfigurationManager.AppSettings["DBName"];
                    String DBServer = ConfigurationManager.AppSettings["DBServerName"];
                    String DBUser = ConfigurationManager.AppSettings["DBUserName"];
                    String DBPassword = ConfigurationManager.AppSettings["DBPassword"];
                    String EvoBranchID = ConfigurationManager.AppSettings["EvoBranchID"];
                    String EvoWarehouseCode = ConfigurationManager.AppSettings["EvoWarehouseCode"];

                        try
                        {
                            //TESTING
//                        DatabaseContext.CreateCommonDBConnection("10.21.64.29", "EvolutionCommon","inbox", "6%U%wgur]qrCz3k8c22t", false);
                        DatabaseContext.CreateCommonDBConnection(DBServer, "EvolutionCommon", DBUser, DBPassword, false);
                        DatabaseContext.SetLicense("DE10110187", "8026340");
                        DatabaseContext.CreateConnection(DBServer, dbName, DBUser, DBPassword, false);
                    }
                    catch (Exception sdkE)
                    {
                        MessageBox.Show(sdkE.Message);
                        StatusLabel.Text = "SDK error: " + sdkE.Message.ToString();
                        break;
                    }
                    DatabaseContext.SetBranchContext(Convert.ToInt32(EvoBranchID));


                    SalesOrder so = new SalesOrder();
                    Customer cust = new Customer(customerAccountNumber);
                    SalesRepresentative sr = new SalesRepresentative(SalesRep);
                    so.Customer = cust; 
                    so.InvoiceDate = SelectedInvoiceDate.Value;
                    so.ExternalOrderNo = ExternalOrderNumber;
                    so.Representative = sr;
                    DataView dv = new DataView(InvoiceLines);
                    dv.RowFilter = "DeliverToAccount = '" + customer["DeliveryAccount"] + "'";

                    foreach (DataRowView products in dv)
                    {
                        try
                        {
                            // add product to invoice objects
                            String productCode = products["ProductCode"].ToString();
                            Double productQty = Convert.ToDouble(products["QuantityToInvoice"]);
                            Double customerSpecialPrice = Convert.ToDouble(products["CustomerSpecialPrice"]);

                            OrderDetail od = new OrderDetail();
                            so.Detail.Add(od);
                            od.InventoryItem = new InventoryItem(productCode);
                            od.Warehouse = new Warehouse(EvoWarehouseCode);
                            od.Quantity = productQty;
                            od.ToProcess = od.Quantity;

                            ///first check if we don;t have an price on a contract else use the default price;
                            if (customerSpecialPrice == 0.00)
                                {
                                    od.UnitSellingPrice = od.InventoryItem.SellingPrices[so.Customer.DefaultPriceList].PriceExcl;
                                }
                                else od.UnitSellingPrice = customerSpecialPrice;


                                ProgressIndicator.AppendText("\r\n\t\tProduct code: " + productCode + "\tQuantity: " + productQty);

                       }
                        catch (Exception lineException)
                        {
                            ProgressIndicator.SelectionColor = Color.Red;
                            ProgressIndicator.AppendText("\r\n##ERROR: " + lineException.Message);
                            ProgressIndicator.SelectionColor = Color.Black;
                        }
                    }

                    try
                    {
                        so.Process();
                        UpdateStagingTable(DeliverToAccount, so.Reference, BatchNumber);

                    }
                    catch (Exception processException)
                    {
                        MessageBox.Show(processException.Message);
                    }
                    // save and process invoice
                    ProgressIndicator.AppendText("\r\nOrder number: " + so.OrderNo);
                    ProgressIndicator.AppendText("\r\nInvoice generated: " + so.Reference);
                    //update the staging table with the invoice number and metadata for the invoice
                    // done with the record, update progress bar and move along!
//                    ProgressBar.Value += steps-1;
                }

                StatusLabel.Text = "Completed!";
//                ProgressBar.Value = 100;
            }
            else
            {
                MessageBox.Show("No invoices to generate!\r\nImport invoice data from Sales Master first!");
            }
            }

        }

        private DataTable getInvoiceHeaders()
        {
            DataTable dt = new DataTable();

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

                        String Query = @"SELECT [Account], [Name]
                                                  ,[Physical1]
                                                  ,[Physical2]
                                                  ,[Physical3]
                                                  ,[Physical4]
                                                  ,[Physical5]
                                                  ,[Telephone]
                                                  ,[ExternalOrderNumber]
                                                  ,[DeliveryAccount]
                                                  ,[SalesRep]
                                        FROM [SV_InvoiceHeaderToGenerate] ORDER BY StagingID";
                        cmd.CommandText = Query;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        cn.Close();
                        da.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
            }

            return dt;
        }

        private DataTable getInvoiceLines(DateTime InvoiceDate)
        {
            DataTable dt = new DataTable();

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

                        String Query = @"
                                        SELECT LineID,
                                               ARAccountNumber,
                                               ProductCode,
                                               QuantityToInvoice,
                                               DeliverToAccount,
                                               CustomerSpecialPrice
                                        FROM dbo.SV_InvoiceLinesToGenerateFunction('"
                                        + InvoiceDate.ToString("yyyy-MM-dd") + "')";
                        cmd.CommandText = Query;
                        MessageBox.Show(Query);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(dt);
                        cn.Close();
                        da.Dispose();

                    }
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
            }

            return dt;
        }

        private void UpdateStagingTable(string accountNumber, string invoiceNumber, Int64 BatchNumber)
        {
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

                        String Query = @"update SV_InvoiceStaging
                                    set InvoiceGeneratedOnDateTime = '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "'" +
                                        ",	InvoiceNumber = '" + invoiceNumber + "'" +
                                        ",	BatchNumber = " + BatchNumber +
                                    "WHERE ARAccountNumber = '" + accountNumber + "'" +
                                    "AND InvoiceGeneratedOnDateTime is null;";
                        cmd.CommandText = Query;

                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateStagingTableLineOnError(Int64 LineNumber)
        {
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

                        String Query = @"update SV_InvoiceStaging
                                    set InvoiceGeneratedOnDateTime = '" + DateTime.Now + "'" +
                                        ",	InvoiceNumber = '##ERROR##'" +
                                        ",	BatchNumber = 1" +
                                        "WHERE ID = " + LineNumber + ";"
                                        ; //TODO: get batch number for printing purposes!!!
                    
                        cmd.CommandText = Query;

                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        private Int64 GetNextBatchNumber(int numberOfLines)
        {
            
            Int64 newID = 0;
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

                        String Query = @"insert into SV_InvoiceCreateLog (CommentsRemarks)
                                            OUTPUT INSERTED.ID
                                            VALUES ('Batch should contain " + numberOfLines.ToString() +" invoice(s)')";

                            cmd.CommandText = Query;
                            
                            newID = (Int64)cmd.ExecuteScalar();
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                MessageBox.Show(ex.Message);
                    StatusLabel.Text = ex.Message;
                }

            BatchNumber = newID;
            return newID;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InvoicePrint ip = new InvoicePrint(BatchNumber);
            ip.ShowDialog();

        }

        private void InvoiceGenerate_Load(object sender, EventArgs e)
        {
            SelectedInvoiceDate.Value = DateTime.Today.AddDays(-8);
        }
    }


}
