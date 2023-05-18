<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yonghuindex.aspx.cs" Inherits="狗屁网盘.guanliyaun.yonghuindex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../js/jquery-3.3.1.min.js"></script>
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
        }

        #zuo {
            float: left;
            background-color: #8ed2e4;
            width: 300px;
            height: 100%;
            padding-top: 50px;
        }

        #Label1 {
            margin-left: 28px;
            font-size: 30px;
            font-weight: 600;
        }

        #Label2 {
            border: 2px solid white;
            font-size: 20px;
            font-weight: 600;
            margin-left: 50px;
        }

        #daohang ul {
            margin-top: 30px;
            width: 300px;
        }

            #daohang ul li {
                margin: 10px;
            }

        #Button5, #Button2, #Button6, #Button4 {
            width: 280px;
            height: 50px;
            border-radius: 15px;
        }

        #Button1 {
            margin-left: 180px;
        }

        #huiyuan {
            margin-bottom: 20px;
        }

        #zuoxia {
            margin-top: 412px;
            font-size: 20px;
        }

        #Label3, #Label4 {
            margin-left: 30px;
        }

        #Label5 {
            margin-left: 100px;
        }

        hr {
            margin-bottom: 20px;
        }

        /*#wjcz, #yhxx, #yhqx, #svip {
            display: none;
        }*/

        input {
            border: 1px; /*去掉未选中边框*/
            outline: none; /*去掉选中边框*/
        }

        #GridView1, #GridView2, #GridView3, #GridView4, #GridView5, #GridView6 {
            text-align: center;
        }
    </style>
    <script>
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="zuo">
                <asp:Label ID="Label1" runat="server" Text="狗屁网盘"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="管理端"></asp:Label>
                <div id="daohang">
                    <ul>
                        <li>
                            <asp:Button ID="Button2" runat="server" Text="文件管理" OnClick="Button2_Click" />
                            <%--<input id="Button1" type="button" value="文件管理" />--%></li>
                        <%--<li><asp:Button runat="server" Text="Button"></asp:Button>
                            <input id="Button2" type="button" value="文件操作" /></li>--%>
                        <li>
                            <asp:Button ID="Button5" runat="server" Text="用户信息" OnClick="Button5_Click" />
                            <%--<input id="Button3" type="button" value="用户信息" />--%></li>
                        <li>
                            <asp:Button ID="Button6" runat="server" Text="用户封禁" OnClick="Button6_Click" />
                            <%--                            <input id="Button4" type="button" value="用户封禁" />--%></li>
                    </ul>
                </div>
                <div id="zuoxia">
                    <div id="huiyuan">
                        <%--<asp:Label ID="Label3" runat="server" Text="0/1G"></asp:Label>--%>
                    </div>
                    <hr />
                    <%--<asp:Label ID="Label5" runat="server" Text=""></asp:Label>--%>
                    <asp:Button ID="Button1" runat="server" BackColor="#8ed2e4" Text="退出" OnClick="Button1_Click" Width="55px" Font-Size="24px" />
                </div>
            </div>
            <div id="you">
                <div id="wenjian">
                    <asp:Label ID="Label3" runat="server" Text="请选择你要查询的文件：" Font-Size="25px" ></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Size="25px" AutoPostBack="True" Height="37px" Width="210px">
                        <asp:ListItem Value="1">txt文件</asp:ListItem>
                        <asp:ListItem Value="2">图片文件</asp:ListItem>
                        <asp:ListItem Value="3">音频文件</asp:ListItem>
                        <asp:ListItem Value="4">其他文件</asp:ListItem>
                    </asp:DropDownList>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" DataKeyNames="TxtId" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="TxtId" HeaderText="序号" ReadOnly="True" />
                            <asp:BoundField DataField="TxtName" HeaderText="文件名" />
                            <asp:BoundField DataField="TxtTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="TxtSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" EditText="重命名" UpdateText="确定" />
                            <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView2" runat="server" Visible="False" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" DataKeyNames="PhotoId">
                        <Columns>
                            <asp:BoundField DataField="PhotoId" HeaderText="序号" ReadOnly="True" />
                            <asp:BoundField DataField="PhotoName" HeaderText="文件名" />
                            <asp:BoundField DataField="PhotoTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="PhotoSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" EditText="重命名" UpdateText="确定" />
                            <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView3" runat="server" Visible="False" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" DataKeyNames="MusicId">
                        <Columns>
                            <asp:BoundField DataField="MusicId" HeaderText="序号" ReadOnly="True" />
                            <asp:BoundField DataField="MusicName" HeaderText="文件名" />
                            <asp:BoundField DataField="MusicTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="MusicSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" EditText="重命名" UpdateText="确定" />
                            <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView4" runat="server" Visible="False" AutoGenerateColumns="False" Width="866px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" DataKeyNames="OthersId" OnRowCancelingEdit="GridView4_RowCancelingEdit" OnRowDeleting="GridView4_RowDeleting" OnRowEditing="GridView4_RowEditing" OnRowUpdating="GridView4_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="OthersId" HeaderText="序号" ReadOnly="True" />
                            <asp:BoundField DataField="OthersName" HeaderText="文件名" />
                            <asp:BoundField DataField="OthersTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="OthersSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" EditText="重命名" UpdateText="确定" />
                            <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>


                </div>
                <div id="wjcz">
                </div>
                <div id="yhxx">
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Width="980px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" OnRowDeleting="GridView5_RowDeleting" OnRowCancelingEdit="GridView5_RowCancelingEdit" OnRowEditing="GridView5_RowEditing" OnRowUpdating="GridView5_RowUpdating" DataKeyNames="UserId">
                        <Columns>
                            <asp:BoundField DataField="UserId" HeaderText="序号" ReadOnly="true" />
                            <asp:BoundField DataField="username" HeaderText="用户名" />
                            <asp:BoundField DataField="userpwd" HeaderText="用户密码" />
                            <asp:BoundField DataField="loa" HeaderText="用户权限" />
                            <asp:BoundField DataField="Userage" HeaderText="用户年龄" />
                            <asp:BoundField DataField="Useriphon" HeaderText="用户手机" />
                            <asp:BoundField DataField="Useremil" HeaderText="用户邮箱" />
                            <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                            <asp:CommandField EditText="修改" HeaderText="操作" ShowEditButton="True" UpdateText="修改" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" Font-Size="30px" runat="server" ForeColor="#333333">添加新用户</asp:LinkButton>
                </div>
                <div id="yhqx">
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" s DataKeyNames="userid">
                        <Columns>
                            <asp:BoundField DataField="userid" HeaderText="序号" />
                            <asp:BoundField DataField="username" HeaderText="用户名" />
                            <asp:BoundField DataField="loa" HeaderText="用户权限" />
                            <asp:TemplateField ShowHeader="False" HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" CommandArgument='<%#Eval("userid") %>' OnClientClick="return confirm('是否确认执行该操作')" CausesValidation="false" CommandName=""><%#Eval("loa","{0}")=="被封禁用户"?"解除封禁":"封禁" %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                <div id="svip">
                </div>
            </div>
        </div>
    </form>
    <script>
        //$("#Button2").click(function () {
        //    $("#wenjian").hide();
        //    $("#wjcz").show();
        //    $("#yhxx").hide();
        //    $("#yhqx").hide();
        //    $("#svip").hide();
        //    $("#huishouzhan").hide();
        //})
        //$("#Button1").click(function () {
        //    $("#wenjian").show();
        //    $("#wjcz").hide();
        //    $("#yhxx").hide();
        //    $("#yhqx").hide();
        //    $("#svip").hide();
        //    $("#huishouzhan").hide();
        //})
        //$("#Button3").click(function () {
        //    $("#wenjian").hide();
        //    $("#wjcz").hide();
        //    $("#yhxx").show();
        //    $("#yhqx").hide();
        //    $("#svip").hide();
        //    $("#huishouzhan").hide();
        //})
        //$("#Button4").click(function () {
        //    $("#wenjian").hide();
        //    $("#wjcz").hide();
        //    $("#yhxx").hide();
        //    $("#yhqx").show();
        //    $("#svip").hide();
        //    $("#huishouzhan").hide();
        //})
        //$("#Button5").click(function () {
        //    $("#wenjian").hide();
        //    $("#wjcz").hide();
        //    $("#yhxx").hide();
        //    $("#yhqx").hide();
        //    $("#svip").show();
        //    $("#huishouzhan").show();
        //})
    </script>
</body>
</html>
