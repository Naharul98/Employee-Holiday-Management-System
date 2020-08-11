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

namespace Holiday_Reservation
{
    //This is the class representing login form of the application
    public partial class LoginFrm : MaterialForm
    {
        public LoginFrm()
        {
            InitializeComponent();
           
        }

        //if exit button is clicked, quit the application
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        //if login is clicked, validate if credentials entered is a valid one, if so, then log the user in
        //if not, then deny login.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //using the database entity model
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //get admin employee records in the database with matching email and password input in the login form
                var record = context.Employees.Where(emp => emp.email == txtEmail.Text).Where(emp => emp.password == txtPassword.Text).Where(emp => emp.Role.role_name == "admin");
                //if we are able to find a matching record in the database then
                if (record.Count() > 0)
                {
                    //Log the user in, and show the navigation form
                    frmNavigation f2 = new frmNavigation();
                    f2.Show();
                    this.Hide();
                }
                else 
                {
                    //if login credentials dont match, then display messagebox informing the user
                    MessageBox.Show("invalid credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
