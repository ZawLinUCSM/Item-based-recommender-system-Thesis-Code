using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewPredictionResults : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string productId = Request.QueryString["MovieID"];// Get select movieid.
       
        // Get Movie details with current movieid
        MovieDetailInfo pd = ProductAccess.GetProductDetailsWithProduct(productId);

        if (pd.name != null)
        {
            PopulateControls(pd);
        }
    }
    private void PopulateControls(MovieDetailInfo pd)
    {
        // Display product details 
        productImage.ImageUrl = "ProductImages/" + pd.image;
        lblname.Text = pd.name; lblgenere.Text = pd.genere;
        lblcast.Text = pd.castordirector;
        lbllanguage.Text = pd.language;
        lblcountry.Text = pd.country;
        string varMinutes = pd.duration.ToString("hh:mm");
        string[] hourMinute = varMinutes.Split(':');
        lblduration.Text = hourMinute[0].ToString() + " hour " + hourMinute[1].ToString() + " minutes"; lblreleasedate.Text = pd.releaseDate.ToShortDateString();
        lblcategory.Text = pd.categoryname;
        lbldescription.Text = pd.description;
    }
    protected void backToHome_Click(object sender, EventArgs e)
    {
        // Redirect to Home page.
        Response.Redirect("~/Default.aspx");
    }
}