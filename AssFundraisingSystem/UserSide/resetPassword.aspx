<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="AssFundraisingSystem.UserSide.resetPassword" %>

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
        <div>
            <div class=" page-holder d-flex align-items-center">
<div class="container">
<div class="row align-items-center py-5">
<div class="col-5 col-lg-7 mx-auto mb-5 mb-lg-0">

<div class="pr-lg-5">
<img src="Img/IconLogin.jpg" alt="" class="img-fluid" />
</div>
</div>
<div class="col-lg-5 px-lg-4">

<h2 class="mb-4">Reset Password</h2>

<div class ="form-group mb-4">
<asp:TextBox required= "true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Enter New Password" runat="server" ID="txtPassword" ></asp:TextBox>

    <br />
<asp:TextBox required= "true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Reenter Password" runat="server" ID="txtcfmPassword" ></asp:TextBox>

</div>


<div class="form-group mb-4">

    
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" Text="Label" Visible="False"></asp:Label>

    
</div>
<asp:Button Text="SUBMIT" CssClass="btn btn-primary" Height="50px" Width="400px" runat="server"  ID="submitbtn" OnClick="submitbtn_Click1" />
    </div>



</div>


</div>

</div>
        </div>
    </form>
</body>
</html>
