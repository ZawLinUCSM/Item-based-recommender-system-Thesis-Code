using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;

public partial class AdminAddMovie : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Fill Controls with data
            PopulateControls();

        }
    }
    #endregion

    #region Member Methods
    private void PopulateControls()
    {
        PopulateMovieCategory();
    }

    private void PopulateMovieCategory()
    {
        DataTable categoryListTable = ProductAccess.GetCategory();

        string categoryId, categoryName;

        categoryList.Items.Clear();
        for (int i = 0; i < categoryListTable.Rows.Count; i++)
        {
            // obtain  id and name
            categoryId = categoryListTable.Rows[i]["CategoryID"].ToString();
            categoryName = categoryListTable.Rows[i]["CategoryName"].ToString();

            // Add to category combo box
            // brandList.Items.Add(new ListItem(categoryName, categoryId));
            categoryList.Items.Add(new ListEditItem(categoryName, categoryId));

        }

        categoryList.SelectedIndex = -1;
    }

    private bool ValidateEntry()
    {
        if (categoryList.SelectedItem.Value.ToString() == "")
        {
            statusLabel.Text = "Please Select Category !";
            categoryList.Focus();
            return false;
        }
        return true;
    }

    private void SaveNewProduct()
    {
        if (!ValidateEntry())
        {
            return;
        }

        string categoryID = categoryList.SelectedItem.Value.ToString();
        string name = txtName.Text;
        string genere = txtGenere.Text;
        DateTime duration = teDuration.DateTime;
        DateTime releaseDate = Convert.ToDateTime(dtReleaseDate.Value);
        string language = cboLanguage.SelectedItem.ToString();
        string country = cboCountry.SelectedItem.ToString();
        string cast = txtDirector.Text;
        string description = newDescription.Text.ToString();
        string thumbnail = image1FileUpload.FileName;
        string image = image2FileUpload.FileName;

        bool success = ProductAccess.CreateProduct(categoryID, name, genere, duration, releaseDate, language, country, cast, description, thumbnail, image);

        statusLabel.Text = success ? "Insert Successful" : "Insert Failed";

    }

 
    #endregion

    #region Events

    // upload product's first image
    protected void upload1Button_Click(object sender, EventArgs e)
    {
        // proceed with uploading only if the user selected a file
        if (image1FileUpload.HasFile)
        {
            try
            {
                string fileName = image1FileUpload.FileName;
                string location = Server.MapPath("./ProductImages/") + fileName;

                // save image to server
                image1FileUpload.SaveAs(location);
            }
            catch
            {

                statusLabel.Text = "Uploading image 1 Failed";
            }

        }

    }

    protected void upload2Button_Click(object sender, EventArgs e)
    {
        if (image2FileUpload.HasFile)
        {
            try
            {
                string fileName = image2FileUpload.FileName;
                string location = Server.MapPath("./ProductImages/") + fileName;
                // save to image to server
                image2FileUpload.SaveAs(location);
            }
            catch
            {
                statusLabel.Text = "Uploading image 2 Failed";

            }
        }
    }

    protected void createProduct_Click(object sender, EventArgs e)
    {
        SaveNewProduct();
    }


    #endregion
}