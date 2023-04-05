<%@ Page Title="Manage Comment" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="CommentManage.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.CommentManage" %>
<asp:Content ID="CommentManage" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/EventLListStyle.css" rel="stylesheet" />

        <div class="title">
        <h1 style="margin:0px;">Comments Manage</h1> 


    </div>
    <table class="product-table">
      <thead>
      <tr>
        <th scope="col">Comment ID</th>
        <th scope="col" colspan="2">User</th>
        <th scope="col" colspan="4">Content</th>
        <th scope="col" colspan="2">Time Commented</th>
        <th scope="col" colspan="2">Button</th>
      </tr>
    </thead>

    <tbody>
        <tr>
            <td data-label="CommentID" style="height: 32px">1</td>
            <td data-label="Username" colspan="2" style="height: 32px">Alex</td>
            <td data-label="CommentContent" colspan="4" style="height: 32px">This event will help a lot of people, keep it up!</td>
            <td data-label="CommentTime" colspan="2" style="height: 32px">3/3/2023 3:14 P.M.</td>
            <td data-label="btnCommentManage" style="height: 32px" colspan="2">
                    <asp:Button ID="btnEditComment" runat="server" Text="Edit" CssClass="button" BackColor="Green" width="80px" OnClick="btnEditComment_Click"/>
                    <asp:Button ID="btnDelComment" runat="server" CssClass="buttonDelete " Text="Delete" BackColor="Red" width="80px" OnClick="btnDelComment_Click"/>
            </td>
        </tr> 
  </tbody>
 </table>


</asp:Content>
