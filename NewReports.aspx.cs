using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CitizensWebApp
{
    public partial class NewReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If the user is authenticated it will open the add observation screen if not it will redirect you to the login screen
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Request.QueryString["ProjectID"] == null)
                {
                    Response.Redirect("Institutions.aspx");
                }
            }

            // Making sure the text boxes are loaded in when screen is displayed
            txtReportDate.Visible = true;
            lblReportDate.Visible = true;

            txtValue.Visible = true;
            lblValue.Visible = true;

            txtObservedDate.Visible = true;
            lblObservedDate.Visible = true;

            txtNotes.Visible = true;
            lblNotes.Visible = true;

            txtToolID.Visible = true;
            lblToolID.Visible = true;

            txtLatitude.Visible = true;
            lblLatitude.Visible = true;

            txtLongitude.Visible = true;
            lblLongitude.Visible = true;

            btnSubmit.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                // Getting the VolunteerID to store the observation connected to the VolunteerID automatically given to the user
                int volunteerId;
                using (SqlCommand command = new SqlCommand("EXEC spGetVolunteerID @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);

                    connection.Open();
                    volunteerId = (int)command.ExecuteScalar();
                    connection.Close();
                }

                // Executing the spAddObservation procedure when the VolunteerID is recognized
                using (SqlCommand command = new SqlCommand("EXEC spAddObservation @ProjectID, @ReportDate, @Value, @ObservedDate, @Notes, @ToolID, @Latitude, @Longitude, @VolunteerID", connection))  // Include @VolunteerID
                {
                    command.Parameters.AddWithValue("@ProjectID", Request.QueryString["ProjectID"]);
                    command.Parameters.AddWithValue("@ReportDate", txtReportDate.Text);
                    command.Parameters.AddWithValue("@Value", txtValue.Text);
                    command.Parameters.AddWithValue("@ObservedDate", txtObservedDate.Text);
                    command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                    command.Parameters.AddWithValue("@ToolID", txtToolID.Text);
                    command.Parameters.AddWithValue("@Latitude", txtLatitude.Text);
                    command.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
                    command.Parameters.AddWithValue("@VolunteerID", volunteerId);  // Include @VolunteerID

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    lblMessage.Text = "Observation added successfully!";

                    // Clearing text boxes and titles after success message
                    txtReportDate.Visible = false;
                    lblReportDate.Visible = false;

                    txtValue.Visible = false;
                    lblValue.Visible = false;

                    txtObservedDate.Visible = false;
                    lblObservedDate.Visible = false;

                    txtNotes.Visible = false;
                    lblNotes.Visible = false;

                    txtToolID.Visible = false;
                    lblToolID.Visible = false;

                    txtLatitude.Visible = false;
                    lblLatitude.Visible = false;

                    txtLongitude.Visible = false;
                    lblLongitude.Visible = false;

                    // Also hiding the submit button
                    btnSubmit.Visible = false;
                }
            }
        }
    }
}