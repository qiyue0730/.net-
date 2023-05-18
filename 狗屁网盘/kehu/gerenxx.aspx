<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gerenxx.aspx.cs" Inherits="狗屁网盘.kehu.gerenxx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        * {
            margin: 0px;
            padding: 0px;
            text-decoration: none;
            list-style-type: none;
        }

        .grid {
            display: flex;
            flex-wrap: nowrap;
            flex-flow: row;
        }

        .grid1 {
            flex-grow: 1;
        }

        .grid2 {
            flex-grow: 2;
        }

        .grid3 {
            flex-grow: 3;
        }

        .grid4 {
            flex-grow: 4;
        }

        .grid5 {
            flex-grow: 5;
        }

        .grid6 {
            flex-grow: 6;
        }

        body {
            background-color: #e4f3ff;
            background-size: cover;
        }

        #jianjie {
            margin: 0 auto;
            width: 1000px;
            height: 420px;
            background-color: rgba(255,255,255,0.5);
            border-radius: 20px;
            margin-top: 100px;
        }

        #zuo, #you {
            float: left;
            /*border:1px solid red;*/
            margin-top: 15px;
            margin-left: 15px;
        }

        #you {
            padding-left: 30px;
            padding-top: 20px;
        }

        .td1, .td2 {
            padding-bottom: 10px;
            padding-top: 13px;
            font-size: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="jianjie">
                <h2 style="text-align: center; font-size: 50px;">个人信息</h2>
                <div id="zuo">
                    <img src="../imges/狗.png" style="width: 250px; height: 25%; border-radius: 10px;" />
                </div>
                <div id="you">
                    <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Visible="False">保存</asp:LinkButton></td>
                            <td>
                                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" Visible="False">取消</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label></td>
                            <td class="td2">
                                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <asp:Label ID="Label2" runat="server" Text="电话号码："></asp:Label></td>
                            <td class="td2">
                                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <asp:Label ID="Label5" runat="server" Text="年龄："></asp:Label></td>
                            <td class="td2">
                                <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="数据错误" ControlToValidate="TextBox4" MaximumValue="70" MinimumValue="18" ForeColor="Red" Type="Integer"></asp:RangeValidator>
                        </tr>
                        <tr>
                            <td class="td1" style="font-size: 23px;">
                                <asp:Label ID="Label4" runat="server" Text="邮箱："></asp:Label></td>
                            <td class="td2" style="font-size: 23px;">
                                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CausesValidation="False">修改信息</asp:LinkButton></td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">返回</asp:LinkButton></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
