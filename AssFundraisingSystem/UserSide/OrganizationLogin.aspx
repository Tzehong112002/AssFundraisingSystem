<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrganizationLogin.aspx.cs" Inherits="AssFundraisingSystem.UserSide.OrganizationLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/LoginStyle.css" rel="stylesheet" />
    <link href="css/ExtraLoginRegisterStyle.css" rel="stylesheet" />
        <script src="https://www.google.com/recaptcha/api.js" async defer></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class=" page-holder d-flex align-items-center">
<div class="container">
<div class="row align-items-center py-5">
<div class="col-5 col-lg-7 mx-auto mb-5 mb-lg-0">

<div class="pr-lg-5">
    <img src="../Images/organization.jpg"class="img-fluid"  />

</div>
</div>
<div class="col-lg-5 px-lg-4">
<h1 class="text-base text-primary text-uppercase mb-4">Login Here</h1>
<h2 class="mb-4">Welcome Organization Thank For Join Us</h2>

<div class ="form-group mb-4">
    <asp:TextBox CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Username" runat="server" ID="txtUsername" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="usernameRequired" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required" Display="Dynamic"></asp:RequiredFieldValidator>
</div>

<div class ="form-group mb-4">
    <asp:TextBox TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password" runat="server" ID="txtPassword" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="passwordRequired" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" Display="Dynamic"></asp:RequiredFieldValidator>
</div>

<div class="form-group mb-4">

<div id="recaptcha-container">
<div class="g-recaptcha" data-sitekey="6LfJUNslAAAAAHM3ZOpAzFserQk75KOsmJcgwjh3" data-callback="onSubmit"></div>
</div>
    
</div>
<asp:Button Text="LOGIN" CssClass="btn btn-primary" Height="50px" Width="400px" runat="server" OnClick="Unnamed4_Click" />

  

    <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
     <asp:Label ID="errorMessage" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>


  

    <div id="hyperlinkPage">

        <a href="Register.aspx" id="HyperlinkSU">dont have an account?</a>
        <a href="forgotPassword.aspx" id="HyperlinkFP">forgot password</a>

    </div>
    <br />

    <div id="hyperlinkPage">
        <a href="Login.aspx" id="">Login User account</a>

    </div>
        

           

</div>



</div>


</div>

</div>
    </form>

    <script type="text/javascript">
    function validateCaptcha(sender, args) {
        args.IsValid = grecaptcha.getResponse().length !== 0;
    }
    function onSubmit(token) {
        document.getElementById("recaptcha-container").style.display = "none";
    }
    </script>
</body>
</html>
