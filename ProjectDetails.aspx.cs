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
    public partial class ProjectDetails : System.Web.UI.Page
    {
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            string query;

            // Executing the spProjectDetails sp and if the query string parameter named ProjectID is given it will execute the sp with that parameter
            if (Request.QueryString["ProjectID"] != null)
            {
                query = "EXEC spProjectDetails @ProjectID";
            }
            else
            {
                query = "EXEC spProjectDetails";
            }

            // Creating an Sqlconnection object. If a query string parameter named InstID is given this will add it as a parameter to the SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (Request.QueryString["ProjectID"] != null)
                    {
                        command.Parameters.AddWithValue("@ProjectID", Request.QueryString["ProjectID"]);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            // If a query string parameter named 'ProjectID' is given, you will be redirected to the 'Institutions.aspx' page.
            if (Request.QueryString["ProjectID"] == null)
            {
                Response.Redirect("Institutions.aspx");
            }
            // If the query string parameter named 'ProjectID' is given set the data source of ProjectDetailsRepeater to the datatable returned by GetDataTable() and bind the data
            else
            {
                if (!IsPostBack)
                {
                    ProjectDetailsRepeater.DataSource = GetDataTable();
                    ProjectDetailsRepeater.DataBind();
                }
            }
        }

        protected void btnAddObservation_Click(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("NewReports.aspx?ProjectID=" + Request.QueryString["ProjectID"]);
            }
        }
    }
}