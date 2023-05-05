<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AssFundraisingSystem.UserSide.Login" %>

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
    <div class="page-holder d-flex align-items-center">
        <div class="container">
            <div class="row align-items-center py-5">
                <div class="col-5 col-lg-7 mx-auto mb-5 mb-lg-0">
                    <div class="pr-lg-5">
                        <img src="Img/IconLogin.jpg" alt="" class="img-fluid" />
                    </div>
                </div>
                <div class="col-lg-5 px-lg-4">
                    <h1 class="text-base text-primary text-uppercase mb-4">Login Here</h1>
                    <h2 class="mb-4">Welcome Back!</h2>

                    <div class="form-group mb-4">
                        <asp:TextBox required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Username" runat="server" ID="txtUsername"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="usernameRequiredFieldValidator" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter your username" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group mb-4">
                        <asp:TextBox required="true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password" runat="server" ID="txtPassword"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group mb-4">
                        <div class="custom-control custom-checkbox">
                            <asp:CheckBox Text="&nbsp;&nbsp;&nbsp;Remember Me" runat="server" />
                        </div>

                        <div id="recaptcha-container">
                            <div class="g-recaptcha" data-sitekey="6LfJUNslAAAAAHM3ZOpAzFserQk75KOsmJcgwjh3" data-callback="onSubmit"></div>
                        </div>

                        <asp:Label ID="errorMessage" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>

                        <asp:CustomValidator runat="server" ID="recaptchaValidator" ClientValidationFunction="validateCaptcha" ErrorMessage="Please check the reCAPTCHA checkbox." />
                    </div>

                    <asp:Button Text="LOGIN" CssClass="btn btn-primary" Height="50px" Width="400px" runat="server" OnClick="Unnamed4_Click" />

                    <div id="hyperlinkPage">
                        <a href="Register.aspx" id="HyperlinkSU">don't have an account?</a>
                        <a href="forgotPassword.aspx" id="HyperlinkFP">forgot password</a>
                    </div>
                    <br />
                    <div id="hyperlinkPage">
                        <a href="OrganizationLogin.aspx" id="">Organization Login?</a>
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
