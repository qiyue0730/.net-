<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="登录.aspx.cs" Inherits="大二项目.登录" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录</title>
    <style type="text/css">
        * {
            padding: 0px;
            margin-left: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }

        input {
            outline: none;
        }

        html,
        body {
            height: 100%;
        }

        body {
            margin-top: 120px;
            display: flexbox;
            background: linear-gradient(to right,#c9e0ed,#edd4dc);
        }

        .box {
            width: 1050px;
            height: 600px;
            display: flexbox;
            position: relative;
            /*background-color: #fff;*/ /*板块颜色透明*/
            margin: auto;
            border-radius: 8px;
            border: 1px solid #ff6a00;
            box-shadow: 1px 1px 1px 1px;
        }

        .pre-box {
            width: 525px;
            height: 100%;
            background-color: #c9e0ed;
            position: absolute;
            left: 0;
            top: 0;
            border-radius: 4px;
            box-shadow: 1px 1px 1px 1px;
            transition: 0.5s ease-in-out;
        }

            .pre-box h1 {
                color: white;
                margin-top: 150px;
                text-align: center;
                letter-spacing: 5px;
                text-shadow: 4px 4px 3px 3px;
            }

            .pre-box p {
                color: white;
                height: 30px;
                line-height: 30px;
                text-align: center;
                margin: 20px 0;
                font-weight: bold;
                text-shadow: 4px 4px 3px 3px;
            }

        .img-box {
            width: 200px;
            height: 200px;
            margin: 20px auto;
            border-radius: 50%;
            overflow: hidden;
            box-shadow: 1px 1px 1px 1px;
        }

            .img-box img {
                width: 100%;
                transition: 0.5s;
            }

        .login-form,
        .register-form {
            width: 525px;
            flex: 1;
            height: 100%;
            float: left;
        }

        .title-box {
            height: 157px;
            line-height: 210px;
        }

            .title-box h1 {
                color: white;
                text-align: center;
                letter-spacing: 5px;
                text-shadow: 1px 1px 1px 1px;
            }

        .input-box {
            display: flexbox;
            flex-direction: column;
            text-align: center;
            height: 129px;
        }

        input {
            margin-bottom: 15px;
            text-indent: 4px;
            border-radius: 4px;
            width: 237px;
            height: 23px;
        }

            input:focus /*文字颜色*/ {
                color: black;
            }



        .btn-box {
            display: flexbox;
            height: 47px;
            width: 403px;
        }

        button {
            width: 100px;
            height: 30px;
            line-height: 30px;
            border-radius: 4px;
            background-color: #15c6ff;
            color: white;
            margin-left: 150px;
        }

            button:hover {
                cursor: pointer;
                /*opacity: .8;*/
            }

        .btn-box span {
            color: white;
            height: 30px;
            line-height: 30px;
            font-size: 14px;
            text-align: center;
        }

            .btn-box span:hover {
                cursor: pointer;
                border-bottom: 1px solid white;
            }

        #RadioButton1, #RadioButton2, #RadioButton3 {
            width: 20px;
            height: 20px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <div class="pre-box">
                <h1>Webdisk网盘</h1>
                <div class="img-box">
                    <img src="imges/狗.png" style="width: 200px; height: 200px" />
                </div>
            </div>

            <div class="register-form">
                <div class="title-box">
                    <h1>注册</h1>
                </div>
                <div class="input-box">
                    用户名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <br />
                    手机号码：&nbsp;&nbsp;&nbsp;  
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <br />
                    密码 ：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    <br />
                    确认密码：&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    <br />
                    验证码：&nbsp;
                    <asp:TextBox ID="TextBox7" runat="server" Width="100px"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="获取验证码" OnClick="Button3_Click" CausesValidation="False" Width="100px"/>
                    <div class="btn-box">
                        <asp:Button ID="Button2" runat="server" Text="注册" Width="85px" OnClick="Button2_Click1" />
                        &nbsp;
                        <span class="dl">已有账号？去登录</span>
                    </div>
                </div>
            </div>
            <div class="login-form">
                <div class="title-box">
                    <h1>登录</h1>
                </div>
                <div class="input-box">
                    用户名：
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br /><br />
                    &nbsp;&nbsp;
                   密码：
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    <br /><br />
                    <div class="btn-box" style="margin-left: 100px">
                        <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" OnClick="LinkButton1_Click">忘记密码</asp:LinkButton>
                        <asp:Button ID="Button1" runat="server" Text="登录" Width="85px" OnClick="Button1_Click" />
                        <span class="zc">没有账号？去注册</span>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script>

    $(function () {
        $(".zc").click(function () {
            $(".pre-box").css("transform", "translateX(100%)")
            $(".pre-box").css("background-color", "#edd4dc")
            $("img").attr("src", "imges/狗.png")
        })
        $(".dl").click(function () {
            $(".pre-box").css("transform", "translateX(0%)")
            $(".pre-box").css("background-color", " #c9e0ed")
            $("img").attr("src", "imges/狗.png")
        })
        $(".denglu").click(function () {
        })
    })



</script>
</html>
