<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vote_page.aspx.cs" Inherits="Testing.vote_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/vote_page.css" rel="stylesheet" />



</head>
<body>
    <form runat="server">
    <table class="rwd-table" align="center" >
        <tr>
            <td>1.</td>
            <td><img src="img/bjp.png" width="100px" height="100px"/></td>
            <td>Bharatiya Janata Party</td>
            <td><asp:Button CssClass="button" Text="Vote" runat="server" ID="btnBJP" OnClick="btnBJP_Click" /></td>
        </tr>
        <tr>
            <td>2.</td>
            <td><img src="img/Congress.png" width="100px" height="100px"/></td>
            <td>National Congress Party</td>
            <td><asp:Button CssClass="button" Text="Vote" runat="server" ID="btnCongress" OnClick="btnCongress_Click"/></td>
        </tr>
        <tr>
            <td>3.</td>
            <td><img src="img/shivsena.jpg" width="100px" height="100px"/></td>
            <td>Shivsena</td>
            <td><asp:Button CssClass="button" Text="Vote" runat="server" ID="btnOthers" OnClick="btnOthers_Click"/></td>
        </tr>
    </table>
        </form>
   
</body>
</html>
