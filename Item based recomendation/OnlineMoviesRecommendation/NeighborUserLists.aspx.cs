using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NeighborUserLists : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //isFormLoad = true;
        if (!IsPostBack)
        {
            Populatecontrols();
            ProductAccess.similarUserRatingTable = new DataTable();
            if (grid.Rows.Count < 0)
            {
                computePCC.Enabled = false;
            }
        }
    }

    private void Populatecontrols()
    {
        grid.DataSource = ProductAccess.usersTable;
        grid.DataBind();
    }
    protected void computePCC_Click(object sender, EventArgs e)
    {
        CalculateSimilarity();
        Response.Redirect("NeighborUserSimilarities.aspx");
    }

    private void CalculateSimilarity()
    {
        if (ProductAccess.usersTable.Rows.Count > 0)
        {
            foreach (DataRow row in ProductAccess.usersTable.Rows)
            {
                string _userID = row["UserID"].ToString();

                //Select MovieList that contains user click history movie with userID
                DataTable table = ProductAccess.GetMovieListRating(_userID);
                ProductAccess.similarUserRatingTable.Merge(table);
            }           
        }
    }
}