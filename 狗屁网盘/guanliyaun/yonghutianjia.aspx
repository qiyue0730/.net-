<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yonghutianjia.aspx.cs" Inherits="狗屁网盘.guanliyaun.yonghutianjia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<style>
        body {
            background-color: #e4f3ff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>添加用户</h2>
            <hr />
            <br />
            <br />
            账 号:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="不能为空" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            <br />
            <br />
            密 码:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="不能为空" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            <br />
            <br />
            年 龄:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="不能为空" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" ForeColor="Red" runat="server" ErrorMessage="请输入合理的年龄" ControlToValidate="TextBox3" MaximumValue="150" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            <br />
            <br />
            手机号:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="不能为空" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
            <br />
            <br />
            邮 箱:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="不能为空" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" runat="server" ErrorMessage="请输入正确的邮箱格式" ControlToValidate="TextBox5" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />
            用户权限：
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="1" Text="普通用户" Checked="True" /><asp:RadioButton ID="RadioButton2" runat="server" GroupName="1" Text="管理员" />

            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="确认添加" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
