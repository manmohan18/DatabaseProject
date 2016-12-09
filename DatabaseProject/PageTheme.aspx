<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PageTheme.aspx.cs" Inherits="DatabaseProject.PageTheme" %>
<asp:Content ID="myContent" ContentPlaceHolderID="pgTheme" Runat="Server">
    <h2>Select color scheme</h2>
    <p>
        <asp:RadioButton ID="radLight" runat="server"  Text="Light" GroupName="theme" />
    <br />
        <asp:RadioButton ID="radDark" runat="server" Text="Dark" GroupName="theme" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Set Theme" />
    </p>
</asp:Content>
