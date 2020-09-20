using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMovieCategory : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {// Bind Grid
            BindGrid();
        }
    }
    #endregion

    #region Member Methods
    private void BindGrid()
    {
        grid.DataSource = ProductAccess.GetCategory();
        grid.DataBind();
    }

    #endregion

    #region Events

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        string categoryName = ((TextBox)grid.Rows[e.RowIndex].Cells[0].Controls[0]).Text;

        bool success = ProductAccess.UpdateCategory(id, categoryName);
        grid.EditIndex = -1;
        statusLabel.Text = success ? "Update Successful" : "Update Failed";
        BindGrid();
    }

    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.EditIndex = e.NewEditIndex;
        statusLabel.Text = "Editing row # :" + e.NewEditIndex.ToString();
        BindGrid();
    }

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();

        bool success = ProductAccess.DeleteCategory(id);
        grid.EditIndex = -1;
        statusLabel.Text = success ? "Delete Successful" : "Delete Failed";
        BindGrid();

    }

    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid.EditIndex = -1;
        statusLabel.Text = "Editing Canceled";
        BindGrid();
    }

    protected void createCategory_Click(object sender, EventArgs e)
    {
        bool success = ProductAccess.CreateMovieCategory(newName.Text);

        statusLabel.Text = success ? "Insert Successful" : "Insert Failed";
        BindGrid();
    }
    #endregion

}