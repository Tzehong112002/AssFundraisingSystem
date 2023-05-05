<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="adminChangePassword.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.adminChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/editAdminStyle.css" rel="stylesheet" />
     <div class="container">

            <h1 class="title">Edit Admin Password</h1>
            <div class="message messageerror"></div>



            <div class="input">
                <asp:Label ID="Label4" runat="server" Text="Old Password :"></asp:Label>
                <asp:TextBox ID="oldPassword" class="txtinput" placeholder="Enter Old Password" runat="server" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldPassword" ErrorMessage="Please enter the old password"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>
         
            <div class="input">
                <asp:Label ID="Label1" runat="server" Text="New Password :"></asp:Label>
                <asp:TextBox ID="NewPassword" class="txtinput" placeholder="Enter New Password" runat="server" TextMode="Password" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NewPassword" ErrorMessage="Please enter the new password"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
                <asp:RequiredFieldValidator ID="NewPasswordRequiredFieldValidator" runat="server" ControlToValidate="NewPassword" ErrorMessage="Please enter a new password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="NewPasswordRegularExpressionValidator" runat="server" ControlToValidate="NewPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$" ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>

            <div class="input">
                <asp:Label ID="Label2" runat="server" Text="Confirm Password :"></asp:Label>
                <asp:TextBox ID="CfmPassword" class="txtinput" placeholder="Enter again the password" runat="server" TextMode="Password" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CfmPassword" ErrorMessage="Please confirm the password you have entered"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
                <asp:RequiredFieldValidator ID="CfmPasswordRequiredFieldValidator" runat="server" ControlToValidate="CfmPassword" ErrorMessage="Please confirm your new password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CfmPasswordCompareValidator" runat="server" ControlToValidate="CfmPassword" ControlToCompare="NewPassword" ErrorMessage="Passwords do not match" Display="Dynamic"></asp:CompareValidator>
            </div>


        

             <asp:Button ID="btnUpdateAdmin"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdateAdmin_Click" />

<<<<<<< HEAD
             <asp:Button ID="btnCancel"  runat="server" Text="cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" CausesValidation="false"/>
=======
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" CssClass="button" BackColor="Red" OnClick="btnCancel_Click" />
>>>>>>> 16f016919bdb28cca9f901d35af24fb6a5343fb5

   </div>
</asp:Content>
