using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public class Link
{
    #region Constructor
    public Link()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    #region Methods

    // Builds an absolute URL
    private static string BuildAbsolute(string relativeUri)
    {
        // get current uri
        Uri uri = HttpContext.Current.Request.Url;
        // build absolute path
        string app = HttpContext.Current.Request.ApplicationPath;

        if (!app.EndsWith("/"))
        {
            app += "/";

        }
        relativeUri = relativeUri.TrimStart('/');

        // return the absolute Path
        return HttpUtility.UrlPathEncode(string.Format("http://{0}:{1}{2}{3}", uri.Host, uri.Port, app, relativeUri));
    }

    public static string ToProduct(string productId)
    {
        return BuildAbsolute(String.Format("MovieDetails.aspx?ProductID={0}", productId));
    }
    public static string ToProductImage(string fileName)
    {
        //build Product URL
        return BuildAbsolute("/ProductImages/" + fileName);
    }

    public static string ToProductList(string page)
    {
        if (page == "1")
        {
            return BuildAbsolute(string.Format("Default.aspx"));

        }
        else
        {
            return BuildAbsolute(string.Format("Default.aspx?Page={0}", page));
        }
    }
    #endregion
}