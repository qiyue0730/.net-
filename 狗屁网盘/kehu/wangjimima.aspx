<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wangjimima.aspx.cs" Inherits="狗屁网盘.wangjimima" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
           *
        {
            margin: 0px;
            padding: 0px;
            text-decoration: none;
            list-style-type: none;
        }
       
        .grid
        {
            display: flex;
            flex-wrap: nowrap;
            flex-flow: row;
        }

        .grid1
        {
            flex-grow: 1;
        }

        .grid2
        {
            flex-grow: 2;
        }

        .grid3
        {
            flex-grow: 3;
        }

        .grid4
        {
            flex-grow: 4;
        }

        .grid5
        {
            flex-grow: 5;
        }

        .grid6
        {
            flex-grow: 6;
        }
        
        body
        {
            background-color: #e4f3ff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>&nbsp;</h3>
        <h3>重置密码</h3>
        <p>&nbsp;</p>
        <hr />
        <asp:Label ID="Label1" runat="server" Text="手机号："></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="获取验证码" Width="122px" CausesValidation="False" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="新用户名："></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="新密码："></asp:Label><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空" ControlToValidate="TextBox4" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="确认密码："></asp:Label><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ControlToCompare="TextBox4" ControlToValidate="TextBox5" ForeColor="Red" Type="Integer"></asp:CompareValidator>
        <br />
        <br />
&nbsp;
        <asp:Button ID="Button2" runat="server" Text="确定" OnClick="Button2_Click" />&nbsp; <asp:Button ID="Button3" runat="server" Text="返回" OnClick="Button3_Click" CausesValidation="False" />
         </div>
    </form>
</body>
</html>
