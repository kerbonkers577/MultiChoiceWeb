<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="MultiChoiceWeb.StudentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><b><u><asp:Label ID="Label4" runat="server" Text="Sudent Options"></asp:Label></u></b></h1>
    <div id="Head">
        <!-- Head set by student successful login -->
        <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
        <asp:Label ID="txtStdName" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Student Number : "></asp:Label>
        <asp:Label ID="txtStdNum" runat="server" Text=""></asp:Label>
    </div>

    <div id="Body">
        <br />
        <asp:Button ID="btnViewMarks" runat="server" Text="View Marks" OnClick="btnViewMarks_Click" />
        <br />
        <br />
        <asp:ListBox ID="lstTests" runat="server" OnSelectedIndexChanged="lstTests_SelectedIndexChanged" SelectionMode="Single"></asp:ListBox>
        <br />
        <asp:Button ID="btnTestSelect" runat="server" Text="Take Test" OnClick="btnTestSelect_Click" />
        <br />
        <asp:Label ID="lblTestSeelctErr" runat="server" Text="" ForeColor="#ff0000"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" />
    </div>
</asp:Content>
