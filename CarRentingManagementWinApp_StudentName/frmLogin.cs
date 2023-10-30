using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ProjectManagementWinApp_VOTHITHANHVAN
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            IConfiguration config = new ConfigurationBuilder()
                                     .SetBasePath(Directory.GetCurrentDirectory())
                                     .AddJsonFile("appsettings.json", true, true)
                                     .Build();
            var adminUser = config["AdminAccount:Email"];
            var adminPassword = config["AdminAccount:Password"];

            if (adminUser == txtUserName.Text && adminPassword == txtPassword.Text)
            {
                frmCustomerManagement f = new frmCustomerManagement();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have no permission to do this function!");
            }

        }
    }
}
