<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan.aspx.cs" Inherits="狗屁网盘.kehu.caidan" %>

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

        #Button1, #Button2, #Button3, #Button4, #Button6 {
            width: 280px;
            height: 50px;
            border-radius: 15px;
        }

        #huiyuan {
            margin-bottom: 20px;
        }

        #zuoxia {
            margin-top: 150px;
            font-size: 20px;
        }

        #Label3, #LinkButton1 {
            margin-left: 30px;
        }

        #LinkButton2, #LinkButton3 {
            margin-left: 100px;
        }

        #LinkButton3, #LinkButton1 {
            color: black;
        }

        hr {
            margin-bottom: 20px;
        }

        #xiangce, #mimaxiang, #huishou, #svip {
            display: none;
        }

        input {
            border: 1px; /*去掉未选中边框*/
            outline: none; /*去掉选中边框*/
        }

        #you {
            padding-top: 50px;
        }

        #you-top {
            height: 50px;
        }

        .han {
            text-align: center;
        }

        #Label4 {
            text-align: center;
            font-size: 30px;
        }

        #jingdu1 {
            width: 300px;
            height: 10px;
            background-color: #d6d6d6;
            border-radius: 50px;
        }

        #jingdu2 {
            margin-top: -10px;
            height: 10px;
            background-color: #3ee23b;
            border-radius: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="zuo">
                <asp:Label ID="Label1" runat="server" Text="    Webdisk网盘"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="桌面端"></asp:Label>
                <div id="daohang">
                    <ul>
                        <li>
                            <asp:Button ID="Button1" runat="server" Text="文档" OnClick="Button1_Click" />
                        </li>
                        <li>
                            <asp:Button ID="Button2" runat="server" Text="图片" OnClick="Button2_Click" />
                        </li>
                        <li>
                            <asp:Button ID="Button3" runat="server" Text="音频" OnClick="Button3_Click" />
                        </li>
                        <li>
                            <asp:Button ID="Button4" runat="server" Text="其他" OnClick="Button4_Click" />
                        </li>
                        <li>
                            <asp:Button ID="Button6" runat="server" Text="回收站" OnClick="Button6_Click" />
                        </li>
                    </ul>
                </div>
                <div id="zuoxia">
                    <div id="huiyuan">
                        <asp:Label ID="Label3" runat="server" Text="自己文件的总大小"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="获取isvip"></asp:Label>
                        <br />
                        <div style="border: 1px solid #d6d6d6">
                            <div id="jingdu1"></div>
                            <div id="jingdu2"></div>
                        </div>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <script>
                            var baifenbi = $("#HiddenField1").val();
                            var a = document.getElementById("Label5").innerHTML;
                            if (a == "/50MB") {
                                if (baifenbi > 40) {
                                    document.getElementById("jingdu2").style.backgroundColor = "red";
                                    document.getElementById("jingdu2").style.width = baifenbi * 2 + "%";
                                }
                                else {
                                    document.getElementById("jingdu2").style.backgroundColor = "#3ee23b";
                                    document.getElementById("jingdu2").style.width = baifenbi + "%";
                                }
                            } else if (a == "/100MB") {
                                if (baifenbi > 90) {
                                    document.getElementById("jingdu2").style.backgroundColor = "red";
                                    document.getElementById("jingdu2").style.width = baifenbi + "%";
                                }
                                else {
                                    document.getElementById("jingdu2").style.backgroundColor = "#3ee23b";
                                    document.getElementById("jingdu2").style.width = baifenbi + "%";
                                }
                            }

                        </script>
                        <hr />
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click5">开通会员</asp:LinkButton>
                    </div>

                </div>
                <hr />

                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">个人信息</asp:LinkButton>

                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" OnClientClick="return confirm('是否退出登录')">退出</asp:LinkButton>
            </div>

            <div id="you">
                <div id="you-top">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    &nbsp;<asp:Button ID="Button7" runat="server" Text="上传" OnClick="Button7_Click" Width="94px" BackColor="White" />
                    &nbsp;
                  
                </div>

                <div id="wendang">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" DataKeyNames="TxtId" OnRowCancelingEdit="GridView4_RowCancelingEdit" OnRowEditing="GridView4_RowEditing" OnRowUpdating="GridView4_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="TxtId" HeaderText="序号" Visible="False" />
                            <asp:BoundField DataField="TxtName" HeaderText="文件名" />
                            <asp:BoundField DataField="TxtTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="TxtSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" EditText="重命名" UpdateText="确定" />

                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" Text="删除" OnClientClick="return confirm('十天内可通过回收站还原，是否删除？')" OnClick="LinkButton1_Click2" CommandArgument='<%#Eval("TxtId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="" Text="下载" CommandArgument='<%#Eval("TxtId") %>' OnClick="LinkButton2_Click1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#Eval("TxtId") %>' OnClick="LinkButton3_Click1" CausesValidation="false" CommandName="" Text="查看"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle BorderColor="#E4F3FF" Height="40px" />
                        <RowStyle CssClass="han" />
                    </asp:GridView>
                </div>
                <div id="tupian">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" DataKeyNames="PhotoId" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="PhotoId" HeaderText="id" Visible="False" />
                            <asp:BoundField DataField="PhotoName" HeaderText="文件名" />
                            <asp:BoundField DataField="PhotoTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="PhotoSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" UpdateText="确定" EditText="重命名" />
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" Text="删除" OnClientClick="return confirm('十天内可通过回收站还原，是否删除？')" CommandArgument='<%#Eval("PhotoId") %>' OnClick="LinkButton1_Click3"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="" Text="下载" OnClick="LinkButton2_Click2" CommandArgument='<%#Eval("PhotoId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="" Text="查看" OnClick="LinkButton3_Click2" CommandArgument='<%#Eval("PhotoId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BorderColor="#E4F3FF" Height="40px" />
                        <RowStyle CssClass="han" />
                    </asp:GridView>
                </div>
                <div id="yinpin">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" DataKeyNames="MusicId" OnRowEditing="GridView2_RowEditing" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowUpdating="GridView2_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="MusicId" HeaderText="id" Visible="False" />
                            <asp:BoundField DataField="MusicName" HeaderText="文件名" />
                            <asp:BoundField DataField="MusicTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="MusicSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" EditText="重命名" UpdateText="确定" />
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" Text="删除" OnClientClick="return confirm('十天内可通过回收站还原，是否删除？')" OnClick="LinkButton1_Click5" CommandArgument='<%#Eval("MusicId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="" Text="下载" OnClick="LinkButton2_Click3" CommandArgument='<%#Eval("MusicId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="" Text="查看" OnClick="LinkButton3_Click3" CommandArgument='<%#Eval("MusicId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BorderColor="#E4F3FF" Height="40px" />

                        <RowStyle CssClass="han"></RowStyle>
                    </asp:GridView>
                </div>
                <div id="qita">
                </div>
                <div id="huishouzhan">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px" DataKeyNames="OthersId" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                        <Columns>
                            <asp:BoundField DataField="OthersId" HeaderText="id" Visible="False" />
                            <asp:BoundField DataField="OthersName" HeaderText="文件名" />
                            <asp:BoundField DataField="OthersTime" HeaderText="上传时间" ReadOnly="True" DataFormatString="{0:yyyy年MM月dd日 hh：mm}" />
                            <asp:BoundField DataField="OthersSize" HeaderText="大小" ReadOnly="True" />
                            <asp:CommandField HeaderText="操作" ShowEditButton="True" EditText="重命名" UpdateText="确定" />
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" Text="删除" OnClientClick="return confirm('十天内可通过回收站还原，是否删除？')" CommandArgument='<%#Eval("OthersId") %>' OnClick="LinkButton1_Click1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="" Text="下载" CommandArgument='<%#Eval("OthersId") %>' OnClick="LinkButton2_Click4"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="" Text="查看" OnClick="LinkButton3_Click4" CommandArgument='<%#Eval("OthersID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BorderColor="#E4F3FF" Height="40px" />
                        <RowStyle CssClass="han" />
                    </asp:GridView>
                    <asp:Label ID="Label4" runat="server" Text="您的回收站为空!" Visible="False" Font-Bold="True" Font-Names="Arial Black"></asp:Label>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Width="843px" CellPadding="10" CellSpacing="1" GridLines="None" RowStyle-CssClass="han" Font-Size="25px">
                        <Columns>
                            <asp:BoundField DataField="RecoveryId" HeaderText="id" Visible="False" />
                            <asp:BoundField DataField="RecoveryName" HeaderText="文件名称" ReadOnly="True" />
                            <asp:BoundField DataField="RecoveryTime" HeaderText="删除时间" ReadOnly="True" />
                            <asp:BoundField DataField="RecoverySize" HeaderText="文件大小" ReadOnly="True" />
                            <asp:BoundField HeaderText="有效时间" DataField="DiffTime" />
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" Text="还原" OnClientClick="return confirm('是否还原所选文件？')" CommandArgument='<%#Eval("RecoveryId") %>' OnClick="LinkButton1_Click4"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="" Text="删除" OnClientClick="return confirm('删除后将无法回复，您确定删除所选文件吗？')" OnClick="LinkButton2_Click" CommandArgument='<%#Eval("RecoveryId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BorderColor="#E4F3FF" Height="40px" />
                        <RowStyle CssClass="han" />
                    </asp:GridView>

                </div>

            </div>
        </div>
    </form>

</body>
</html>
