<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="狗屁网盘.index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" height="00">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
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
        }

        #daohang {
            width: 100%;
            height: 10%;
            text-align: center;
        }

        .li1 {
            margin-top: 18px;
            margin-bottom: 18px;
            margin-left: 30px;
            margin-right: 30px;
        }

        .huiyuan {
            background-color: #ffaf26;
            border-radius: 25px;
        }

        #daohanul li:hover {
            color: cornflowerblue;
        }

        .li2 {
            text-align: center;
            margin-top: 5%;
            width: 100%;
            height: 90%;
        }

            .li2 img {
                width: 100%;
                height: 90%;
            }

        .p1 {
            font-size: 60px;
            font-weight: 800;
        }

        .p2 {
            font-size: 18px;
            color: #808080;
            text-align: left;
            margin-left: 25%;
        }

        #qudenglu {
            position: absolute;
            top: 55%;
            left: 12%;
            height: 10%;
            width: 20%;
            border-radius: 50px;
            background-color: cyan;
            border-color: cyan;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
            <div id="daohang" class="grid">
                <ul class="grid4 li1">
                    <li style="font-size: 18px; font-family: 'Sitka Banner'; text-align: left;">Webdisk网盘</li>
                </ul>
                <ul class="grid grid4" id="daohanul">
                    <li class="grid1 li1">网盘首页</li>
                    <li class="grid1 li1">服务器下载</li>
                    <li class="grid1 li1">官方微博</li>
                    <li class="grid1 li1">问题反馈</li>
                    <li class="grid1 huiyuan li1">会员中心</li>
                </ul>
            </div>
            <div id="zhong">
                <ul class="grid">
                    <li class="grid1 li2">
                        <p class="p1">记录每一份热爱</p>
                        <p class="p1" style="margin-bottom: 2%">让美好永远陪伴</p>
                        <p class="p2">&nbsp;&nbsp;&nbsp; 为你的文件提供备份、分享等服务</p>
                        <p class="p2">&nbsp;&nbsp;&nbsp; 帮你便捷安全的管理数据</p>
                    </li>
                    <li class="grid2 li2">
                        <img src="imges/狗.png" /></li>
                </ul>
            </div>
            <br />
            <asp:Button ID="qudenglu" runat="server" Text="去登陆" Font-Size="X-Large" OnClick="qudenglu_Click" />
        </div>
    </form>
</body>
</html>
 