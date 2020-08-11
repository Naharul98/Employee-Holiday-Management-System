using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin;
using System.Globalization;
using MaterialSkin.Controls;

namespace Holiday_Reservation
{
    public partial class frmBookings : MaterialForm
    {
        public frmBookings()
        {
            InitializeComponent();
        }

        //this method is called when the form loads
        private void frmBookings_Load(object sender, EventArgs e)
        {
            populateCombos(); //pre-populate the dropdowns for filtering by employee
            populateDataGrid(); //populate data grid view with data to show records

        }

        //this method populate data grid view with data to show records
        private void populateDataGrid()
        {
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //getting the holiday requests from the database
                var record = context.HolidayRequests.Select(p => new { p.Employee.Id, p.Employee.name, p.date_from, p.date_to, p.reason, p.Employee.Department.department_name, p.Employee.Role.role_name, p.approval });

                if (cmbEmployeeID.SelectedItem != null)
                {
                    //if filter by employee ID is applied
                    if (cmbEmployeeID.SelectedItem.ToString().Equals("All") == false)
                    {
                        //filter the record
                        record = record.Where(x => x.Id.ToString() == cmbEmployeeID.SelectedItem.ToString());
                    }
                }
                if (cmbEmployeeName.SelectedItem != null)
                {
                    //if filter by employee name is applied
                    if (cmbEmployeeName.SelectedItem.ToString().Equals("All") == false)
                    {
                        //filter the record
                        record = record.Where(y => y.name.Contains(cmbEmployeeName.SelectedItem.ToString()));
                    }
                }
                //display records in data grid view
                dataGridView1.DataSource = record.ToList();
                dataGridView1.AutoResizeColumns();

            }
        }

        //pre-populate the dropdowns for filtering by employee
        private void populateCombos()
        {
            resetComboBoxes();
            //add 'all' record filter in combobox
            cmbEmployeeName.Items.Add("All");
            cmbEmployeeID.Items.Add("All");
            //using db model
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //get employee records from the database
                var employees = context.Employees.Select(p => new { p.Id, p.name }).ToList();
                //add every employee record name and id to filter dropdowns
                foreach (var item in employees)
                {
                    cmbEmployeeName.Items.Add(item.name);
                    cmbEmployeeID.Items.Add(item.Id);
                }

                //pre select the first item in the dropdown
                cmbEmployeeID.SelectedIndex = 0;
                cmbEmployeeName.SelectedIndex = 0;
            }
        }

        //this method clears items and data in dropdowns 
        private void resetComboBoxes()
        {
            cmbEmployeeID.Items.Clear();
            cmbEmployeeID.ResetText();
            cmbEmployeeName.Items.Clear();
            cmbEmployeeName.ResetText();
        }

        //refresh data grid view if new filter applied
        private void cmbEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDataGrid();
        }

        //refresh data grid view if new filter applied
        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDataGrid();
        }
    }
}
