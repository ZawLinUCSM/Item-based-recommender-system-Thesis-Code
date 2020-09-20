using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            string userID = Session["UserID"].ToString();

            // Get User Profile With userID
            UserInfo up = ProductAccess.GetUser(userID);
            // Populate Controls
            PopulateControls(up);
        }
    }

    private void PopulateControls(UserInfo up)
    {
       
    }
}
