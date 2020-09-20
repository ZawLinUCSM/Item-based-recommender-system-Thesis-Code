<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductLists.ascx.cs"
    Inherits="UserControls_ProductLists" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<uc1:Pager ID="topPager" runat="server" />
<asp:DataList ID="list" runat="server" RepeatColumns="2">
    <ItemTemplate>
        <h3 class="ProductTitle">
            <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
                <%#HttpUtility .HtmlEncode (Eval("Name").ToString ()) %></a>
        </h3>
        <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
            <img width="200px" height="100px" src="<%# Link.ToProductImage(Eval("Thumbnail").ToString()) %>"
                alt='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>' />
        </a>
        <%#HttpUtility.HtmlEncode(Eval("Description").ToString ()) %>
        <br />
        <br />
        Price:
               <%#Eval("Price","{0:c}") %>
    </ItemTemplate>
</asp:DataList>
<uc1:Pager ID="bottomPager" runat="server" Visible="False" />
