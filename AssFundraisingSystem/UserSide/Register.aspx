﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AssFundraisingSystem.UserSide.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/LoginStyle.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/ExtraLoginRegisterStyle.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div class=" page-holder d-flex align-items-center">
<div class="container">
<div class="row align-items-center py-5">
<div class="col-5 col-lg-7 mx-auto mb-5 mb-lg-0">

<div class="pr-lg-5">
<img src="Img/IconLogin.jpg" alt="" class="img-fluid" />
</div>
</div>
<div class="col-lg-5 px-lg-4">
<h1 class="text-base text-primary text-uppercase mb-4">Sign up Here</h1>
<h2 class="mb-4">Welcome Back!</h2>

<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="First Name" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Last Name" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="User Name" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Confirm Password" runat="server" ></asp:TextBox>

</div>


<asp:Button Text="Sign up" CssClass="btn btn-primary" Height="50px" Width="400px" runat="server" OnClick="Unnamed7_Click" />

    <div id="hyperlinkPage">

        <a href="Login.aspx" id="HyperlinkLogin">already have an account?</a>
        <a href="forgotPassword.aspx" id="HyperlinkFP">forgot password</a>
    </div>


    <div id="hyperlinkPage">
        <a href="OrganizationLogin.aspx" id="">Organization Login ?</a>

    </div>
</div>
</div>


</div>


</form>
</body>
</html>
