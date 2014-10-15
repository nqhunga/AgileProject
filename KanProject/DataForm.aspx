<%@ Page Title="" Language="C#" MasterPageFile="~/KanProject.Master" AutoEventWireup="true" CodeBehind="DataForm.aspx.cs" Inherits="KanProject.DataForm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        #kanboard {
            border-collapse: collapse;
            width: 100%;
            min-height: 200px;
        }
        .draggable-placeholder {
            border: 2px dashed #000;
            background: #fafafa;
            height: 70px;
            margin-bottom: 10px;
        }
        #kanboard, #kanboard th, #kanboard td {
            border: 1px solid black;
        }
        #kanboard th{
            text-align: left;
        }
        #kanboard td{
         width: 33%;   
        }
        #myElement{
            position: relative;
            margin-right: 5px;
            margin-bottom: 10px;
            border: 1px solid #000;
            padding: 5px;
            font-size: 95%;
            height: 65px;
            width: 90%;
        }
    </style>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="plhContentMain" runat="server">
    <table id="kanboard">
        <tr>
            <th>Column 1</th>
            <th>Column 2</th>
            <th>Column 3</th>
        </tr>
        <tr>
            <td class="column"><div id="myElement">Draggable element</div></td>
            <td class="column"></td>
            <td class="column"></td>
        </tr>
    </table>

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
            $(".column").sortable({
                distance: 5,
                connectWith: ".column",
                placeholder: "draggable-placeholder"
            });

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
