using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CitizensWebApp
{
    public partial class Description : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No need to check if the user is authenticated in Page_Load
        }

        protected void btnFeedback_Click(object sender, EventArgs e)
        {
            // Check if the user is authenticated when the feedback button is clicked
            if (!User.Identity.IsAuthenticated)
            {
                // If the user is not authenticated, redirect them to the login page
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // If the user is authenticated, redirect them to the feedback page
                Response.Redirect("~/Feedback.aspx");
            }
        }
    }
}