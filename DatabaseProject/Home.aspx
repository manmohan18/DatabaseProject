<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DatabaseProject.Home" %>

<asp:Content id="myContent" runat="server"
    ContentPlaceHolderID="HomePageContent">
    
      <h1>Wise Cooks - Home Recipes</h1> 
      <h2>Welcome</h2>
      <p> Wise Cooks - Home recipies provides typical home food recepies  from all over the world. The recipe collection offers you to try  <br /> 
          never eaten items. While promoting traditional and continental foods, site also provides centralized recipe of most of the popular dishes which includes snaks, main couse, desserts and more. Futher you can add your recipe too if it isn't in our site. Navigate from left to explore full website.
      </p>
    <br /><br /><br />
      <p> Except Home Page, you have following options to go through</p>
    <asp:BulletedList ID="homeOptionsDisplay" runat="server" DisplayMode="Text" >
        <asp:ListItem Text="View recipe collection."></asp:ListItem>
        <asp:ListItem Text=" Add new non-existing recipe."></asp:ListItem>
        <asp:ListItem Text=" Search in site."></asp:ListItem>
    </asp:BulletedList>   
</asp:Content>

