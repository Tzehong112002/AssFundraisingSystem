<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AssFundraisingSystem.UserSide.Register" %>

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

<div class="form-group mb-4">
    <asp:TextBox required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Name" runat="server" ID="txtName"></asp:TextBox>
    <asp:RequiredFieldValidator ID="nameValidator" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtName" ErrorMessage="Name should contain only alphabets" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
</div>


<div class="form-group mb-4">
    <asp:TextBox required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="User Name" runat="server" ID="txtusername"></asp:TextBox>
    <asp:RequiredFieldValidator ID="usernameRequired" runat="server" ControlToValidate="txtusername" ErrorMessage="Username is required" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="usernameValidator" runat="server" ControlToValidate="txtusername" OnServerValidate="ValidateUsername" ErrorMessage="Username already exists or is less than 6 characters" Display="Dynamic"></asp:CustomValidator>
</div>

<div class="form-group mb-4">
    <asp:TextBox CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email" runat="server" ID="txtEmail"></asp:TextBox>
    <asp:RequiredFieldValidator ID="emailRequired" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="emailValidator" runat="server" ControlToValidate="txtEmail" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage="Invalid email format" Display="Dynamic"></asp:RegularExpressionValidator>
</div>


<div class="form-group mb-4">
  <asp:TextBox required="true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password" runat="server" ID="txtPassword"></asp:TextBox>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$" ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number" Display="Dynamic"></asp:RegularExpressionValidator>
</div>
<div class ="form-group mb-4">
  <asp:TextBox required= "true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Confirm Password" runat="server" ID="txtConfirmPassword"></asp:TextBox>
  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="The passwords do not match." Display="Dynamic"></asp:CompareValidator>
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
