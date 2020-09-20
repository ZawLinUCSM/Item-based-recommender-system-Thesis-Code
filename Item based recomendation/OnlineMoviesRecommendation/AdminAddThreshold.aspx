<%@ Page Title="" Language="C#" MasterPageFile="~/OCRAdmin.master" AutoEventWireup="true" CodeFile="AdminAddThreshold.aspx.cs" Inherits="AdminAddThreshold" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
    <p>
  Enter Threshold Value:
  <asp:TextBox ID="txtThresholdValue" runat ="server" >0</asp:TextBox>
  &nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Button ID="saveThreshold" runat="server" Text="Save" 
        onclick="saveThreshold_Click"/>
 </p>
</asp:Content>

