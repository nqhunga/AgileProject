<%@ Page Title="" Language="C#" MasterPageFile="~/KanProject.Master" AutoEventWireup="true" CodeBehind="DataForm.aspx.cs" Inherits="KanProject.DataForm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="plhContentMain" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="GridView1"></asp:GridView>
    </div>
    </form>
</asp:Content>
