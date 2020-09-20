using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections;

public partial class PredictionResults : System.Web.UI.Page
{
    ArrayList resultList = new ArrayList();
    List<PredictionMovies> resul = new List<PredictionMovies>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Populatecontrols();
        }
    }

    private void Populatecontrols()
    {
        DataTable table = (from c in ProductAccess.similarUserRatingTable.AsEnumerable()
                           orderby c.Field<int>("Rating") descending
                           select c).CopyToDataTable();
        DataTable table1 = table.Select().CopyToDataTable()
.DefaultView.ToTable(false, "MovieID", "Movies", "Rating");
        ConvertMovies(table1);
        //grid.DataSource = ProductAccess.GetMovieListWithPrediction(ProductAccess.predictionResult);
        grid.DataSource = resul
    .GroupBy(i => i.MovieName)
    .Select(g => g.First())
    .ToList();
        grid.DataBind();
    }

    /// <summary>
    /// Prediction Movies Results
    /// </summary>
    /// <param name="table1">Return Table of Movies</param>
    private void ConvertMovies(DataTable table1)
    {
        int id = 0;
        foreach (DataRow item in table1.Rows)
        {
            // Instance of PredictionMovies
            PredictionMovies pr = new PredictionMovies();
            // Add Movies.
            pr.MovieID = Convert.ToInt32(item["MovieID"]);
            pr.MovieName = item["Movies"].ToString();
            pr.Prediction = Convert.ToInt32(item["Rating"]);
            resul.Add(pr);
            if (id == 30)
            {
                break;
            }
            id++;
        }
    }  
}