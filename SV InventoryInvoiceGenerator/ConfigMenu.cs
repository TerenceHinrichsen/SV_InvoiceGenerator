using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Net;


namespace SV_InventoryInvoiceGenerator
{
    public partial class ConfigMenu : Form
    {
        public ConfigMenu()
        {
            InitializeComponent();
        }

        private void BtnCloseNoSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No changes will be saved!");
            this.Close();

        }

        private void BtnCloseSave_Click(object sender, EventArgs e)
        {
            if (SalesMaster.TextLength < 5)
            {
                SalesMaster.BackColor = System.Drawing.Color.Red;
            }
            else if (DBServerName.TextLength < 5)
            {
                DBServerName.BackColor = System.Drawing.Color.Red;
            }
            else if (DBName.TextLength < 5)
            {
                DBName.BackColor = System.Drawing.Color.Red;

            }
            else if (SMSheetName.TextLength < 5)
            {
                SMSheetName.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                if (MessageBox.Show("Current settings will not be recoverable and will be overwritten by the values you have provided", "Are you sure?"
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    config.AppSettings.Settings.Remove("SalesMasterLocation");
                    config.AppSettings.Settings.Add("SalesMasterLocation", SalesMaster.Text);
                    config.AppSettings.Settings.Remove("DBUserName");
                    config.AppSettings.Settings.Add("DBUserName", SQLUserName.Text);
                    config.AppSettings.Settings.Remove("DBPassword");
                    config.AppSettings.Settings.Add("DBPassword", SQLPassword.Text);
                    config.AppSettings.Settings.Remove("DBServerName");
                    config.AppSettings.Settings.Add("DBServerName", DBServerName.Text);
                    config.AppSettings.Settings.Remove("DBName");
                    config.AppSettings.Settings.Add("DBName", DBName.Text);
                    config.AppSettings.Settings.Remove("SMSheetName");
                    config.AppSettings.Settings.Add("SMSheetName", SMSheetName.Text);
                    config.AppSettings.Settings.Remove("EvoBranchID");
                    config.AppSettings.Settings.Add("EvoBranchID", EvoBranchID.Text);
                    config.AppSettings.Settings.Remove("EvoWarehouseCode");
                    config.AppSettings.Settings.Add("EvoWarehouseCode", EvoWarehouseCode.Text);

                    config.Save(ConfigurationSaveMode.Full, true);
                    ConfigurationManager.RefreshSection("appSettings");

                    this.Close();
                }

            }

        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            fd.ShowDialog();
            SalesMaster.Text = fd.FileName;
        }

        private void ConfigMenu_Load(object sender, EventArgs e)
        {
            SalesMaster.Text = ConfigurationManager.AppSettings["SalesMasterLocation"];
            DBServerName.Text = ConfigurationManager.AppSettings["DBServerName"];
            DBName.Text = ConfigurationManager.AppSettings["DBName"];
            SMSheetName.Text = ConfigurationManager.AppSettings["SMSheetName"];
            SQLUserName.Text = ConfigurationManager.AppSettings["DBUserName"];
            EvoBranchID.Text = ConfigurationManager.AppSettings["EvoBranchID"];
            EvoWarehouseCode.Text = ConfigurationManager.AppSettings["EvoWarehouseCode"];
        }

        private void SalesMaster_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
