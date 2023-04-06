<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="AssFundraisingSystem.UserSide.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Payment.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/ExtraPayment.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div class=" page-holder d-flex align-items-center">
<div class="container">
<div class="row align-items-center py-5">
<div class="col-5 col-lg-7 mx-auto mb-5 mb-lg-0">

<div class="pr-lg-5">
<img src="Img/download.png" />
</div>
</div>
<div class="col-lg-5 px-lg-4">
<h1 class="text-base text-primary text-uppercase mb-4">DONATION FORM</h1>
<h2 class="mb-4">Please fill in your personal information</h2>

<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Name" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email Address" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="IC Number" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Contact Number" runat="server" ></asp:TextBox>

</div>
<div class ="form-group mb-4">
<asp:TextBox required= "true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Donation Amount" runat="server" ></asp:TextBox>

</div>

<div class ="form-group mb-4">
    

</div>


<asp:Button Text="Submit" CssClass="btn btn-primary" Height="50px" Width="400px" runat="server" OnClick="Unnamed7_Click" />


</div>
</div>


</div>
</div>


</form>
</body>
</html>
