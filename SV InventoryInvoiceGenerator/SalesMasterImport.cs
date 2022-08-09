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
using System.IO;
using System.Data.OleDb;

namespace SV_InventoryInvoiceGenerator
{
    public partial class SalesMasterImport : Form
    {
        public SalesMasterImport()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to close, this will remove all the data in this grid!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)

            {
                //Delete unprocessed staging data!!
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

                            String Query = @"delete SV_InvoiceStaging
                                           where InvoiceGeneratedOnDateTime is null"
                                            ;

                            cmd.CommandText = Query;

                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = ex.Message;
                }

                this.Close();
            }
           
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Importing sales master data to database";
            String dbName = ConfigurationManager.AppSettings["DBName"];
            String DBServer = ConfigurationManager.AppSettings["DBServerName"];
            String DBUser = ConfigurationManager.AppSettings["DBUserName"];
            String DBPassword = ConfigurationManager.AppSettings["DBPassword"];

            String sqlCon = "Data Source=" +DBServer+ ";Initial Catalog=" + dbName + ";User Id="+DBUser+";Password="+DBPassword+";Integrated Security=False;TrustServerCertificate=True;ConnectRetryCount=2";

            try
            {
                using (SqlConnection cn = new SqlConnection(sqlCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cn.Open();

                        MessageBox.Show("This process could take a few minutes, please be patient!");
                        String query = "";
                                    //@"INSERT INTO SV_InvoiceStaging (ARAccountNumber, ProductCode, QuantityToInvoice)
                                    //VALUES ('ABC001','X30',10)";
                        for (int i = 0; i < SalesMasterDataGrid.Rows.Count - 1; i++)
                        {
                            if (SalesMasterDataGrid.Rows[i].Cells[0].Value.ToString() == "0" || SalesMasterDataGrid.Rows[i].Cells[0].Value.ToString() == "")
                            {
                                // taking the break out so it will not process the record, but not break out of the loop either.
  //                              MessageBox.Show("Line: " + i.ToString() + " is blank, moving along....");                              
                                //break; // so this will take us out of the loop when there is not a valid customer account in the row
                            }
                            else { 
                            String CustomerCode = SalesMasterDataGrid.Rows[i].Cells[0].Value.ToString();
                            String ExternalOrderNumber = SalesMasterDataGrid.Rows[i].Cells[1].Value.ToString();
//                                MessageBox.Show("Working on " + CustomerCode + "!");
                            for (int j = 2; j < SalesMasterDataGrid.Columns.Count; j++)
                            {

                                if (SalesMasterDataGrid.Rows[i].Cells[j].Value.ToString() != "0")
                                {
                                    query = @"INSERT INTO SV_InvoiceStaging(ARAccountNumber,ExternalOrderNumber, ProductCode, QuantityToInvoice) VALUES ('"
                                    + CustomerCode + "','"+ ExternalOrderNumber + "','" + SalesMasterDataGrid.Columns[j].HeaderText + "','" + //product code
                                             SalesMasterDataGrid.Rows[i].Cells[j].Value.ToString() + "')"; //product quantity
//                                   MessageBox.Show(query);
                                    cmd.CommandText = query;
                                    cmd.ExecuteNonQuery();

                                }

                            }
                            }
                        }
                    }
                    cn.Close();
                }
                MessageBox.Show("Staging completed!");
                StatusLabel.Text = "Operation completed . . . Click close to exit window";
                this.Close();
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
                MessageBox.Show(ex.Message);
            }

        }

        private void SalesMasterImport_Load(object sender, EventArgs e)
        {
            //// delete the current unprocessed staging data - there can only be ONE!
            ///
            //Delete unprocessed staging data!!
            String dbName = ConfigurationManager.AppSettings["DBName"];
            String DBServer = ConfigurationManager.AppSettings["DBServerName"];
            String DBUser = ConfigurationManager.AppSettings["DBUserName"];
            String DBPassword = ConfigurationManager.AppSettings["DBPassword"];

            String sqlCon = "Data Source=" + DBServer + ";Initial Catalog=" + dbName + ";User Id=" + DBUser + ";Password=" + DBPassword + ";Integrated Security=False;TrustServerCertificate=True;ConnectRetryCount=2";
            try
            {
                using (SqlConnection cn = new SqlConnection(sqlCon))
                {
                    using (SqlCommand comd = new SqlCommand())
                    {
                        comd.Connection = cn;
                        cn.Open();

                        String Query = @"delete SV_InvoiceStaging
                                           where InvoiceGeneratedOnDateTime is null"
                                        ;

                        comd.CommandText = Query;

                        comd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
            }
////
/// Now import the new staging data!!


            String sPath, SheetName, connectString;

            // get the strings from App Settings and store in local variable
            sPath = ConfigurationManager.AppSettings["SalesMasterLocation"];
            SheetName = ConfigurationManager.AppSettings["SMSheetName"];

            // build connection string to Excel file
            connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            sPath +
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(connectString);
            OleDbCommand cmd = new OleDbCommand("select * from [" + SheetName + "$]", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            SalesMasterDataGrid.DataSource = data;
            con.Close(); //so the excel file is usable again.



        }
    }
}
