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
    public partial class frmManageEmployee : MaterialForm
    {
        public frmManageEmployee()
        {
            InitializeComponent();
        }

        //when the form loads, populate data grid view to display records of employees in database
        private void frmManageEmployee_Load(object sender, EventArgs e)
        {
            populateDataGrid();
        }

        //populate data grid view
        public void populateDataGrid()
        {
            //using database model
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //get records of employees in the database
                var record = context.Employees.Select(p => new { p.Id, p.name, p.email, p.Role.role_name, p.Department.department_name, p.nid, p.date_joined });
                //show the employee records retrieved in the data grid view
                dgEmployee.DataSource = record.ToList();
                dgEmployee.AutoResizeColumns();
            }
        }

        //close the form
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //send id of the selected employee in the datagrid to the employee record form for updating/deleting
        private void dgEmployee_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView gv = sender as DataGridView;
            if (gv.SelectedRows.Count == 1)
            {
                if (gv.Focused)
                {
                    //get id of the selected employee in the data grid
                    int x = dgEmployee.CurrentCell.RowIndex;
                    int y = (int)dgEmployee.Rows[x].Cells[0].Value;
                    //send id of the selected employee to the form
                    EmployeeAdd z = new EmployeeAdd(this, y);
                    //mark the form for update
                    z.forUpdate();
                    //show the form
                    z.Show();
                }
            }
        }

        //show form for adding employees
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            EmployeeAdd k = new EmployeeAdd(this, null);
            k.Show();
            k.forAdd();
        }
    }
}
