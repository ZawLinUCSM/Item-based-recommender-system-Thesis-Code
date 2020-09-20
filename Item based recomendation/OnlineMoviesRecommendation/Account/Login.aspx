<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>Log In
    </h2>
    <b>Please enter your username and password.</b>
    <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register</asp:HyperLink>
    <b>if you don't have an account.</b>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false"
        RenderOuterTable="false" OnAuthenticate="LoginUser_Authenticate">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="LoginUserValidationGroup" />
            <div>
                <fieldset class="login">
                    <legend>Account Information</legend>
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:CheckBox ID="RememberMe" runat="server" />
                    <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                </fieldset>

                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In"
                    ValidationGroup="LoginUserValidationGroup" />
            </div>
        </LayoutTemplate>
    </asp:Login>

</asp:Content>

