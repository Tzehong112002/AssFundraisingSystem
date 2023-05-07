<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.AddAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/AddAdminStyle.css" rel="stylesheet" />
     <div class="container">

            <h1 class="title">Add Admin</h1>
            <div class="message messageerror"></div>

         <div class="input">
                <span id="lblPicture">Profile Picture:</span>
                <asp:FileUpload ID="FileUpload1" runat="server" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please upload the profile picture"></asp:RequiredFieldValidator>
&nbsp;<div class="inputerrormessage"></div>
            </div>

            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Admin Name :"></asp:Label>
                <asp:TextBox ID="TextBox1" class="txtinput" placeholder="Enter Admin Name" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter an admin name"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

         <div class="input">
               <asp:Label ID="Label7" runat="server" Text="UserName :"></asp:Label>
                <asp:TextBox ID="TextBox4" class="txtinput" placeholder="Enter Username" runat="server" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please enter an username"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

         <div class="input">
               <asp:Label ID="Label1" runat="server" Text="Contact Number :"></asp:Label>
                <asp:TextBox ID="TextBox5" class="txtinput" placeholder="Enter Contact Number" runat="server" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="Please enter the contact number"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"
                ErrorMessage="Contact number must be 10-11 digits" ValidationExpression="^\d{10,11}$" Display="Dynamic"></asp:RegularExpressionValidator>
                <div class="inputerrormessage"></div>
            </div>
         <div class="input">
               <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
                <asp:TextBox ID="TextBox2" class="txtinput" placeholder="Enter Password" runat="server" TextMode="Password" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please enter an password"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="NewPasswordRegularExpressionValidator" runat="server" ControlToValidate="TextBox2" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$" ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number" Display="Dynamic"></asp:RegularExpressionValidator>
                <div class="inputerrormessage"></div>
            </div>
         <div class="input">
               <asp:Label ID="Label3" runat="server" Text="Enter again the Password"></asp:Label>
                <asp:TextBox ID="TextBox3" class="txtinput" placeholder="Enter again the Password" runat="server" TextMode="Password" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please confirm your password"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CfmPasswordCompareValidator" runat="server" ControlToValidate="TextBox3" ControlToCompare="TextBox2" ErrorMessage="Passwords do not match" Display="Dynamic"></asp:CompareValidator>
                <div class="inputerrormessage"></div>
            </div>

         


             <asp:Button ID="btnUpdate"  runat="server" Text="Add Admin" class="button" BackColor="Green" OnClick="btnUpdate_Click" />


             <asp:Button ID="btnCancel"  runat="server" Text="cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" CausesValidation="false"/>




   </div>

</asp:Content>
