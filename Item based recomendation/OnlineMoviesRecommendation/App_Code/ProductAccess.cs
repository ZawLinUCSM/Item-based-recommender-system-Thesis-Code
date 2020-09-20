using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;


public struct UserInfo
{
    private string userID;

    public string UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    private string userName;

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }
}

/// <summary>
///  Struct for Product details information
/// </summary>
public struct MovieDetailInfo
{
    public int ProductId;
    public string name;
    public string description;
    public string thumbnail;
    public string image;
    public string genere;
    public string castordirector;
    public string language;
    public string country;
    public DateTime duration;
    public DateTime releaseDate;
    public string categoryname;
}
/// <summary>
/// Summary description for ProductAccess
/// </summary>
public static class ProductAccess
{
    public static bool isLogin;

    public static int IsCount;
    // public int ThresholdValue { get; set; }
    public static int ThresholdValue;

    public static string productId;
    public static string userId;
    public static double predictionResult;
    public static DataTable usersTable { get; set; }
    public static DataTable similarityDataTable { get; set; }
    public static DataTable currentProductRatingTable { get; set; }

    public static DataTable similarUserRatingTable { get; set; }

    public static DataTable activeUserRatingTable { get; set; }

    public static DataTable similarityResultTable { get; set; }

    #region Constructor
    static ProductAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion


    #region Get Methods

    // Retrieve  list of Category.
    public static DataTable GetCategory()
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // set the stored procedure
        comm.CommandText = "GetCategoryLists";

        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static DataTable GetProductLists()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetMovieList";
        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    #endregion

    #region GetProductsOnClientPromo

    public static DataTable GetProductsOnClientPromo(string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetProductsOnClientPromo";
        // Create a parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = OMRConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = OMRConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //execute the stored pro and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

        // Calculate how many pages of products and set out parameter
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());

        howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)OMRConfiguration.ProductsPerPage);

        // return the page of products
        return table;
    }

    #endregion


    #region GetProductDetails

    public static MovieDetailInfo GetProductDetailsWithProduct(string productId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetMovies";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@MovieID";
        param.Value = productId;
        param.DbType = DbType.Int32;

        comm.Parameters.Add(param);

        // Execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

        // Wrap retrieved data into ProductDetails object
        MovieDetailInfo details = new MovieDetailInfo();

        if (table.Rows.Count > 0)
        {
            // Get the first table row
            DataRow row = table.Rows[0];

            // get product details
            details.ProductId = int.Parse(productId);
            details.name = row["Name"].ToString();
            details.categoryname = row["CategoryName"].ToString();
            details.releaseDate = Convert.ToDateTime(row["ReleaseDate"]);
            details.genere = row["Genere"].ToString();
            details.castordirector = row["Cast"].ToString();

            details.duration = Convert.ToDateTime(row["Duration"]);

            details.country = row["Country"].ToString();
            details.language = row["Language"].ToString();

            details.description = row["Description"].ToString();
            details.thumbnail = row["Thumbnail"].ToString();
            details.image = row["Image"].ToString();

        }

        // Return Product Details
        return details;

    }

    public static void SaveSelectMovie(int productId, string userID, int rating)
    {
        // Get a configured DbCommnad object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // Set the stored procedure name
        comm.CommandText = "CreateProductHistory";
        //Create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Rating";
        param.Value = rating;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        try
        {// execute the stored procedure
            int result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
        }

    }

    #endregion


    #region GetProductHistory
    public static DataTable GetMovieListRating(string userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetProductHistoryByUserID";

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    #endregion


    #region Create/Update/Delete Methods

    #region Create Methods
    // insert all attributes 
    public static bool CreateMovieCategory(string modelname)
    {
        // Get a configured DbCommnad object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // Set the stored procedure name
        comm.CommandText = "CreateMovieCategory";
        //Create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryName";
        param.Value = modelname;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        //result will represent the number of changed rows
        int result = -1;
        try
        {// execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {


        }

        // result will be 1 in case of success
        return (result != -1);
    }

    #endregion

    #region Update Methods

    // update Category
    public static bool UpdateCategory(string id, string name)
    {
        // get a configured Dbcommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // Set the stored procedure
        comm.CommandText = "UpdateCategory";

        //Create a paramenter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //Create a paramenter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryName";
        param.Value = name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);

        }
        catch
        {
            // any errors are logged in GenericDataAccess,  ignore them here 

        }

        // result will be 1 in case of success
        return (result != -1);
    }

    public static bool UpdateUser(string id, string name, string email)
    {
        // get a configured Dbcommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateUser";


        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = id;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // Create a Parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);



        // result will represent the number of changed rows
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess,  ignore them here 

        }

        // result will be 1 in case of success
        return (result != -1);


    }

    #endregion

    #region Delete Methods

    // delete brand attribute
    public static bool DeleteBrand(string id)
    {
        // get a configured Dbcommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // Set the stored procedure
        comm.CommandText = "DeleteBrandAttribute";

        //Create a paramenter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@BrandID";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            // execute command
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, ignoer them here

        }
        // result will be 1 in case of success

        return (result != -1);

    }

    // delete Color 
    public static bool DeleteColor(string id)
    {
        // get a configured Dbcommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // Set the stored procedure
        comm.CommandText = "DeleteColor";

        //Create a paramenter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ColorID";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            // execute command
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, ignoer them here

        }
        // result will be 1 in case of success

        return (result != -1);
    }

    // delete Model
    public static bool DeleteModel(string id)
    {
        // get a configured Dbcommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // Set the stored procedure
        comm.CommandText = "DeleteModel";

        //Create a paramenter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ModelID";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            // execute command
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, ignoer them here

        }
        // result will be 1 in case of success

        return (result != -1);
    }

    // delete Type
    public static bool DeleteCategory(string id)
    {
        // get a configured Dbcommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // Set the stored procedure
        comm.CommandText = "DeleteCategory";

        //Create a paramenter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            // execute command
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, ignoer them here

        }
        // result will be 1 in case of success

        return (result != -1);
    }

    // delete Price
    public static bool DeletePrice(string id)
    {
        // get a configured Dbcommand object
        DbCommand comm = GenericDataAccess.CreateCommand();

        // Set the stored procedure
        comm.CommandText = "DeletePrice";

        //Create a paramenter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@PriceID";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            // execute command
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, ignoer them here

        }
        // result will be 1 in case of success

        return (result != -1);
    }

    #endregion

    #endregion


    #region GetUsers

    public static UserInfo GetUser(string userID)
    {
        DataTable table = new DataTable();
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetUser";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        table = GenericDataAccess.ExecuteSelectCommand(comm);
        UserInfo up = new UserInfo();
        foreach (DataRow userRow in table.Rows)
        {
            up.UserName = userRow["UserName"].ToString();
            up.Email = userRow["Email"].ToString();
            up.Password = userRow["Password"].ToString();
        }

        // return User Info
        return up;
    }


    // Retrieve UserID with productID from ProductHistory
    public static DataTable GetUserLists(string id, string userID)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetUserListsWithProduct";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static UserInfo GetUserIdByUserName(string username)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetUserIdByUserName";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserName";
        param.Value = username;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        UserInfo user = new UserInfo();
        if (table.Rows.Count > 0)
        {
            user.UserID = table.Rows[0]["UserId"].ToString();
            user.UserName = table.Rows[0]["UserName"].ToString();
        }

        return user;
    }

    #endregion


    #region LoadProductAttribute

    public static void LoadProductAttribute()
    {
        // Store attribute to OCRConfiguration DataTable 
        // As Column 
        // From the database

        LoadCategory();

    }

    private static DataTable AddProductIDAndUserID(DataTable table)
    {
        table.Columns.Add("UserID");
        table.Columns.Add("ProductID");
        return table;
    }

    private static void LoadCategory()
    {
        DataTable table1 = new DataTable();

        // Add Column ProductID and UserID
        AddProductIDAndUserID(table1);

        // Get data from the database and
        // Store to table as Columns
        DataTable table = GetCategory();

        OMRConfiguration.modelDataTable = new DataTable();
        OMRConfiguration.tuprofileModelTable = new DataTable();
        OMRConfiguration.puProfileModelTable = new DataTable();

        foreach (DataRow tableRow in table.Rows)
        {
            OMRConfiguration.modelDataTable.Columns.Add(tableRow["ModelName"].ToString());
            OMRConfiguration.tuprofileModelTable.Columns.Add(tableRow["ModelName"].ToString());
        }

        // Merge DataTable With table1
        OMRConfiguration.modelDataTable.Merge(table1);
        OMRConfiguration.tuprofileModelTable.Merge(table1);
    }

    #endregion

    #region Search Product Lists

    // Get User Search Product From the database
    public static DataTable GetSearchProductList(string page, out int howManyPages, int category)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetSearchProductLists";

        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = page;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = OMRConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = OMRConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // Create a parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = category;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //execute the stored pro and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

        // Calculate how many pages of products and set out parameter
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());

        howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)OMRConfiguration.ProductsPerPage);

        return table;
    }

    #endregion

    public static bool CreateProduct(string categoryID, string name, string genere, DateTime duration, DateTime releaseDate, string language, string country, string cast, string description, string thumbnail, string image)
    {
        // Get a configured DbCommnad object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // Set the stored procedure name
        comm.CommandText = "CreateMovie";
        //Create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Genere";
        param.Value = genere;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Duration";
        param.Value = duration;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ReleaseDate";
        param.Value = releaseDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Language";
        param.Value = language;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Country";
        param.Value = country;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Cast";
        param.Value = cast;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Description";
        param.Value = description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Thumbnail";
        param.Value = thumbnail;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Image";
        param.Value = image;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        //result will represent the number of changed rows
        int result = -1;
        try
        {// execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {


        }

        // result will be 1 in case of success
        return (result != -1);
    }


    public static DataTable GetSimilarUsersTotalRating(string userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetUserTotalRating";

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable GetMovieListWithPrediction(double prediction)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetMovieListWithPrediction";

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@PredictionValue";
        param.Value = (int)prediction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static void UpdateMovieRating(string productId, string userId, double prediction)
    {
        // Get a configured DbCommnad object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // Set the stored procedure name
        comm.CommandText = "UpdateProductHistory";
        //Create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Rating";
        param.Value = prediction;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        try
        {// execute the stored procedure
            int result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
        }
    }

    public static DataTable GetProductDescriptionAndOthers(string productID)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetProductDescriptionAndOthers";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool UpdateMovie(string movieId, string categoryID, string name, string genere, DateTime duration, DateTime releaseDate, string language, string country, string cast, string description, string thumbnail, string image)
    {
        // Get a configured DbCommnad object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // Set the stored procedure name
        comm.CommandText = "UpdateMovie";
        //Create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@MovieId";
        param.Value = Convert.ToInt32(movieId);
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = Convert.ToInt32(categoryID);
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Genere";
        param.Value = genere;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Duration";
        param.Value = duration;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ReleaseDate";
        param.Value = releaseDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Language";
        param.Value = language;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Country";
        param.Value = country;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Cast";
        param.Value = cast;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Description";
        param.Value = description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Thumbnail";
        param.Value = thumbnail;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Image";
        param.Value = image;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        //result will represent the number of changed rows
        int result = -1;
        try
        {// execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {


        }

        // result will be 1 in case of success
        return (result != -1);
    }
}
