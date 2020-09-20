<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PopularProductLists.ascx.cs"
    Inherits="UserControls_PopularProductLists" %>
<asp:DataList ID="popularLists" runat="server" RepeatColumns="1">
    <ItemTemplate>
        <h3 class="ProductTitle">
            <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
                <%#HttpUtility .HtmlEncode (Eval("Name").ToString ()) %></a>
        </h3>
        <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
            <img width="150px" height="100px" src="<%# Link.ToProductImage(Eval("Thumbnail").ToString()) %>"
                alt='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>' />
        </a>
        <%#HttpUtility.HtmlEncode(Eval("Description").ToString ()) %>
        <br />
        Price:
        <%#Eval("Price","{0:c}") %>
    </ItemTemplate>
</asp:DataList>
