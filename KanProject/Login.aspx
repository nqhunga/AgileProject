<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KanProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="scripts/jquery-1.11.1.js"></script>
    <title></title>
</head>
<body>
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
    <br />
        <br />
        <br />
        <button id="testAjax">AJAX!</button>
        <p id="ajaxContent">
        </p>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#testAjax").click(function () {
                var uri = "api/Test.asmx/HelloWorld";

                $.ajax({
                    type: "POST",
                    url: uri,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response);
                        $("#ajaxContent").html(response.d.Message);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            });
        });
    </script>
</body>
</html>
