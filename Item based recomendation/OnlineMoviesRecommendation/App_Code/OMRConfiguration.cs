using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
/// <summary>
/// Summary description for OCRConfiguration
/// </summary>
public static class OMRConfiguration
{
    #region Variables

    // Caches the connection string
    private static string dbConnectionString;

    //Caches the data provider name 
    private static string dbProviderName;

    //Stre the number of products per page
    private readonly static int productsPerPage;

    //Store the product description length for products lists
    private readonly static int productDescriptionLength;

    // Store the name of your Site
    private readonly static string siteName;

    // To Control profileTables are empty or for first time 
    public static bool brandflag;
    public static bool materialflag;
    public static bool modelflag;
    public static bool typeflag;
    public static bool priceflag;
    public static bool colorflag;
    public static bool widthflag;
    public static bool heightflag;
    public static bool depthflag;
    public static bool weightflag;
    public static int rowCount = 0;

    #region DataTable
    #region Neighbor's User Products & Products from DB
    public static DataTable neighbor;
    #endregion
    // Attribute Table To Store User Click Product
    #region Attribute Table
    public static DataTable brandDataTable;
    public static DataTable depthDataTable;
    public static DataTable modelDataTable;
    public static DataTable typeDataTable;
    public static DataTable priceDataTable;
    public static DataTable colorDataTable;
    public static DataTable fuelDataTable;
    public static DataTable heightDataTable;
    public static DataTable widthDataTable;
    public static DataTable weightDataTable;
    public static DataTable materialDataTable;
    public static DataTable seatDataTable;
    public static DataTable userDataTable;
    #endregion

    // target user profile table
    #region target user profile table

    public static DataTable tuprofileBrandTable;
    public static DataTable tuprofileDepthTable;
    public static DataTable tuprofileModelTable;
    public static DataTable tuprofileTypeTable;
    public static DataTable tuprofilePriceTable;
    public static DataTable tuprofileColorTable;
    public static DataTable tuprofileFuelTable;
    public static DataTable tuprofileHeightTable;
    public static DataTable tuprofileWidthTable;
    public static DataTable tuprofileWeightTable;
    public static DataTable tuprofileMaterialTable;
    public static DataTable tuprofileSeatDataTable;

    #endregion

    // neighbor users profile table
    #region neighbor users profile table
    public static DataTable puProfileBrandTable;
    public static DataTable puProfileDepthTable;
    public static DataTable puProfileModelTable;
    public static DataTable puProfileTypeTable;
    public static DataTable puProfilePriceTable;
    public static DataTable puProfileColorTable;
    public static DataTable puProfileFuelTable;
    public static DataTable puProfileHeightTable;
    public static DataTable puProfileWidthTable;
    public static DataTable puProfileWeightTable;
    public static DataTable puProfileMaterialTable;
    public static DataTable puProfileSeatDataTable;

    #endregion

    #endregion

    #endregion


    #region Properties

    public static int ProductsPerPage
    {
        get { return OMRConfiguration.productsPerPage; }
    }

    public static int ProductDescriptionLength
    {
        get { return OMRConfiguration.productDescriptionLength; }
    }


    public static string SiteName
    {
        get { return OMRConfiguration.siteName; }
    }

    // return the connection string for the OnlineCarDB database
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }

    // Returns the address of the mail server
    public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    // Returns the email UserName
    public static string MailUserName
    {
        get
        {
            return ConfigurationManager.AppSettings["MailUserName"];
        }
    }

    // Returns the email passowrd
    public static string MailPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["MailPassword"];
        }
    }

    // Returns the mail From
    public static string MailFrom
    {
        get
        {
            return ConfigurationManager.AppSettings["MailFrom"];
        }
    }

    // Send error log emails?
    public static bool EnableErrorLogEmail
    {
        get
        {
            return bool.Parse(ConfigurationManager.AppSettings["EnableErrorLogEmail"]);
        }
    }

    // Returns the email address where to send error reports
    public static string ErrorLogEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ErrorLogEmail"];
        }
    }

    #endregion


    #region Constructor

    static OMRConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["OCRConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["OCRConnection"].ProviderName;
        productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
        productDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings["ProductDescriptionLength"]);
        siteName = ConfigurationManager.AppSettings["SiteName"];
    }

    #endregion

}