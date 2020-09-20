using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_UpdateProfile : System.Web.UI.Page
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
        UserName.Text = up.UserName;
        Email.Text = up.Email;
    }

    protected void updateUser_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            string userID = Session["UserID"].ToString();
            bool result = ProductAccess.UpdateUser(userID, UserName.Text.ToString(), Email.Text.ToString());

            if (result == true)
            {
                Response.Redirect("ChangeProfileSuccess.aspx");
            }
        }

    }
}