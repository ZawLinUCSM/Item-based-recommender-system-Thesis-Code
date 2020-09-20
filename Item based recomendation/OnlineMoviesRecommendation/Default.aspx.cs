using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        //isFormLoad = true;
        if (!IsPostBack)
        {
            Populatecontrols();
        }

    }

    #endregion

    #region Events
    protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSearchProductList();
    }

    #endregion

    #region Member Methods

    private void Populatecontrols()
    {
        #region First Page Load
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
        #endregion

        #region Load Product Search Info

        PopulateMovieCategory();

        #endregion

        #region Load Popular Product Lists

        //popularLists.DataSource = ProductAccess.GetPopularProductLists();
        //if (ProductAccess .isLogin)
        //{
        //    popularLabel.Text = ProductAccess.recommendTitle;
        //}
        //else
        //{
        //    popularLabel.Text = ProductAccess.title;
        //}

        //popularLists.DataBind();

        #endregion

    }

    private void PopulateMovieCategory()
    {
        DataTable categoryListTable = ProductAccess.GetCategory();

        categoryList.Items.Clear();
        for (int i = 0; i < categoryListTable.Rows.Count; i++)
        {
            // obtain brand id and name
            string categoryId = categoryListTable.Rows[i]["CategoryID"].ToString();
            string categoryName = categoryListTable.Rows[i]["CategoryName"].ToString();

            // Add to brandList combo box
            categoryList.Items.Add(new ListItem(categoryName, categoryId));

        }

        categoryList.SelectedIndex = -1;
    }

    private void LoadSearchProductList()
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

        // Retrieve list of search product to cleint 
        if (!ValidateEntry())
        {
            return;
        }
        //list.DataSource = null;
        list.DataSource = ProductAccess.GetSearchProductList(page, out howManyPages, Convert.ToInt32(categoryList.SelectedValue));
        list.DataBind();


        // have the current page as integer
        int currentPage = Int32.Parse(page);
        firstPageUrl = Link.ToProductList("1");
        pageFormat = Link.ToProductList("{0}");
        // Display pager controls
        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pageFormat, false);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pageFormat, true);
    }

    private bool ValidateEntry()
    {
        if (!string.IsNullOrEmpty(categoryList.SelectedItem.Text))
        {
            return true;
        }
        return false;
    }

    #endregion

}