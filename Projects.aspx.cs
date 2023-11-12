using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CitizensWebApp
{
    public partial class Projects : System.Web.UI.Page
    {
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            string query;

            // Executing the spGetProjects sp and if the query string parameter named RA is given it will execute the sp with that parameter. If it does not have an RA parameter then it will print out all Projects.
            if (Request.QueryString["RA"] != null)
            {
                query = "EXEC spGetProjects @ResearchID";
            }
            else
            {
                query = "EXEC spGetProjects";
            }

            // Creating an Sqlconnection object. If a query string parameter named InstID is given this will add it as a parameter to the SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (Request.QueryString["RA"] != null)
                    {
                        command.Parameters.AddWithValue("@ResearchID", Request.QueryString["RA"]);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // If the page is not being loaded in response to a client postback, set the data source of ProjectsRepeater to the datatable returned by GetDataTable() and bind the data
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProjectsRepeater.DataSource = GetDataTable();
                ProjectsRepeater.DataBind();
            }
        }

    }
}