<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchRecipies.aspx.cs" Inherits="DatabaseProject.SearchRecipies" %>
<asp:Content ID="Content4" ContentPlaceHolderID="SearchRecipiesPageContent" Runat="Server">
    <p>
        <asp:Label ID="Label2" runat="server" Text="Submitted By:  "></asp:Label>   <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="SUBMITTED_BY" DataValueField="SUBMITTED_BY" >
            <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;SUBMITTED_BY&quot; FROM &quot;RECIPES&quot;"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="CATEGORY" DataValueField="CATEGORY">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;CATEGORY&quot; FROM &quot;RECIPES&quot;"></asp:SqlDataSource>
        <br /><br />

        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
    </p>
    
    </asp:Content>
