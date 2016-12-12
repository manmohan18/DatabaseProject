<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchRecipies.aspx.cs" Inherits="DatabaseProject.SearchRecipies" %>
<asp:Content ID="Content4" ContentPlaceHolderID="SearchRecipiesPageContent" Runat="Server">
    <p>
        <asp:Label ID="Label2" runat="server" Text="Submitted By:  "></asp:Label>  
        <asp:DropDownList ID="drpDwnUsers" runat="server">
        </asp:DropDownList> 
        <br />
        <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="drpCategory" runat="server" >
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Ingredient"></asp:Label>
        <asp:DropDownList ID="drpIngredient" runat="server"  >
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label runat="server" ID="lblResult"></asp:Label>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
    </p>
    <p>
        <br /><br />

        <asp:GridView ID="searchGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  style="margin-top: 91px" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="recipe_name" HeaderText="Recipe Name" />
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
    </p>    
    
</asp:Content>