<%@ Page Title="" Language="C#" MasterPageFile="~/KanProject.Master" AutoEventWireup="true" CodeBehind="DataForm.aspx.cs" Inherits="KanProject.DataForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="plhContentMain" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="GridView1"></asp:GridView>
    </div>
    </form>
    <br />
    <br />
    Ajax Example!
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
</asp:Content>


<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="GridView1"></asp:GridView>
    </div>
    </form>
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
</html>--%>
