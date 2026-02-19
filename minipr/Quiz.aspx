<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="minipr.Quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quiz Page</title>
    <script type="text/javascript">
        function checkOptionSelected() {
            var options = document.getElementsByName('<%= rblOptions.UniqueID %>');
            var selected = false;

            for (var i = 0; i < options.length; i++) {
                if (options[i].checked) {
                    selected = true;
                    break;
                }
            }

            if (!selected) {
                alert("Please select an option before proceeding!");
                return false; // prevents postback
            }
            return true; // allows postback
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 42px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            height: 25px;
        }
        body {
            background:
                linear-gradient(
                    rgba(0,0,0,0.35),
                    rgba(0,0,0,0.35)
                ),
                url('PHS/quiz.png');

            background-size: cover;
            background-repeat: no-repeat;
            background-position: center;
            min-height: 100vh;
            margin: 0;
            font-family: Arial;
        }
        .auto-style5 {
            width: 592px;
        }
        .auto-style6 {
            height: 25px;
            width: 592px;
        }
        .auto-style7 {
            height: 26px;
            width: 592px;
        }
        .auto-style8 {
            height: 42px;
            width: 592px;
        }
        .auto-style9 {
            width: 592px;
            height: 27px;
        }
        .auto-style10 {
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblQuestion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;</td>
                <td>
                    <asp:RadioButtonList ID="rblOptions" runat="server">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblchk" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    </td>
                <td class="auto-style10">
                    <asp:Label ID="lblans" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnchk" runat="server" OnClick="btnchk_Click" Text="Check" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClientClick="return checkOptionSelected();" OnClick="btnNext_Click"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
