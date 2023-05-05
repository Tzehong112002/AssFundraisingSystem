<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="AssFundraisingSystem.UserSide.forgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/LoginStyle.css" rel="stylesheet" />
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

<h2 class="mb-4">Forgot Password</h2>

<div class="form-group mb-4">
    <asp:TextBox required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email" runat="server" ID="txtEmail"></asp:TextBox>
    <asp:RegularExpressionValidator ID="emailValidator" runat="server" ControlToValidate="txtEmail" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$" ErrorMessage="Please enter a valid email address" Display="Dynamic"></asp:RegularExpressionValidator>
</div>



<div class="form-group mb-4">

    
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" Text="Label" Visible="False"></asp:Label>

    
</div>
<asp:Button Text="SUBMIT" CssClass="btn btn-primary" Height="50px" Width="400px" runat="server" OnClick="Unnamed2_Click" ID="submitbtn" />

  

    <div id="hyperlinkPage">

        <a href="Register.aspx" id="HyperlinkSU">dont have an account?</a>
        <a href="Login.aspx" id="HyperlinkFP">login to account</a>
    </div>
    <br />
    <div id="hyperlinkPage">
        <a href="OrganizationLogin.aspx" id="">Organization Login ?</a>

    </div>

</div>



</div>


</div>

</div>

</form>
</body>
</html>
