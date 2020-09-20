<%@ Page Title="Admin Product Lists" Language="C#" MasterPageFile="~/OCRAdmin.master" AutoEventWireup="true"
    CodeFile="AdminMoviesList.aspx.cs" Inherits="AdminMoviesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle ">System Admin
        <br />
        Movies List</span>
</asp:Content><asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
        <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
    </p>
    <asp:GridView ID="grid" runat="server" DataKeyNames="ProductID" AutoGenerateColumns="False"
        Width="100%">
        <Columns>
            <asp:ImageField DataImageUrlField="Thumbnail" DataImageUrlFormatString="ProductImages/{0}"
                HeaderText="Movie Image" ReadOnly="True">
            </asp:ImageField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Movie Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate><ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Thumb File" SortExpression="Thumbnail">
                <EditItemTemplate>
                    <asp:TextBox ID="thumbnailTextBox" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image File" SortExpression="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="imageTextBox" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Select" NavigateUrl='<%# "AdminMovieDetails.aspx?ProductID="+Eval("ProductID")%>'
                        ID="HyperLink1"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Select" NavigateUrl='<%# "AdminMovieDetails.aspx?ProductID="+Eval("ProductID")%>'
                        ID="HyperLink1"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
