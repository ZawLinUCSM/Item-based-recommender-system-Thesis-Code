using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ProductLists : System.Web.UI.UserControl
{
    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        Populatecontrols();

    }

    #endregion

    private void Populatecontrols()
    {
        // Retrieve Page from the query string 
        string page = Request.QueryString["Page"];

        if (page == null)
        {
            page = "1";

        }
        // How many pages of products
        int howManyPages = 1;
        // pager links format
        string firstPageUrl = "";
        string pageFormat = "";

        // Retrieve list of products on product cleint promo
        list.DataSource = ProductAccess.GetProductsOnClientPromo(page, out howManyPages);
        list.DataBind();

        // have the current page as integer
        int currentPage = Int32.Parse(page);
        firstPageUrl = Link.ToProductList("1");
        pageFormat = Link.ToProductList("{0}");
        // Display pager controls
        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pageFormat, false);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pageFormat, true);
    }
}