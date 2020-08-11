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
    public partial class frmRequestHoliday : MaterialForm
    {
        private string empID;
        public frmRequestHoliday(string id)
        {
            InitializeComponent();
            //set constraint so that request date cannot be earlier than today's date
            dtpFrom.MinDate = DateTime.Now;
            dtpTo.MinDate = DateTime.Now;
            empID = id;

        }

        private void frmRequestHoliday_Load(object sender, EventArgs e)
        {

        }
        //if exit button is clicked, quit the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            //if form data returns no error
            if (validate().Equals(""))
            {
                //get date value user is trying to submit
                var date_from = dtpFrom.Value.ToString("yyyy-MM-dd");
                var date_to = dtpTo.Value.ToString("yyyy-MM-dd");

                String url = String.Format(@"https://localhost:44327/api/requestholiday/AttemptRequest/{0}/{1}/{2}/{3}", date_from, date_to, txtReason.Text, empID);
                using (var client = new HttpClient())
                {
                    //HTTP GET
                    var responseTask = client.GetAsync(url);
                    var result = responseTask.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Request was made successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtReason.Text = "";
                        dtpFrom.Value = DateTime.Now;
                        dtpTo.Value = DateTime.Now;

                    }
                    else
                    {
                        MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else //theres an error in form validation
            {
                //display form validation error in message box
                MessageBox.Show(validate(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //This method checks if form data user is submitting is valid.
        private String validate()
        {
            StringBuilder sb = new StringBuilder("");
            //check if date to is not earlier than date from
            if(dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                sb.Append("Request date from must be earlier than request date to \n");
            }
            //check if reason is empty
            if(txtReason.Text.Equals(""))
            {
                sb.Append("Please give a reason for the request \n");
            }
            return sb.ToString();
        }
    }
}
