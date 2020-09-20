using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Utilities
/// </summary>
public static class Utilities
{
    #region Contructors

    static Utilities()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #endregion

    #region Methods

    // Generic method for sending emails
    public static void SendMail(string from, string to, string subject, string body)
    {
        // Configure mail Client
        SmtpClient mailClient = new SmtpClient(OMRConfiguration.MailServer);

        //Set credentials(for SMTP Servers that require authentication)
        mailClient.Credentials = new NetworkCredential(OMRConfiguration.MailUserName, OMRConfiguration.MailPassword);

        //Create the mail message
        MailMessage mailMessage = new MailMessage(from, to, subject, body);

        // Send mail
       // mailClient.Send(mailMessage);
    }

    // Send Error Log mail
    public static void LogError(Exception ex)
    {
        // get the current date and time
        string dateTime = DateTime.Now.ToLongDateString() + ", at" + DateTime.Now.ToShortDateString();

        // Stores the error message
        string errorMessage = "Exception generated on " + dateTime;

        // obtain the page thata generated the error
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        errorMessage += "\n\n Message:  " + ex.Message;
        errorMessage += "\n\n Source:   " + ex.Source;
        errorMessage += "\n\n Method :  " + ex.TargetSite;
        errorMessage += "\n\n Stack Tarce: \n\n" + ex.StackTrace;

        // send error email in case the option is activated in web.config
        if (OMRConfiguration.EnableErrorLogEmail)
        {
            string from = OMRConfiguration.MailFrom;
            string to = OMRConfiguration.ErrorLogEmail;
            string subject = "Online Movies Recommendation Error Report";
            string body = errorMessage;
            SendMail(from, to, subject, body);

        }
    }

    #endregion
}