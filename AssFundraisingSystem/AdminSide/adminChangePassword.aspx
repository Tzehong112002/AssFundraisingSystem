<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="adminChangePassword.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.adminChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/editAdminStyle.css" rel="stylesheet" />
     <div class="container">

            <h1 class="title">Edit Admin Password</h1>
            <div class="message messageerror"></div>



            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Old Password :"></asp:Label>
                <asp:TextBox ID="oldPassword" class="txtinput" placeholder="Enter Old Password" runat="server" TextMode="Password" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>

         

         <div class="input">
               <asp:Label ID="Label1" runat="server" Text="New Password :"></asp:Label>
                <asp:TextBox ID="NewPassword" class="txtinput" placeholder="Enter New Password" runat="server" TextMode="Password" ></asp:TextBox>
                <div class="inputerrormessage"></div>
           </div>

         <div class="input">
               <asp:Label ID="Label2" runat="server" Text="Contact Number :"></asp:Label>
                <asp:TextBox ID="CfmPassword" class="txtinput" placeholder="Enter again the password" runat="server" TextMode="Password" ></asp:TextBox>
                <div class="inputerrormessage"></div>
           </div>

        

             <asp:Button ID="btnUpdateAdmin"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdateAdmin_Click" />

             <asp:Button ID="btnCancel"  runat="server" Text="cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" />

   </div>
</asp:Content>
