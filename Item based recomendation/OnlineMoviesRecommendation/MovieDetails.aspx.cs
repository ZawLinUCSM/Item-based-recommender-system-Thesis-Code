using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;

public partial class MovieDetails : System.Web.UI.Page
{

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        ProductAccess.isLogin = true;
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] != null && Session["UserName"] != null)
            {
                ProductAccess.productId = Request.QueryString["ProductID"];// Get User ID 
                ProductAccess.userId = Session["UserID"].ToString();
                //string userID = OCRConfiguration.userID;

                // Get Product details with currentProductID
                MovieDetailInfo pd = ProductAccess.GetProductDetailsWithProduct(ProductAccess.productId);

                if (pd.name != null)
                {
                    PopulateControls(pd);
                }
            }
        }


    }

    #endregion

    #region Member Methods
    private void GetSimilarUsers(int rating)
    {
        // Call the function to store use click data
        if ((!string.IsNullOrEmpty(ProductAccess.productId.ToString())) && (!string.IsNullOrEmpty(ProductAccess.userId)))
        {
            string _loginUserID = ProductAccess.userId;
           
            // Get movie details with productID.
            MovieDetailInfo mv = ProductAccess.GetProductDetailsWithProduct(ProductAccess.productId.ToString());

            // Select history list with current userid.
            DataTable historytable = ProductAccess.GetMovieListRating(ProductAccess.userId);

            // Check user select product is contain in history table.
            bool isContain = historytable.AsEnumerable().Any(s => s.Field<Int32>("MovieID") == Convert.ToInt32(ProductAccess.productId));

            // if the user click product is not contain
            if (!isContain)
            {
                #region movie History သိမ္းမယ္

                // Save user select movie details to History table in Database
                ProductAccess.SaveSelectMovie(mv.ProductId, ProductAccess.userId,rating);

                DataTable loginUserTable = ProductAccess.GetMovieListRating(_loginUserID);

                // Get UserLists with Login user click MovieID
                ProductAccess.usersTable = ProductAccess.GetUserLists(Convert.ToString(mv.ProductId), ProductAccess.userId);

                if (ProductAccess.usersTable.Rows.Count > 0)
                {
                    foreach (DataRow row in ProductAccess.usersTable.Rows)
                    {
                        string _userID = row["UserID"].ToString();
                        //Select ProductTable that contains user click history product with userID
                        DataTable table = ProductAccess.GetMovieListRating(_userID);
                    }

                }

                #endregion
            }
            else
            {
                // Get UserLists with Login user click Movie
                ProductAccess.usersTable = ProductAccess.GetUserLists(Convert.ToString(mv.ProductId), ProductAccess.userId);
            }
        }
    }

    private void PopulateControls(MovieDetailInfo pd)
    {
        // Display product details 
        productImage.ImageUrl = "ProductImages/" + pd.image;
        lblname.Text = pd.name;lblgenere.Text = pd.genere;
        lblcast.Text = pd.castordirector;
        lbllanguage.Text = pd.language;
        lblcountry.Text = pd.country;
        string varMinutes = pd.duration.ToString("hh:mm");
        string []hourMinute = varMinutes.Split(':');
        lblduration.Text = hourMinute[0].ToString() + " hour " + hourMinute[1].ToString() + " minutes";lblreleasedate.Text = pd.releaseDate.ToShortDateString();
        lblcategory.Text = pd.categoryname;
        lbldescription.Text = pd.description;
    }

    #endregion
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        #region not use coding
        switch (cboRating.SelectedIndex)
        {
            case 0:
                GetSimilarUsers(1);
                break;
            case 1:
                GetSimilarUsers(2);
                break;
            case 2:
                GetSimilarUsers(3);
                break;
            case 3:
                GetSimilarUsers(4);
                break;
            case 4:
                GetSimilarUsers(5);
                break;
        }
        #endregion

        // Get Similar users list by the user click movie.
        //GetSimilarUsers();
        Response.Redirect("NeighborUserLists.aspx");
    }
}