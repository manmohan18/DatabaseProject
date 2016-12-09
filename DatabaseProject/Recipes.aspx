<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Recipes.aspx.cs" Inherits="DatabaseProject.Recipes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RecipePageContent" Runat="Server">
    <h1>Recipes</h1>
    <asp:Label ID="lblProblem" runat="server"></asp:Label>

     <asp:GridView ID="gvRecipes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvRecipes_SelectedIndexChanged" style="margin-left: 26px" AutoGenerateColumns="False">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="recipe_name" HeaderText="Recipe Name" />
             <asp:BoundField DataField="submitted_by" HeaderText="Submitted By" />
             <asp:BoundField DataField="recipe_description" HeaderText="Description" />
             <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />
         </Columns>
         <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
         <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
         <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
         <SortedAscendingCellStyle BackColor="#FDF5AC" />
         <SortedAscendingHeaderStyle BackColor="#4D0000" />
         <SortedDescendingCellStyle BackColor="#FCF6C0" />
         <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

     <br />
    <br />
    </asp:Content>
