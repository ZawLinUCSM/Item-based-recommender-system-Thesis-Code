<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserControls_UserInfo" %>
<table cellspacing="0" border="0" width="200px">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <tr>
                <td class="UserInfoHead">Welcome!
                </td>
            </tr>
            <tr>
                <td class="UserInfoContent">You are not logged in.
                    <asp:LoginStatus ID="LoginStatus1" runat="server" />
                    <%-- <asp:HyperLink runat="server" ID="registerLink" NavigateUrl="~/Register.aspx" Text="Register"
                        ToolTip="Go to the registration page"></asp:HyperLink>--%>
                </td>
            </tr>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrators">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server" FormatString="Hello, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:LoginStatus ID="LoginStatus2" runat="server" />
                            <br />
                            <a href="AdminMovieCategory.aspx">Movie Category</a>
                            <br />
                            <br />
                            <a href="AdminAddMovie.aspx">Add New Movie</a>
                            <br />
                            <a href="AdminMoviesList.aspx">Lists of Movies</a>
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Customers">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server" FormatString="Hello, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:LoginStatus ID="LoginStatus1" runat="server" />
                            <br />
                            <asp:HyperLink runat="server" ID="detailsLink" NavigateUrl="~/CustomerDetails.aspx"
                                Text="Edit Details" ToolTip="Eidt your personal details"></asp:HyperLink>
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</table>
