<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="AssFundraisingSystem.UserSide.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/Payment.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/ExtraPayment.css" rel="stylesheet" />

<div class="donationForm">
<div class=" page-holder d-flex align-items-center">
<div class="container">
<div class="row align-items-center py-5">
<div class="col-5 col-lg-6 mx-auto mb-5 mb-lg-0">

<div>
    <img src="Img/donationIcon.png" class="donateFormImg" />
</div>
</div>
<div class="col-lg-6 px-lg-4">
<h1 class="text-base text-primary text-uppercase mb-4">DONATION FORM</h1>
<h2 class="mb-4">Please fill in your personal information</h2>

<div class ="form-group mb-4">
    <asp:TextBox ID="txtName" required= "true" CssClass="form-control shadow form-control-lg text-base" placeholder="Name" runat="server" ></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="No Allow Special Character" ValidationExpression="[a-zA-Z\s()\-]*$" ForeColor="Red" ControlToValidate="txtName"></asp:RegularExpressionValidator>
</div>
<div class ="form-group mb-4">
    <asp:TextBox ID="txtEmail" required= "true" CssClass="form-control shadow form-control-lg text-base" placeholder="Email Address" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Proper Email Address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
</div>
<div class ="form-group mb-4">
    <asp:TextBox ID="txtIC" required= "true" CssClass="form-control shadow form-control-lg text-base" placeholder="IC Number" runat="server" ></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="IC Number format incorrect" ValidationExpression="(([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01]))([0-9]{2})([0-9]{4})" ForeColor="Red" ControlToValidate="txtIC"></asp:RegularExpressionValidator>
</div>
<div class ="form-group mb-4">
    <asp:TextBox ID="txtContact" required= "true" CssClass="form-control shadow form-control-lg text-base" placeholder="Contact Number" runat="server" ></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please Enter 01XXXXXXXX" ValidationExpression="01\d\d{7,8}" ForeColor="Red" ControlToValidate="txtContact"></asp:RegularExpressionValidator>
</div>
<div class ="form-group mb-4">
    <asp:TextBox ID="txtAmount" required= "true" CssClass="form-control shadow form-control-lg text-base" placeholder="Donation Amount (0.00)" runat="server" ></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Please Enter 0.00" ValidationExpression="^\d{1,5}\.\d{0,2}$" ForeColor="Red" ControlToValidate="txtAmount"></asp:RegularExpressionValidator>
</div>

<div class ="form-group mb-4">
    

</div>


<asp:Button Text="Pay" CssClass="btn btn-primary" Height="50px" Width="100%" runat="server" OnClick="Pay_Click" />


</div>
</div>


</div>
</div>
</div>
</asp:Content>
