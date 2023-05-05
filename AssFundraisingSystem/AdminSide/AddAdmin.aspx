<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.AddAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/AddAdminStyle.css" rel="stylesheet" />
     <div class="container">

            <h1 class="title">Add Admin</h1>
            <div class="message messageerror"></div>

         <div class="input">
            <span id="lblPicture">Profile Picture:</span>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <div class="inputerrormessage"></div>
        </div>

        <div class="input">
            <asp:Label ID="Label4" runat="server" Text="Admin Name :"></asp:Label>
            <asp:TextBox ID="TextBox1" class="txtinput" placeholder="Enter Admin Name" runat="server"></asp:TextBox>
            <div class="inputerrormessage"></div>
            <asp:RequiredFieldValidator ID="rfvAdminName" runat="server" ControlToValidate="TextBox1" 
                ErrorMessage="Please enter Admin Name" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="input">
            <asp:Label ID="Label7" runat="server" Text="UserName :"></asp:Label>
            <asp:TextBox ID="TextBox4" class="txtinput" placeholder="Enter Username" runat="server"></asp:TextBox>
            <div class="inputerrormessage"></div>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="TextBox4" 
                ErrorMessage="Please enter Username" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>


         <div class="input">
            <asp:Label ID="Label1" runat="server" Text="Contact Number :"></asp:Label>
            <asp:TextBox ID="TextBox5" class="txtinput" placeholder="Enter Contact Number" runat="server"></asp:TextBox>
            <div class="inputerrormessage"></div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox5"
                ErrorMessage="Contact number is required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"
                ErrorMessage="Contact number must be 10-11 digits" ValidationExpression="^\d{10,11}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>

        <div class="input">
            <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
            <asp:TextBox ID="TextBox2" class="txtinput" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
            <div class="inputerrormessage"></div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                ErrorMessage="Password is required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2"
                ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number"
                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>

        <div class="input">
            <asp:Label ID="Label3" runat="server" Text="Enter again the Password"></asp:Label>
            <asp:TextBox ID="TextBox3" class="txtinput" placeholder="Enter again the Password" runat="server" TextMode="Password"></asp:TextBox>
            <div class="inputerrormessage"></div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                ErrorMessage="Please enter the password again" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3"
                ErrorMessage="Passwords do not match" Display="Dynamic"></asp:CompareValidator>
        </div>


         


             <asp:Button ID="btnUpdate"  runat="server" Text="Add Admin" class="button" BackColor="Green" OnClick="btnUpdate_Click" />

             <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" CausesValidation="false" />


   </div>

</asp:Content>
