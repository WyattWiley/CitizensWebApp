using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace CitizensWebApp
{
    public partial class MyReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LoadReports();
                }
            }
        }

        private void LoadReports()
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("EXEC spGetObservationsByVolunteer @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    gvReports.DataSource = reader;
                    gvReports.DataBind();
                    connection.Close();
                }
            }
        }

        protected void gvReports_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the edit index.
            gvReports.EditIndex = e.NewEditIndex;
            // Bind data to the GridView control.
            LoadReports();
        }

        protected void gvReports_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve the row index stored in the CommandArgument property.
            int index = e.RowIndex;

            // Retrieve the ObservationID of the updated row.
            int observationId = (int)gvReports.DataKeys[index].Value;

            // Retrieve the new values from the GridViewUpdateEventArgs
            float value = float.Parse((string)e.NewValues["Value"]);
            DateTime observedDate = DateTime.Parse((string)e.NewValues["ObservedDate"]);
            string notes = (string)e.NewValues["Notes"];
            int toolId = int.Parse((string)e.NewValues["ToolID"]);
            decimal latitude = decimal.Parse((string)e.NewValues["Latitude"]);
            decimal longitude = decimal.Parse((string)e.NewValues["Longitude"]);

            // Define the connection string
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            // Call spUpdateObservation
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("EXEC spUpdateObservation @ObservationID, @Value, @ObservedDate, @Notes, @ToolID, @Latitude, @Longitude", connection))
            {
                command.Parameters.AddWithValue("@ObservationID", observationId);
                command.Parameters.AddWithValue("@Value", value);
                command.Parameters.AddWithValue("@ObservedDate", observedDate);
                command.Parameters.AddWithValue("@Notes", notes);
                command.Parameters.AddWithValue("@ToolID", toolId);
                command.Parameters.AddWithValue("@Latitude", latitude);
                command.Parameters.AddWithValue("@Longitude", longitude);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            // Switch back to normal mode.
            gvReports.EditIndex = -1;

            // Bind data to the GridView control.
            LoadReports();
        }

        protected void gvReports_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the ObservationID of the row being deleted
            int observationId = (int)gvReports.DataKeys[e.RowIndex].Value;

            // Define the connection string
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            // Call spDeleteObservation
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("EXEC spDeleteObservation @ObservationID", connection))
            {
                command.Parameters.AddWithValue("@ObservationID", observationId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            // Refresh the GridView
            LoadReports();
        }

        protected void gvReports_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReports.EditIndex = -1;
            LoadReports();
        }

    }
}