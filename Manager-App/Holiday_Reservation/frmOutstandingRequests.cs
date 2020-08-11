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
    public partial class frmOutstandingRequests : MaterialForm
    {
        public frmOutstandingRequests()
        {
            InitializeComponent();
        }

        //this method is called when the form loads
        //populates data grid to show outstanding holiday records
        private void frmOutstandingRequests_Load(object sender, EventArgs e)
        {
            populateDataGrid();
        }

        //populates data grid to show outstanding holiday records
        public void populateDataGrid()
        {
            //using database model
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //gets holiday requests from database which has been neither approved or rejected
                var record = context.HolidayRequests.Where(p => p.approval ==null).Select(p => new { p.Id, p.Employee.name, p.date_from, p.date_to, p.reason, p.Employee.Department.department_name, p.Employee.Role.role_name });
                //add records to data grid view in order to display them
                dgOutstandingRequests.DataSource = record.ToList();
                dgOutstandingRequests.AutoResizeColumns();
            }
        }

        //close the form
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //send id of the selected holiday in the datagrid to the holiday approval/rejection form
        private void dgOutstandingRequests_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView gv = sender as DataGridView;
            if (gv.SelectedRows.Count == 1)
            {
                if (gv.Focused)
                {
                    //get id of the selected employee in the data grid
                    int x = dgOutstandingRequests.CurrentCell.RowIndex;
                    int y = (int)dgOutstandingRequests.Rows[x].Cells[0].Value;
                    //send id of the selected employee to the form
                    frmApproveHoliday z = new frmApproveHoliday(this, y);
                    //show the approval/rejection of holiday request form
                    z.Show();
                }
            }
        }
    }
}
