﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// simple struct that represents a(pagenumber,url) association
public struct PageUrl
{
    private string page;
    private string url;

    // Page and Url property definitions
    public string Page
    {
        get
        {
            return page;
        }
    }

    public string Url
    {
        get
        {
            return url;
        }
    }

    // constructor
    public PageUrl(string page, string url)
    {
        this.page = page;
        this.url = url;
    }

}

/// <summary>
/// Pager control
/// </summary>
public partial class UserControls_Pager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // show the pager
    public void Show(int currentPage, int howManyPages, string firstPageUrl, string pageUrlFormat, bool showPages)
    {
        // make the pager visible
        this.Visible = true;

        // display the current page
        currentPageLabel.Text = currentPage.ToString();
        howManyPagesLabel.Text = howManyPages.ToString();

        // create the previous link
        if (currentPage == 1)
        {
            previousLink.Enabled = false;

        }
        else
        {
            previousLink.NavigateUrl = (currentPage == 2) ? firstPageUrl : string.Format(pageUrlFormat, currentPage - 1);
        }

        // create the Next link
        if (currentPage == howManyPages)
        {
            nextLink.Enabled = false;

        }
        else
        {
            nextLink.NavigateUrl = string.Format(pageUrlFormat, currentPage + 1);
        }

        // create the page links
        if (showPages)
        {
            if (howManyPages>0)
            {
                // the list of pages and their URLs as an array
                PageUrl[] pages = new PageUrl[howManyPages];

                // generate (page,url) elements
                pages[0] = new PageUrl("1", firstPageUrl);

                for (int i = 2; i <= howManyPages; i++)
                {
                    pages[i - 1] = new PageUrl(i.ToString(), string.Format(pageUrlFormat, i));
                }

                // do not generate a link for the current page
                pages[currentPage - 1] = new PageUrl((currentPage).ToString(), "");

                // feed the pages to the repeater
                pagesRepeater.DataSource = pages;
                pagesRepeater.DataBind();
            }
            
        }
    }
}