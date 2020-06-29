<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Testing.Result" EnableSessionState="False" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/vote_page.css" rel="stylesheet" />
    <style>
        #progress{
            color:Red;
            display:block;
            padding-top:20px;
            text-align:center;
            font-size:2em;
            animation: live 2s infinite;
            
        }
        @keyframes live{
            0% {color:darkred}
            50% {color:red}
            100% {
                color:lightcoral
            }
        }
        #Win {
            color:blue;
            display:block;
            padding-top:20px;
            text-align:center;
            font-size:1.15em;
            
        }
    </style>
</head>
<body>

     <asp:Label ID="progress" runat="server"/>
    <asp:Label ID="Win" runat="server" />
    <form id="form1" runat="server">
        <table class="rwd-table" align="center" >
        <tr>
            <th>Sr.No</th>
            <th>Logo</th>
            <th>Poltical Party Name</th>
            <th>Gujarat</th>
            <th>Rajshthan</th>
            <th>MahaRashtra</th>
            <th>Total</th>
        </tr>
        <tr>
            <td>1.</td>
            <td><img src="img/bjp.png" width="100px" height="100px"/></td>
            <td>Bharatiya Janata Party</td>
            <td><asp:Label  ID="BJP_Gujarat" runat="server" /></td>
            <td><asp:Label  ID="BJP_Rajasthan" runat="server" /></td>
            <td><asp:Label  ID="BJP_Maharashtra" runat="server" /></td>
            <td><asp:Label  ID="BJP_total" runat="server" /></td>
        </tr>
        <tr>
            <td>2.</td>
            <td><img src="img/Congress.png" width="100px" height="100px"/></td>
            <td>National Congress Party</td>
            <td><asp:Label  ID="Congress_Gujarat" runat="server" /></td>
            <td><asp:Label  ID="Congress_Rajasthan" runat="server" /></td>
            <td><asp:Label  ID="Congress_Maharashtra" runat="server" /></td>
            <td><asp:Label  ID="Congress_total" runat="server" /></td>
        </tr>
        <tr>
            <td>3.</td>
            <td><img src="img/shivsena.jpg" width="100px" height="100px"/></td>
            <td>Shivsena</td>
            <td><asp:Label  ID="Shivsena_Gujarat" runat="server" /></td>
            <td><asp:Label  ID="Shivsena_Rajasthan" runat="server" /></td>
            <td><asp:Label  ID="Shivsena_Maharashtra" runat="server" /></td>
            <td><asp:Label  ID="Shivsena_total" runat="server" /></td>
        </tr>
    </table>
    </form>

</body>
</html>
