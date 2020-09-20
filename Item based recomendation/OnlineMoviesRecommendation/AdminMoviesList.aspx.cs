using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMoviesList : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page .IsPostBack)
        {
            //string productID = Request.QueryString["ProductID"];
            // Load the products to grid
            BindGrid();
            
        }
    }

    #endregion

    #region Member Methods
    private void BindGrid()
    {
      
        // get a DataTable object containing the products
        grid.DataSource = ProductAccess.GetProductLists();
        grid.DataBind();
    }

    #endregion
}