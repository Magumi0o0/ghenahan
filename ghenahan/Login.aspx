<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ghenahan.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="Txtemail" runat="server"></asp:TextBox>
        <p>
            <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btnlogin" runat="server" Text="Button" OnClick="btnlogin_Click" />
    </form>
</body>
</html>
