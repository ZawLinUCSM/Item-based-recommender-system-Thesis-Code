using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // get Controls
        TextBox usernameTextBox = (TextBox)loginControl.FindControl("UserName");

        // set focus on the usename text box when the page loads
        usernameTextBox.Focus();

        // set page title
        this.Title = OMRConfiguration.SiteName + ":  Login";
    }
}