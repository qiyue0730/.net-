<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="狗屁网盘.kehu.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../js/jquery-3.3.1.min.js"></script>
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server"  />
           <asp:Image ID="Image1" runat="server" />
            <%-- <span style="font-family: 'Microsoft YaHei'; font-size: 18px;">
                <audio id="auto"  controls="controls" autoplay="autoplay">
                </audio>
              <%--src="/UploadFile/王菲 - 如愿.mp3" --%>
            <%--</span>--%>
           <audio id="auto" controls="controls" autoplay="autoplay" ></audio>
        </div>
    </form>
    <script>
        var geturl = document.getElementById("HiddenField1").value;
        const src1 = document.querySelector("audio");
        src1.src=geturl;
        ////var url = document.getElementById("mu").
        //var audio = document.getElementById("audio");
        //function play() {

        //        audio.src = geturl;
            
        //    audio.play(); // 播放
        //}

    </script>
</body>
</html>
