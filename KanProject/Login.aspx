<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KanProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="scripts/jquery-1.11.1.js"></script>
    <script src="scripts/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="username">Username</label>
            <asp:TextBox runat="server" ID="UserName" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" controltovalidate="username" ID="nameValidator" ErrorMessage="Name is required!"></asp:RequiredFieldValidator>
            <br />
            <label for="password">Password</label>
            <asp:TextBox runat="server" ID="PassWord" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" controltovalidate="password" ID="passwordValidator" ErrorMessage="Password is required!"></asp:RequiredFieldValidator>
            <br />
            <input type="submit" />
            <asp:Panel runat="server" ID="ErrorPanel" Visible="false">
                <p>Username or password not valid</p>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
