<%@ Page Title="Admin Movie Category Page" Language="C#" MasterPageFile="~/OCRAdmin.master" AutoEventWireup="true"
    CodeFile="AdminMovieCategory.aspx.cs" Inherits="AdminMovieCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">System Admin<br />
        Movie Categories</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
        <asp:Label ID="statusLabel" runat="server" CssClass="AdminError"></asp:Label>
    </p>
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID"
        Width="100%" OnRowCancelingEdit="grid_RowCancelingEdit"
        OnRowDeleting="grid_RowDeleting" OnRowEditing="grid_RowEditing"
        OnRowUpdating="grid_RowUpdating">
        <Columns>
            <asp:BoundField DataField="CategoryName" HeaderText="Categories Of Movies" SortExpression="CategoryName" />
            <asp:CommandField ShowCancelButton="False" ShowEditButton="True" />
            <asp:ButtonField CommandName="Delete" Text="Delete" />
        </Columns>
    </asp:GridView>

    <p>
        Create a Movie Category :
    </p>
    <p>
        Movie Category
    </p>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
    <p>
        <asp:Button ID="createCategory" Text="Create Category for Movies" runat="server"
            OnClick="createCategory_Click" />
    </p>
</asp:Content>
