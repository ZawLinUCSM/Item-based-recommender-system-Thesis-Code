<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="UserControls/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="Server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<h4 class="labelContent">Choose Movie Category</h4><br />
    <br />
    <asp:Label ID="lblCategory" runat="server" Text="Movie Category:"></asp:Label><br />
    <asp:DropDownList ID="categoryList" runat="server" AutoPostBack="True" Width="200px"
        OnSelectedIndexChanged="categoryList_SelectedIndexChanged" Height="30px">
    </asp:DropDownList>
</asp:Content><asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <uc1:Pager ID="topPager" runat="server" />
    <asp:DataList ID="list" runat="server" RepeatColumns="5">
        <ItemTemplate><a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
                <img width="120px" height="100px" src="<%# Link.ToProductImage(Eval("Thumbnail").ToString()) %>"
                    alt='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>' />
            </a>
            <h3 class="ProductTitle">
                <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
                    <%#HttpUtility .HtmlEncode (Eval("Name").ToString ()) %></a>
            </h3>
            <%-- <%#HttpUtility.HtmlEncode(Eval("Description").ToString ()) %>--%>
        </ItemTemplate>
    </asp:DataList>
    <uc1:Pager ID="bottomPager" runat="server" />
</asp:Content>
