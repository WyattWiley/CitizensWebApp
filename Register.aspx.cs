using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CitizensWebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                StatusMessage.Text = string.Format("User {0} was added successfully as a volunteer! You are now able to add, edit, and delete observations to reports!", FullName.Text);

                // Call the stored procedure after the user has been created successfully
                string connectionString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("spAddVolunteer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Assuming FullName.Text is the FullName for the volunteer
                        command.Parameters.Add(new SqlParameter("@FullName", FullName.Text));
                        // Assuming the user's email and contact number are available
                        command.Parameters.Add(new SqlParameter("@Email", Email.Text));
                        command.Parameters.Add(new SqlParameter("@ContactNumber", ContactNumber.Text));

                        SqlParameter outputIdParam = new SqlParameter("@VolunteerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Get the ID of the newly inserted volunteer
                        int volunteerId = (int)outputIdParam.Value;
                    }
                }
            }
            else
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }

}