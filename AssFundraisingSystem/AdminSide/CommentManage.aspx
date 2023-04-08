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
        

        <asp:Repeater ID="commentRepeater" runat="server" >
            <ItemTemplate>
        
                <tr>
                    <td data-label="CommentID" style="height: 32px"><%# Eval("CommentID") %></td>
                    <td data-label="Username" colspan="2" style="height: 32px"><%# Eval("Username") %></td>
                    <td data-label="CommentContent" colspan="4" style="height: 32px"><%# Eval("CommentContent") %></td>
                    <td data-label="CommentTime" colspan="2" style="height: 32px"><%# Eval("DateCommented") %></td>
                    <td data-label="btnCommentManage" style="height: 32px" colspan="2">
                        <asp:HyperLink ID="btnEditComment" CssClass="button "  runat="server" BackColor="Green" width="80px" NavigateUrl='<%# Eval("CommentID","CommentEdit.aspx?CommentID={0}&EventID=" + Eval("EventID")) %>'>Edit</asp:HyperLink>
                        <asp:Button ID="btnDelComment" runat="server" CssClass="buttonDelete " Text="Delete" BackColor="Red" width="80px" OnClick="btnDelComment_Click" CommandArgument='<%#Eval("CommentID") %>' OnClientClick="return confirm('Do you want to delete this comment?');" />
                    </td>
                </tr>


                </ItemTemplate>
        </asp:Repeater>


             
  </tbody>
 </table>


</asp:Content>
