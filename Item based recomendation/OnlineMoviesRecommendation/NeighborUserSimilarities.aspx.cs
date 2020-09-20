using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NeighborUserSimilarities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Populatecontrols();
            if (grid.Rows.Count < 0)
            {
                computePrediction.Enabled = false;
            }
        }
    }

    private void Populatecontrols()
    {
        grid.DataSource = ProductAccess.similarUserRatingTable;
        grid.DataBind();
    }
    protected void computePrediction_Click(object sender, EventArgs e)
    {
        ProductAccess.currentProductRatingTable = new DataTable();
        CalcualteSimilarity();

        double res = GeneratePrediction();
        ProductAccess.predictionResult = res;
        if (ProductAccess.predictionResult > 0)
        {
            // Save user select movie details to History table in Database
            ProductAccess.UpdateMovieRating(ProductAccess.productId, ProductAccess.userId, ProductAccess.predictionResult);
        }
        else
        {
            double prediction = (-1) * ProductAccess.predictionResult;
            ProductAccess.UpdateMovieRating(ProductAccess.productId, ProductAccess.userId, prediction);
        }
        // Redirect to Results page.
        Response.Redirect("~/PredictionResults.aspx");
    }

    private double GeneratePrediction()
    {
        double total_Similarity = 0.0;
        double activeuserRating = 0;
        // Get sum of rating for each user.
        int ratingTotal_activeUser = Convert.ToInt32(ProductAccess.activeUserRatingTable.Compute("SUM(RatingTotal)", String.Empty));

        // Divide sum with movie list count
        // if userRating >0
        if (ratingTotal_activeUser > 0)
        {
            activeuserRating = ratingTotal_activeUser / ProductAccess.activeUserRatingTable.Rows.Count - 1;
        }

        // Find sum of total rating for neighbors
        double ratingTotal = FindTotalRating();

        // Sum similarity of neighbor users
        if (ProductAccess.similarityResultTable.Rows.Count > 0)
        {
            foreach (DataRow row in ProductAccess.similarityResultTable.Rows)
            {
                total_Similarity += Convert.ToDouble(row["Similarity"]);
            }
        }
        else
        {
            total_Similarity += 0;
        }
        double res=Math.Round(activeuserRating + ratingTotal / total_Similarity);;
        return res;
    }

    private double FindTotalRating()
    {
        double total = 0;
        foreach (DataRow dataRow in ProductAccess.usersTable.Rows)
        {
            DataTable table = new DataTable();
            DataTable similarityTable = new DataTable();

            // Get UserID for each neighbor users.
            string puUserID = dataRow["UserID"].ToString();

            // Get neighbor user movie lists and rating.
            DataTable neighborUserTable = new DataTable();
            neighborUserTable = ProductAccess.GetSimilarUsersTotalRating(puUserID);

            // Get sum of rating for each user.
            int ratingTotal_User = Convert.ToInt32(neighborUserTable.Compute("SUM(RatingTotal)", String.Empty));

            // Divide sum with movie list count
            double activeuserRating = (double)ratingTotal_User / (double)neighborUserTable.Rows.Count - 1;

            // Get current movie from neighbor users
            table = neighborUserTable.Select("MovieID='" + ProductAccess.productId + "'").CopyToDataTable();
            // Get similarity from neighbor users similairties list 
            // and then multiply.

            similarityTable = ProductAccess.similarityResultTable.Select("UserID='" + puUserID + "'").CopyToDataTable();
            if (table.Rows.Count > 0)
            {
                total += (Convert.ToDouble(table.Rows[0]["RatingTotal"]) - activeuserRating) * Convert.ToDouble(similarityTable.Rows[0]["Similarity"]);
            }
            else
            {
                total += 0;
            }

        }
        return total;
    }

    private void CalcualteSimilarity()
    {
        // Get Movie Lists and rating list for active user.
        ProductAccess.activeUserRatingTable = ProductAccess.GetSimilarUsersTotalRating(ProductAccess.userId);

        ProductAccess.similarityResultTable = new DataTable();

        foreach (DataRow dataRow in ProductAccess.usersTable.Rows)
        {
            DataTable table = new DataTable();

            // Get UserID for each neighbor users.
            string puUserID = dataRow["UserID"].ToString();

            // Get neighbor user movie lists and rating.
            DataTable neighborUserTable = new DataTable();
            neighborUserTable = ProductAccess.GetSimilarUsersTotalRating(puUserID);

            // Add neighbor user movielists to calculate prediction.
            ProductAccess.currentProductRatingTable.Merge(neighborUserTable.Select("MovieID='" + ProductAccess.productId + "'").CopyToDataTable());

            // Find similarity 
            double similarValue = FindSimilarity(neighborUserTable, ProductAccess.activeUserRatingTable);

            // Set UserID and Similarity
            table = SetSimilarityTable(puUserID, similarValue);

            // Merge UserID and similarity for neighbor users
            ProductAccess.similarityResultTable.Merge(table);
        }

    }

    // Find Similarity between active user and neighborUser
    private double FindSimilarity(DataTable neighborUserTable, DataTable activeUserTable)
    {
        double avg = 0;
        double square = 0; double similarity = 0;
        DataTable similarMovieTable = new DataTable();

        // Get sum of rating for each user.
        int ratingTotal_activeUser = Convert.ToInt32(activeUserTable.Compute("SUM(RatingTotal)", String.Empty));
        int ratingTotal_neighborUser = Convert.ToInt32(neighborUserTable.Compute("SUM(RatingTotal)", string.Empty));

        // Divide sum with movie list count
        double activeuserRating = ratingTotal_activeUser / activeUserTable.Rows.Count - 1;
        double neighborUserRating = ratingTotal_neighborUser / neighborUserTable.Rows.Count - 1;

        #region ToUse

        //// Create Dictionary to store attributevalue and sum value
        //Dictionary<string, decimal> _attriValue = new Dictionary<string, decimal>();
        //// Compare each Attribute Value and 
        //// sum attribute value of each
        //foreach (DataRow row in similarUsersAttributeTable.Rows)
        //{
        //    int query = (from atr in _attributeTable.AsEnumerable()
        //                 where atr[0].ToString() == row["Name"].ToString()
        //                 select atr).Count();
        //    //DataRow resRow=query as DataRow;
        //    _attriValue.Add(row["Name"].ToString(), query);
        //}

        //// Find Maxium Similarity for Attribute of Dictionary ValueList
        //// and get attribute name and return it.
        //var max = _attriValue.FirstOrDefault(x => x.Value == _attriValue.Values.Max()).Key;

        #endregion

        // get similar movie list with active user and neighbor users
        foreach (DataRow dataRow in activeUserTable.Rows)
        {
            DataTable table = new DataTable();
            string movieID = dataRow["MovieID"].ToString();
            // Check user select product is contain in history table.
            bool isContain = neighborUserTable.AsEnumerable().Any(s => s.Field<Int32>("MovieID") == Convert.ToInt32(movieID));
            if (isContain)
            {
                similarMovieTable.Merge(neighborUserTable.Select("MovieID='" + movieID + "'").CopyToDataTable());
            }

        }
        avg = CalculateAvgerate(similarMovieTable, activeUserTable, activeuserRating, neighborUserRating);

        // Calculate Lower Square value of tuProfile and neighborUserProfile
        square = CalculateSquare(neighborUserTable, activeUserTable, activeuserRating, neighborUserRating);

        // Similarity
        similarity = avg / square;

        return similarity;
    }

    private static DataTable SetSimilarityTable(string puUserID, double similarValue)
    {
        DataTable similarityTable = new DataTable();
        // Create columns
        similarityTable.Columns.Add("UserID");
        similarityTable.Columns.Add("Similarity");
        //create new row
        DataRow row = similarityTable.NewRow();

        row["UserID"] = puUserID;
        row["Similarity"] = similarValue;

        similarityTable.Rows.Add(row);
        // return similarityTable
        return similarityTable;
    }

    private static double CalculateSquare(DataTable neighborUserTable, DataTable activeUserTable, double activeUserRating, double neighborUserRating)
    {
        double _squarevalue = 0.0;

        // Calculate square value of tuProfileTable 
        // by calling CalculateSquareValue()
        double tuSquare = CalculateSquareValue(activeUserTable, activeUserRating);

        // Calculate square value of neighborUserProfile 
        // by calling CalculateSquareValue()
        double puSquare = CalculateSquareValue(neighborUserTable, neighborUserRating);

        // Get Square Value by Sum
        _squarevalue = tuSquare + puSquare;
        return _squarevalue;
    }

    private static double CalculateSquareValue(DataTable userTable, double rating)
    {
        double value = 0.0;
        for (int i = 0; i < userTable.Rows.Count; i++)
        {
            double rowValue = Convert.ToDouble(userTable.Rows[i]["RatingTotal"]) - rating;
            value += Math.Pow(rowValue, 2.0);
        }
        return Math.Sqrt(value);
    }

    private static double CalculateAvgerate(DataTable neighborUserTable, DataTable activeUserTable, double activeUserRating, double neighborUserRating)
    {
        double _sum = 0.0;

        for (int i = 0; i < neighborUserTable.Rows.Count; i++)
        {

            _sum += (Convert.ToDouble(activeUserTable.Rows[i]["RatingTotal"]) - activeUserRating) * (Convert.ToDouble(neighborUserTable.Rows[i]["RatingTotal"]) -
                    neighborUserRating);
        }
        return _sum;
    }

    private static DataTable ChangeRowsToColumns(DataTable neighborUserTable)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Name");
        table.Columns.Add("Weight");


        for (int i = 0; i < neighborUserTable.Columns.Count; i++)
        {
            if (neighborUserTable.Columns[i].ToString() == "UserID")
            {

            }
            else
            {
                DataRow dr = table.NewRow();
                dr["Name"] = neighborUserTable.Columns[i].ToString();
                dr["Weight"] = neighborUserTable.Rows[0][i].ToString();
                table.Rows.Add(dr);
            }

        }
        return table;
    }
}