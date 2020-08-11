using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;
using System.Net.Http;

namespace WindowsFormsApp1
{
    public partial class LoginFrm : MaterialForm
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void  btnLogin_Click(object sender, EventArgs e)
        {
            String url = String.Format(@"https://localhost:44327/api/employees/AttemptLogin/{0}/{1}", txtEmail.Text, txtPassword.Text);
            using (var client = new HttpClient())
            {
                //HTTP GET
                var responseTask = client.GetAsync(url);
                var result = responseTask.Result;
                var employeeID = result.Content.ReadAsStringAsync().Result;
                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    frmRequestHoliday frm = new frmRequestHoliday(employeeID);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
