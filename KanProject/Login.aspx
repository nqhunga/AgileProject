<%@ Page Title="" Language="C#" MasterPageFile="~/KanProject.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KanProject.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhContentMain" runat="server">
    <form id="form1" runat="server">
        <div>
            <label for="username">Username</label>
            <asp:TextBox runat="server" ID="username" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" controltovalidate="username" ID="nameValidator" ErrorMessage="Name is required!"></asp:RequiredFieldValidator>
            <br />
            <label for="password">Password</label>
            <asp:TextBox runat="server" ID="password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" controltovalidate="password" ID="passwordValidator" ErrorMessage="Password is required!"></asp:RequiredFieldValidator>
            <br />
            <input type="submit" />
            <asp:Panel runat="server" ID="ErrorPanel" Visible="false">
                <p>Username or password not valid</p>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
