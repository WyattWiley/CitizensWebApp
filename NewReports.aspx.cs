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
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Request.QueryString["ProjectID"] == null)
                {
                    Response.Redirect("Institutions.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                int volunteerId;
                using (SqlCommand command = new SqlCommand("EXEC spGetVolunteerID @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);

                    connection.Open();
                    volunteerId = (int)command.ExecuteScalar();
                    connection.Close();
                }

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

                    // Clearing text boxes after success message
                    txtReportDate.Text = "";
                    txtValue.Text = "";
                    txtObservedDate.Text = "";
                    txtNotes.Text = "";
                    txtToolID.Text = "";
                    txtLatitude.Text = "";
                    txtLongitude.Text = "";
                }
            }
        }
    }
}