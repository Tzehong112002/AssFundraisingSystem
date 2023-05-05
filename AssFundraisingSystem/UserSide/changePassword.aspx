<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="AssFundraisingSystem.UserSide.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/changePassword.css" rel="stylesheet" />


    <div class="container">

            <h1 class="title">Change Password</h1>
            <div class="message messageerror"></div>
            <div class="input">
                <asp:Label ID="Label1" runat="server" Text="Current Password"></asp:Label>
                <asp:TextBox ID="txtCurrentPassword" class="txtinput" placeholder="Enter current password" runat="server" TextMode="Password"></asp:TextBox>
                <div class="inputerrormessage"></div>
                <asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server" ControlToValidate="txtCurrentPassword"
                    ErrorMessage="Please enter current password" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="input">
                <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
                <asp:TextBox ID="txtNewPassword" class="txtinput" placeholder="Enter new password" runat="server" TextMode="Password"></asp:TextBox>
                <div class="inputerrormessage"></div>
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="Please enter new password" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvRepeatPassword" runat="server" ControlToValidate="txtNewPassword" ControlToCompare="txtRepeatPassword"
                    ErrorMessage="Passwords do not match" Display="Dynamic"></asp:CompareValidator>
                <asp:RegularExpressionValidator ID="rvPassword" runat="server" ControlToValidate="txtNewPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"
                    ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="input">
                <asp:Label ID="Label3" runat="server" Text="Repeat Password"></asp:Label>
                <asp:TextBox ID="txtRepeatPassword" class="txtinput" placeholder="Repeat new password" runat="server" TextMode="Password"></asp:TextBox>
                <div class="inputerrormessage"></div>
                <asp:RequiredFieldValidator ID="rfvRepeatPassword" runat="server" ControlToValidate="txtRepeatPassword"
                    ErrorMessage="Please repeat new password" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvNewPassword" runat="server" ControlToValidate="txtRepeatPassword" ControlToCompare="txtNewPassword"
                    ErrorMessage="Passwords do not match" Display="Dynamic"></asp:CompareValidator>
            </div>


            
           

             <asp:Button ID="btnUpdate"  runat="server" Text="Update Password" class="button" BackColor="Green" OnClick="btnUpdate_Click" />

             <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" CausesValidation="false" />


   </div>






</asp:Content>
