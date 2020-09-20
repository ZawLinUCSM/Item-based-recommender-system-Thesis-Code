using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Web.SessionState;


public partial class Account_Login : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["User"] != null && Session["UserID"] != null)
            {

            }
        }



    }
    #endregion

    #region Member Methods
    protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (Membership.ValidateUser(LoginUser.UserName, LoginUser.Password) == true)
        {
            Session["UserName"] = LoginUser.UserName;
            Session["UserID"] = GetUserIdByUserName(LoginUser.UserName);
            //OCRConfiguration.userID = Session["UserID"].ToString();

            FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, true);
            //ProductAccess.LoadProductAttribute();
            //DataTable historytable = ProductAccess.GetProductHistoryByUserID(Session["UserID"].ToString());
            DataTable historytable = new DataTable();
            //if (historytable.Rows.Count > 0)
            //{
            //    ProductAccess.CreateUserClickData(historytable, Session["UserID"].ToString());
            //    ProductAccess.CreateUserProfile("", Session["UserID"].ToString());//}

        }
        else
        {
            Response.Write("Invalid Login");
        }
    }

    private string GetUserIdByUserName(string username)
    {
        UserInfo user = ProductAccess.GetUserIdByUserName(username);

        string userID = user.UserID;

        return userID;
    }
    #endregion
}