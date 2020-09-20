<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="UpdateProfile.aspx.cs" Inherits="Account_UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>
        Change User Profile
    </h2>
    Use the form below to change your Profile.
    <br />
    <br />
    <asp:Label ID="lblUserName" runat="server" Text="Name:"></asp:Label>
    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="updateUser" runat="server" Text="Update" Width="61px" OnClick="updateUser_Click" />
    <h3>
        If you want to change your password Click
        <asp:HyperLink ID="changePassword" runat="server" NavigateUrl="Account/ChangePassword.aspx">Change Password</asp:HyperLink>
    </h3>
    <br />
</asp:Content>
