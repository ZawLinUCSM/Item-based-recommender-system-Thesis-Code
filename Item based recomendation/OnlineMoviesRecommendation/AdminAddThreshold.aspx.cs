using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAddThreshold : System.Web.UI.Page
{
    string keyName = @"HKEY_CURRENT_USER\Software\OnlineCar";
    //bool isSave=true;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (isSave)
        //{
        //    object obj = null;
        //    int ThresholdValue=0;

        //    if (Microsoft.Win32.Registry.GetValue(keyName, "ThresholdValue", obj) != null)
        //    {
        //      ThresholdValue= Convert.ToInt32(Microsoft.Win32.Registry.GetValue(keyName, "ThresholdValue", obj));
        //    }
        //    else
        //    {
        //        Microsoft.Win32.Registry.SetValue(keyName, "ThresholdValue", 7, Microsoft.Win32.RegistryValueKind.DWord);
        //    }

        //    txtThresholdValue.Text =ThresholdValue.ToString();
        //    isSave = false;
        //}
        

    }
    protected void saveThreshold_Click(object sender, EventArgs e)
    {

        //isSave = false;
       int ThresholdValue = Convert.ToInt32(txtThresholdValue.Text);

       Microsoft.Win32.Registry.SetValue(keyName, "ThresholdValue", ThresholdValue, Microsoft.Win32.RegistryValueKind.DWord);
        
        txtThresholdValue.Text = string.Empty;

    }
}