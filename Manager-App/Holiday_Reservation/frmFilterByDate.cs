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
    public partial class frmFilterByDate : MaterialForm
    {
        public frmFilterByDate()
        {
            InitializeComponent();
        }

        private void frmFilterByDate_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        //refreshes data and populates data grid view showing which employees are on holiday and which are not
        private void refreshData()
        {
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //get list of employees in database who are on holiday at the date selected
                var onHoliday = context.HolidayRequests.Select(p => new { p.Employee.Id, p.Employee.name, p.Employee.Department.department_name, p.Employee.Role.role_name, p.approval, p.date_from, p.date_to }).Where(x => x.approval == true).Where(x => (dtpDateFilter.Value.Date >= x.date_from && dtpDateFilter.Value.Date <= x.date_to));
                ////get only the id of the employees on holiday at the selected date
                var employeesOnHoliday = onHoliday.Select(p => new { p.Id }).ToList();
                var employeeIdsOnHoliday = new List<int>();

                //add ids of employees on holiday in the list
                foreach (var item in employeesOnHoliday)
                {
                    int k = item.Id;
                    employeeIdsOnHoliday.Add(k);
                }

                //get employees who are not on holiday from the database
                var working = context.Employees.Where(p => !employeeIdsOnHoliday.Contains(p.Id)).Select(p => new { p.Id, p.name, p.Department.department_name, p.Role.role_name });

                //get only specific columns of employees for displaying in the data grid view
                var toDisplay = onHoliday.Select(p => new { p.Id, p.name, p.role_name, p.department_name, p.date_from, p.date_to });

                //populate data grid with list of employees on holiday
                dgOnHoliday.DataSource = toDisplay.ToList();
                dgOnHoliday.AutoResizeColumns();
                //populate data grid with list of employees working
                dgWorkingEmployee.DataSource = working.ToList();
                dgWorkingEmployee.AutoResizeColumns();

            }
        }

        //close the form
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //refresh data if new date is selected
        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
