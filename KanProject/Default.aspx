<%@ Page Title="" Language="C#" MasterPageFile="~/KanProject.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KanProject.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/kanboard.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="plhContentMain" runat="server">
    <table id="kanboard">
        <tr>
            <th>Column 1</th>
            <th>Column 2</th>
            <th>Test</th>
        </tr>
        <tr>
            <td class="column"><div id="myElement">Draggable element</div></td>
            <td class="column"></td>
            <td class="column"></td>
        </tr>
    </table>
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
                placeholder: "draggable-placeholder",
                stop: function (event, ui) {
                    saveBoard();
                }
            });

            //window.setInterval(checkBoard, 10 * 1000);

            function saveBoard() {
                $.ajax({
                    type: "POST",
                    url: "api/Projects.asmx/SaveProject",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response.d.message);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
            function checkBoard() {
                $.ajax({
                    type: "POST",
                    url: "api/Projects.asmx/CheckProject",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response.d.message);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }

            $("#testAjax").click(function () {
                var uri = "api/Test.asmx/HelloWorld";

                $.ajax({
                    type: "POST",
                    url: uri,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response);
                        $("#ajaxContent").html(response.d.message);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            });
        });
    </script>
</asp:Content>
