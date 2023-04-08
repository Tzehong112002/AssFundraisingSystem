<%@ Page Title="Edit Comment" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="CommentEdit.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.CommentEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/editProgramStyle.css" rel="stylesheet" />
             <div class="container">

            <h1 class="title">Edit Comment</h1>
            <div class="message messageerror"></div>
         <div class="input">
             <asp:Label ID="Label2" runat="server" Text="Time Commented :"></asp:Label>
             <asp:Calendar ID="Calendar1" runat="server" DateFormat="MM/dd/yyyy hh:mm:ss"></asp:Calendar>
         </div>

            <div class="input">
                <asp:Label ID="Label3" runat="server" Text="Comment Content :"></asp:Label>
                <asp:TextBox ID="txtComment" class="txtinput" placeholder="Enter  comment content" runat="server" Height="250px" TextMode="MultiLine" ></asp:TextBox>
            </div>

             <asp:Button ID="btnUpdate"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdate_Click" />
             <asp:Button ID="btnCancel"  runat="server" Text="Cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" />

   </div>



</asp:Content>
