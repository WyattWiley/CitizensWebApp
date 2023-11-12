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
    public partial class ResearchAreas : System.Web.UI.Page
    {
        public DataTable GetDataTable()
        {
            // Getting data from the CitizensDB, creating a new DataTable object, and getting the connection string from the configuration file.
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            string query;

            // Executing the spGetResearchInformation sp and if the query string parameter named InstID is given it will execute the sp with that parameter
            if (Request.QueryString["InstID"] != null)
            {
                query = "EXEC spGetResearchAreaInformation @InstitutionID";
            }
            else
            {
                query = "EXEC spGetResearchAreaInformation";
            }

            // Creating an Sqlconnection object. If a query string parameter named InstID is given this will add it as a parameter to the SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (Request.QueryString["InstID"] != null)
                    {
                        command.Parameters.AddWithValue("@InstitutionID", Request.QueryString["InstID"]);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // If the page is not being loaded in response to a client postback, set the data source of ResearchAreasRepeater to the datatable returned by GetDataTable() and bind the data
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResearchAreasRepeater.DataSource = GetDataTable();
                ResearchAreasRepeater.DataBind();
            }
        }
    
    }
}