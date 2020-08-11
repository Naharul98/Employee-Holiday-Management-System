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
    public partial class EmployeeAdd : MaterialForm
    {

        private int? employeeID; //the id of the employee whose records we are showing
        private frmManageEmployee form; //the form with the employee data grid view
        public EmployeeAdd(frmManageEmployee x, int? y)
        {
            InitializeComponent();
            //configure date picker so that a date in the future cannot be selected
            dtpJoiningDate.MaxDate = DateTime.Now;
            
            form = x;//assign 'form' instance variables
            employeeID = y;//assign 'employeeID' instance variable instance variables

            populateComboBoxes(); //pre-populates combobox data for department and role
        }

        //this method is called when form loads initially
        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            //checking if form is for updating record of adding
            if (employeeID != null)
            {
                //pre-populate employee data in text boxes for updating
                populateTextBoxes();
                //marking days employee has booked leave in calender
                highlightBookedDaysInCalender();
            }
        }

        //this method marks days employee has booked leave in calender as bold
        private void highlightBookedDaysInCalender()
        {
            //using the database model
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //get holiday records which has been booked by the employee and approved/confirmed
                var holidaysBookedByEmployee = context.HolidayRequests.Where(b => b.employee_id == (int)employeeID).Where(b => b.approval == true).Select(p => new { p.date_from, p.date_to }).ToList();
                //if we find a record from the previous line
                if (holidaysBookedByEmployee != null)
                {
                    //creates list of dates to make bold
                    var datesToMakeBold = new List<DateTime>();
                    //add dates to make bold in the list created in the previousline
                    foreach (var item in holidaysBookedByEmployee)
                    {
                        for (var dt = item.date_from; dt <= item.date_to; dt = dt.AddDays(1))
                        {
                            datesToMakeBold.Add(dt);
                        }
                    }
                    //sets which dates to mark as bold in the calender
                    monthCalendar.BoldedDates = datesToMakeBold.ToArray();
                    //updates calender to mark days in bold
                    monthCalendar.UpdateBoldedDates();
                }
            }
        }

        //this method pre-populates data in textboxes when updating employee
        private void populateTextBoxes()
        {
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //gets employee record from the database
                var emp = context.Employees.SingleOrDefault(b => b.Id == (int)employeeID);
                //if an employee record is found
                if (emp != null)
                {
                    //updates form text boxes according to employee record found
                    txtName.Text = emp.name;
                    txtEmail.Text = emp.email;
                    txtNID.Text = emp.nid;
                    richTextBoxPhone.Text = emp.phone;
                    txtPassword.Text = emp.password;
                    cmbDepartment.Text = emp.Department.department_name;
                    cmbRole.Text = emp.Role.role_name;
                    dtpJoiningDate.Value = emp.date_joined;
                }
            }
        }

        //if form is for adding, makes update and delete buttons invisible
        //and create button visible
        public void forAdd()
        {
            btnCreate.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }
        //if form is for updates, makes update and delete buttons visible
        //and create button invisible
        public void forUpdate()
        {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCreate.Visible = false;
        }

        //this method handles logic for creating employee
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if form validation returns no error
            if(validateFormData() == "" && validateInsertion() == "")
            {
                //using the database model
                using (holiday_dbEntities context = new holiday_dbEntities())
                {
                    //create employee record to add to the database
                    //using content of textboses in the form
                    Employee employee = new Employee
                    {
                        name = txtName.Text,
                        email = txtEmail.Text,
                        password = txtPassword.Text,
                        nid = txtNID.Text,
                        date_joined = dtpJoiningDate.Value.Date,
                        role_id = context.Roles.FirstOrDefault(s => s.role_name == cmbRole.Text).Id,
                        department_id = context.Departments.FirstOrDefault(s => s.department_name == cmbDepartment.Text).Id,

                    };
                    //add employee record to database
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    //refresh data grid view showing employees
                    form.populateDataGrid();
                    this.Close();
                }

            }
            else //theres an error in form validation
            {
                //display form validation error in message box
                MessageBox.Show(validateFormData() + validateInsertion(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //This method implements constraint checking for inserting employee so 
        //there is always one head in a department
        private String validateInsertion()
        {
            StringBuilder sb = new StringBuilder(""); //instantiate an string builder
            //if employee we are adding is head or deputy head, we have to check
            //constraint so that no more than 1 head can be in one department
            if(cmbRole.Text == "Head" || cmbRole.Text == "Deputy Head")
            {
                //using database
                using (holiday_dbEntities context = new holiday_dbEntities())
                {
                    //if email entered in text box is not valid, build error message
                    if (context.Employees.Where((emp => emp.email == txtEmail.Text)).Count() > 0) { sb.Append("An employee with this email already exists \n"); }
                    //getting the number of employees already in the department who are head
                    var headCount = context.Employees.Where(emp => emp.Department.department_name == cmbDepartment.Text).Where(emp => emp.Role.role_name == cmbRole.Text).Count();

                    //if constraint is broken, then build error message
                    if(headCount >=1) { sb.Append("This department already has an employee who has the role " + cmbRole.Text + ". A department can only have one employee with role:" + cmbRole.Text); }
                }
                
            }
            //return error message built
            return sb.ToString();

        }

        //This method implements constraint checking for updating employee so 
        //there is always one head in a department
        private String validateUpdate(Employee em)
        {
            StringBuilder sb = new StringBuilder(""); //instantiate an string builder
            //if we are updating employee to a different role than before
            if (em.Role.role_name != cmbRole.Text || em.Department.department_name != cmbDepartment.Text)
            {
                //if email is updated
                if (em.email != txtEmail.Text)
                {
                    //if email entered in text box is not valid, build error message
                    if (txtEmail.Text.Equals("") || IsValidEmail(txtEmail.Text) == false) { sb.Append("Email field is empty or format is invalid \n"); }
                }
                //if employee we are adding is head or deputy head, we have to check
                //constraint so that no more than 1 head can be in one department
                if (cmbRole.Text == "Head" || cmbRole.Text == "Deputy Head")
                {
                    //using database model
                    using (holiday_dbEntities context = new holiday_dbEntities())
                    {
                        //if email entered in text box is not valid, build error message
                        if (context.Employees.Where((emp => emp.email == txtEmail.Text)).Count() > 0) { sb.Append("An employee with this email already exists \n"); }

                        //getting the number of employees already in the department who are head
                        var headCount = context.Employees.Where(emp => emp.Department.department_name == cmbDepartment.Text).Where(emp => emp.Role.role_name == cmbRole.Text).Count();
                        //if constraint is broken, then build error message
                        if (headCount >= 1) { sb.Append("This department already has an employee who has the role " + cmbRole.Text + ". A department can only have one employee with role:" + cmbRole.Text); }
                    }

                }
                
            }
            //return error message built
            return sb.ToString();

        }

        //this method is responsible for validating and making sure data input in form is not empty or is correct
        private String validateFormData()
        {
            StringBuilder sb = new StringBuilder(""); //instantiate an string builder to record error messages
            //check if employee name is not empty
            if (txtName.Text.Equals("")){ sb.Append("Employee name field is empty \n");}
            //check if employee email is not empty
            if (txtEmail.Text.Equals("") || IsValidEmail(txtEmail.Text) == false){ sb.Append("Email field is empty or format is invalid \n");}
            //check if employee password is not empty
            if (txtPassword.Text.Equals("")){ sb.Append("Password Field is Empty \n");}
            //check if employee NIN is not empty
            if (txtNID.Text.Equals("")){ sb.Append("National insurance number field is empty \n");}
            //check phone number entered
            if (richTextBoxPhone.Text.Equals("")) { sb.Append("Please enter phone number \n"); }
            //return error messages if any
            return sb.ToString();
        }

        //this method is responsible for validating and making sure data input in form is not empty or is correct
        private String validateFormDataUpdate()
        {
            StringBuilder sb = new StringBuilder("");//instantiate an string builder to record error messages
            //check if employee name is not empty
            if (txtName.Text.Equals("")) { sb.Append("Employee name field is empty \n"); }
            //check if employee password is not empty
            if (txtPassword.Text.Equals("")) { sb.Append("Password Field is Empty \n"); }
            //check if employee NIN is not empty
            if (txtNID.Text.Equals("")) { sb.Append("National insurance number field is empty \n"); }
            //check phone number entered
            if (richTextBoxPhone.Text.Equals("")) { sb.Append("Please enter phone number \n"); }
            //return error messages if any
            return sb.ToString();
        }

        //checks if email address entered is of a valid format. Returns true if it is, else returns false
        private bool IsValidEmail(string email)
        {
            try{var addr = new System.Net.Mail.MailAddress(email);return addr.Address == email;}
            catch{return false;}
        }

        //this method populates dropdowns in the form with 
        //list of department and roles available
        private void populateComboBoxes()
        {
            //using db model
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //get records of all departments from database
                var departmentRecords = context.Departments.Select(p => new { p.department_name });
                //add department records to department dropdown
                cmbDepartment.DataSource = departmentRecords.ToList();
                cmbDepartment.DisplayMember = "department_name";

                //get records of all roles from database
                var roleRecords = context.Roles.Select(p => new { p.role_name });
                //add department records to role dropdown
                cmbRole.DataSource = roleRecords.ToList();
                cmbRole.DisplayMember = "role_name";
            }
        }

        //this method is responsible for deleting employee record from database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //show message box to confirm deleting
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //if yes selected for confirmation
            if (dialogResult == DialogResult.Yes)
            {
                using (holiday_dbEntities context = new holiday_dbEntities())
                {
                    //get employee record in database to remove
                    var empToRemove = context.Employees.SingleOrDefault(x => x.Id == (int)employeeID);
                    //remove employee in database
                    context.Employees.Remove(empToRemove);
                    context.SaveChanges();
                }
                //refresh data grid view
                form.populateDataGrid();
                this.Close();
            }

        }

        //this method is responsible for updating employee record from database
        private void btnUpdate_Click(object sender, EventArgs e)
        {

                using (holiday_dbEntities context = new holiday_dbEntities())
                {
                //get employee record in database, which is to be updated
                var empToUpdate = context.Employees.SingleOrDefault(b => b.Id == (int)employeeID);

                //validate form and check constraint to ensure they are not broken
                if (validateFormDataUpdate() == "" && validateUpdate(empToUpdate) == "")
                  {
                    //if we get the employee from the database successfully
                    if (empToUpdate != null)
                    {
                        //update the record of the employee from the data in the form text boxes
                        empToUpdate.name = txtName.Text;
                        empToUpdate.email = txtEmail.Text;
                        empToUpdate.nid = txtNID.Text;
                        empToUpdate.date_joined = dtpJoiningDate.Value.Date;
                        empToUpdate.role_id = context.Roles.FirstOrDefault(s => s.role_name == cmbRole.Text).Id;
                        empToUpdate.department_id = context.Departments.FirstOrDefault(s => s.department_name == cmbDepartment.Text).Id;
                        empToUpdate.phone = richTextBoxPhone.Text;
                        //save changes in database
                        context.SaveChanges();
                        form.populateDataGrid();
                        this.Close();
                    }
                  }
                else
                {
                    MessageBox.Show(validateFormDataUpdate() + validateUpdate(empToUpdate), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void richTextBoxPhone_TextChanged(object sender, EventArgs e)
        {
            var numberOfCharacters = richTextBoxPhone.Text.Length;
            if(numberOfCharacters<=11)
            {
                richTextBoxPhone.ForeColor = Color.Black;
            }
            else
            {
                richTextBoxPhone.ForeColor = Color.DarkRed;
            }

        }

        private void richTextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
