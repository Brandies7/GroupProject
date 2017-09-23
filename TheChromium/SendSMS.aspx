<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="TheChromium.SendSMS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4>To Number:</h4>
        <asp:TextBox ID="ToNumber" TextMode="Password" runat="server"></asp:TextBox>
        <h4>SMS Message:</h4>
        <asp:TextBox ID="Message"  runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SendMessage" runat="server" Text="Send Message" OnClick="SendMessage_OnClick" />

    </div>
    </form>
</body>
</html>
