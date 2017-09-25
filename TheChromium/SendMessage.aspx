<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="TheChromium.SendMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="To Number:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="463px">

</asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        Message:<br />
        <asp:TextBox ID="TextBox2" runat="server" Height="496px" Width="945px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Send" Width="213px" OnClick="ButtonSend_Click" />
        <br />
        <br />
    </form>
</body>
</html>
