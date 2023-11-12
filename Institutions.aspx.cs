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
    public partial class Institutions : System.Web.UI.Page
    {
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                // Defining the query and executing spInstitutionInformation which will print out the institutions in the CitizensDB
                string query = "EXEC spInstitutionInformation";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
            InstitutionsRepeater.DataSource = GetDataTable();
            InstitutionsRepeater.DataBind();
        }

    }
}