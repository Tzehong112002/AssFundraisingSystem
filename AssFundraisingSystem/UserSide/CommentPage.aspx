<%@ Page Title="Comment" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CommentPage.aspx.cs" Inherits="AssFundraisingSystem.UserSide.CommentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

    <link href="css/becomeOrganizationStyle.css" rel="stylesheet" />

    <div class="container">

            <h1 class="title"> Comment </h1>
            <div class="message messageerror"></div>
            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Share your word of support! :"></asp:Label>
                <asp:TextBox ID="txtComment" class="txtinput" placeholder="Comment" runat="server" Rows="8" TextMode="MultiLine" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>   

             <asp:Button ID="btnSubmit"  runat="server" Text="Submit" class="button" BackColor="Green" OnClick="btnSubmit_Click"/>
            <asp:Button ID="btnCancel"  runat="server" Text="Cancel" class="button" BackColor="Red"/>


   </div>


</asp:Content>
