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
using System.Globalization;

namespace Holiday_Reservation
{
    public partial class frmApproveHoliday : MaterialForm
    {
        frmOutstandingRequests form; //data grid view where data is displayed
        int requestId; //the holiday request ID of the request in context
        public frmApproveHoliday(frmOutstandingRequests x, int y)
        {
            InitializeComponent();

            //instantiate instance variables
            requestId = y;
            form = x;
        }

        //This method is called when form loads
        private void frmApproveHoliday_Load(object sender, EventArgs e)
        {
            populateTextBoxes();//pre-populate the text box with holiday data
        }

        //this method is responsible for populating text boxes in the form with holiday request data in context
        private void populateTextBoxes()
        {
            //using db model
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //retrieving the holiday request data from the database
                var request = context.HolidayRequests.SingleOrDefault(b => b.Id == (int)requestId);
                //if the retrieval is successfull
                if (request != null)
                {
                    //populate text boxes in form with the data retrieved
                    txtRequestID.Text = request.Id.ToString();
                    txtEmployeeID.Text = request.Employee.Id.ToString();
                    txtEmployee.Text = request.Employee.name.ToString();
                    txtDepartment.Text = request.Employee.Department.department_name.ToString();
                    txtRole.Text = request.Employee.Role.role_name.ToString();
                    txtDateFrom.Text = request.date_from.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    txtDateTo.Text = request.date_to.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    txtReason.Text = request.reason.ToString();

                }
            }
        }

        //close the form if cancel clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //this method approves the holiday request in context
        private void btnApprove_Click(object sender, EventArgs e)
        {
            //show messagebox asking for cofirmation
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to approve this holiday Request?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if yes is selected in confirmation
            if (dialogResult == DialogResult.Yes)
            {
                using (holiday_dbEntities context = new holiday_dbEntities())
                {
                    //get the holiday request record to approve
                    var requestToUpdate = context.HolidayRequests.SingleOrDefault(b => b.Id == (int)requestId);
                        if (requestToUpdate != null)
                        {
                            //approve the request and save changes in database
                            requestToUpdate.approval = true;
                            context.SaveChanges();
                            form.populateDataGrid();
                            this.Close();
                        }
                }
            }
        }

        //this method rejects the holiday request in context
        private void btnReject_Click(object sender, EventArgs e)
        {
            //show messagebox asking for cofirmation
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reject this holiday Request?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if yes is selected in confirmation
            if (dialogResult == DialogResult.Yes)
            {
                //using db model
                using (holiday_dbEntities context = new holiday_dbEntities())
                {
                    //get the holiday request record to reject
                    var requestToUpdate = context.HolidayRequests.SingleOrDefault(b => b.Id == (int)requestId);
                    if (requestToUpdate != null)
                    {
                        //reject the request and save changes in database
                        requestToUpdate.approval = false;
                        context.SaveChanges();
                        form.populateDataGrid();
                        this.Close();
                    }
                }
            }
        }
    }
}
