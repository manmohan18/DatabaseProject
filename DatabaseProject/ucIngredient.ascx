<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucIngredient.ascx.cs" Inherits="DatabaseProject.ucIngredient" %>
<asp:TextBox ID="Name" runat="server" Width="200px"></asp:TextBox>
<asp:TextBox ID="Quantity" runat="server" Width="200px"></asp:TextBox>
<asp:DropDownList ID="ddlUnit" runat="server" Width="70px">
    <asp:ListItem Selected="True">Kg</asp:ListItem>
    <asp:ListItem>Grams</asp:ListItem>
    <asp:ListItem>Ounce</asp:ListItem>
    <asp:ListItem>Litres</asp:ListItem>
</asp:DropDownList>