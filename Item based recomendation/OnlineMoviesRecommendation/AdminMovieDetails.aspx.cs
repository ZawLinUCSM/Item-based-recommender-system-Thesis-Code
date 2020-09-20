using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;

public partial class AdminMovieDetails : System.Web.UI.Page
{
    #region Variables

    // store the current product ID;
    string currentProductId;

    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {

        currentProductId = Request.QueryString["ProductID"];
        // fill the controls with data in the initial page loaded
        if (!Page.IsPostBack)
        {
            //Pupulate Controls
            if (currentProductId != null)
            {
                PopulateControls();
            }


        }
    }

    #endregion

    #region Member Methods

    // Populate controls and fill with data from the database
    private void PopulateControls()
    {
        // Get movie details with productID.
        MovieDetailInfo mv = ProductAccess.GetProductDetailsWithProduct(currentProductId);
        txtName.Text = mv.name;
        txtGenere.Text = mv.genere;
        txtDirector.Text = mv.castordirector;

        cboCountry.Value= mv.country;
        cboLanguage.Value = mv.language;

        teDuration.Value = mv.duration;
        dtReleaseDate.Value = mv.releaseDate;

        newDescription.Text = mv.description;

        PopulateMovieCategory(mv.categoryname);
        PopulateDescriptionAndOthers();
    }

    private void PopulateMovieCategory(string category)
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
            categoryList.Items.Add(new ListEditItem(categoryName, categoryId));

        }
        categoryList.SelectedIndex = categoryList.Items.IndexOfText(category);
    }

    private void PopulateDescriptionAndOthers()
    {
        DataTable tableDescription = ProductAccess.GetProductDescriptionAndOthers(currentProductId);
        string desc, thumbnail, image;

        for (int i = 0; i < tableDescription.Rows.Count; i++)
        {
            desc = tableDescription.Rows[i]["Description"].ToString();
            thumbnail = tableDescription.Rows[i]["Thumbnail"].ToString();
            image = tableDescription.Rows[i]["Image"].ToString();

            newDescription.Text = desc;
            Image1Label.Text = thumbnail;
            Image2Label.Text = image;
        }

    }

    #endregion
    protected void createProduct_Click(object sender, EventArgs e)
    {
        UpdateMovie();
    }

    private bool ValidateEntry()
    {
        if (categoryList.Value.ToString() == "")
        {
            statusLabel.Text = "Please Select Movie Category !";
            categoryList.Focus();
            return false;
        }
        return true;
    }

    private void UpdateMovie()
    {
        if (!ValidateEntry())
        {
            return;
        }

        string categoryID = categoryList.Value.ToString();
        string name = txtName.Text;
        string genere = txtGenere.Text;
        DateTime duration = teDuration.DateTime;
        DateTime releaseDate = Convert.ToDateTime(dtReleaseDate.Value);
        string language = cboLanguage.Value.ToString();
        string country = cboCountry.Value.ToString();
        string cast = txtDirector.Text;
        string description = newDescription.Text.ToString();
        string thumbnail = image1FileUpload.FileName;
        string image = image2FileUpload.FileName;

        bool success = ProductAccess.UpdateMovie(currentProductId,categoryID, name, genere, duration, releaseDate, language, country, cast, description, thumbnail, image);

        statusLabel.Text = success ? "Insert Successful" : "Insert Failed";
    }
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
}