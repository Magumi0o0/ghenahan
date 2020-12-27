<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="ghenahan.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 433px;
            width: 1047px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        </div>
        <asp:TextBox ID="txtBirth" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
        <p>
            <asp:TextBox ID="txtPaas" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Button ID="add" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <asp:FileUpload ID="FileUpload1" runat="server" Width="258px" />
        <asp:GridView ID="gdview" runat="server" Height="249px" OnSelectedIndexChanged="gdview_SelectedIndexChanged" Width="527px">
        </asp:GridView>
    </form>
</body>
</html>
