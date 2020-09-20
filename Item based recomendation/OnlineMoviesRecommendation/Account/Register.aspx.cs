using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        MembershipCreateStatus p = MembershipCreateStatus.Success;
        Membership.CreateUser(RegisterUser.UserName, RegisterUser.Password, RegisterUser.Email, RegisterUser.Question, RegisterUser.Answer, true, out p);
    }
    protected void RegisterUser_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}