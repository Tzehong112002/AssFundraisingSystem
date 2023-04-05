<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="AssFundraisingSystem.UserSide.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/changePassword.css" rel="stylesheet" />


    <div class="container">

            <h1 class="title">Change Password</h1>
            <div class="message messageerror"></div>
            <div class="input">
                <asp:TextBox ID="TextBox1" class="txtinput" placeholder="Enter your old password" runat="server" TextMode="Password" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>
            <div class="input">
                <asp:TextBox ID="TextBox2" class="txtinput" placeholder="Enter your new password" runat="server" TextMode="Password"></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>
            <div class="input">
                <asp:TextBox ID="TextBox3" class="txtinput" placeholder="Repeat your new password" runat="server" TextMode="Password" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>
           

             <asp:Button ID="btnUpdate"  runat="server" Text="Update Password" class="button" BackColor="Green" OnClick="btnUpdate_Click" />

             <asp:Button ID="btnCancel"  runat="server" Text="cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" />

   </div>






</asp:Content>
