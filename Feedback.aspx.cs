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
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                // Getting the VolunteerID to store the feedback connected to the VolunteerID automatically given to the user
                int volunteerId;
                using (SqlCommand command = new SqlCommand("EXEC spGetVolunteerID @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);

                    connection.Open();
                    volunteerId = (int)command.ExecuteScalar();
                    connection.Close();
                }

                // Get the feedback text entered by the user
                string feedbackText = txtFeedback.Text;

                // Executing the spAddFeedback procedure when the VolunteerID is recognized
                using (SqlCommand command = new SqlCommand("EXEC spAddFeedback @VolunteerID, @FeedbackText", connection))
                {
                    command.Parameters.AddWithValue("@VolunteerID", volunteerId);
                    command.Parameters.AddWithValue("@FeedbackText", feedbackText);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // Show a success message
                lblMessage.Text = "Thank you for your feedback! Your feedback is appreciated and will be reviewed! If you have another suggestion or more feedback enter another submission and submityour feedback. If not feel free to explore our website!";
                lblMessage.Visible = true;

                // Clear the feedback text box
                txtFeedback.Text = string.Empty;
            }
        }
    }
}