<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddRecipes.aspx.cs" Inherits="DatabaseProject.AddRecipes" %>

<%@ Reference Control="~/ucIngredient.ascx" %>
<%@ Register Src="~/ucIngredient.ascx" TagPrefix="uc1" TagName="ucIngredient" %>
<asp:Content ID="Content3" ContentPlaceHolderID="AddRecipiesPageContent" Runat="Server">
    <h2>Add Recipies</h2>
    <p>Enter food name for which you want to add the recipe for :</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Name of Recipe" Width="250"></asp:Label>
    &nbsp;<asp:TextBox ID="txtRecipeName" runat="server" Width ="200"></asp:TextBox>
    <%--&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRecipeName" ErrorMessage="Recipe Name is Required!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
    </p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Submitted By" Width="250px"></asp:Label>
    &nbsp;
        <asp:TextBox ID="txtSubmittedBy" runat="server" style="margin-left: 0px" Width="200px"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubmittedBy" ErrorMessage="Provide Name for this field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
    </p>
    <p>
        <asp:Label ID="Label8" runat="server" Text="Category" Width="250px"></asp:Label>
&nbsp;<asp:DropDownList ID="drpDwnCat" runat="server" Width="200px">
        </asp:DropDownList>
    </p>
    <p>
        Add new Category:&nbsp;
        <asp:TextBox ID="txtNewCat" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="addCategory" runat="server" OnClick="addCategory_Click" Text="Add Category" />
    </p>
    <p>
        <asp:Label ID="Label9" runat="server" Text="Preparing/ Cooking time" Width="250px"></asp:Label>
&nbsp;<asp:TextBox ID="txtCookTime" runat="server" Width="200px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label10" runat="server" Text="Number of Serving" Width="250px"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtServings" runat="server" Width="200px"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtServings" ErrorMessage="Provide a Number here!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
    </p>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Recipe Description" Width="250px"></asp:Label>
    <br/>
        <asp:TextBox ID="txtDescription" runat="server" Width="350px" Rows="5" TextMode="MultiLine" style="margin-left: 250px"></asp:TextBox>
    </p>
    <br /><br />
<p>Ingredient List</p>

    <br /><br />
    Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Quantity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Unit
    <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <uc1:ucIngredient runat="server" ID="ucIngredient1" /><br />     
        <uc1:ucIngredient runat="server" ID="ucIngredient2"  Visible="False"/> <br />  
        <uc1:ucIngredient runat="server" ID="ucIngredient3"  Visible="False"/><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient4"  Visible="False"/><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient5"  Visible="False"/><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient6"  Visible="False"/><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient7"  Visible="False"/><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient8"  Visible="False"/><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient9"  Visible="False"/><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient10" Visible="False" /><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient11" Visible="False" /><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient12" Visible="False" /><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient13" Visible="False" /><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient14" Visible="False" /><br />
        <uc1:ucIngredient runat="server" ID="ucIngredient15" Visible="False" /><br />
        </asp:PlaceHolder>
    
    <asp:Label ID="lblResult" runat="server"></asp:Label>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Add Ingredient" OnClick="addIngredient_Click" />
    <asp:Button ID="Button3" runat="server" Text="Save" OnClick="addRecipeeProceed_Click" style="margin-left: 114px" Width="86px" />
    <asp:Label ID="Label13" runat="server" Text=" "></asp:Label>
    <asp:Button ID="Button4" runat="server" style="margin-left: 119px" Text="Cancel" Width="149px" />
</asp:Content>

