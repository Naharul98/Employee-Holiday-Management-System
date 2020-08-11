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
    public partial class frmManageHolidayNavigation : MaterialForm
    {
        public frmManageHolidayNavigation()
        {
            InitializeComponent();
        }

        private void frmManageHolidayNavigation_Load(object sender, EventArgs e)
        {

        }

        //if back button pressed, show the previous form
        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            frmNavigation z = new frmNavigation();
            z.Show();
            this.Hide();
        }

        //show form which shows outstanding requests
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            frmOutstandingRequests z = new frmOutstandingRequests();
            z.Show();
        }

        //show form which shows all bookings
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            frmBookings z = new frmBookings();
            z.Show();
        }

        //show form for filtering by date
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            frmFilterByDate z = new frmFilterByDate();
            z.Show();
        }
    }
}
