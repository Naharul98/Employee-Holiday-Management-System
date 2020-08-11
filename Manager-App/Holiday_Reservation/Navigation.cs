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

    public partial class frmNavigation : MaterialForm
    {
        public frmNavigation()
        {
            InitializeComponent();
        }

        private void Navigation_Load(object sender, EventArgs e)
        {

        }

        //if exit button pressed, then quit the application
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        //show form for checking out employee records
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            frmManageEmployee z = new frmManageEmployee();
            z.Show();
        }

        //show navigation form for managing holiday request
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            frmManageHolidayNavigation z = new frmManageHolidayNavigation();
            z.Show();
            this.Hide();
        }
    }
}
