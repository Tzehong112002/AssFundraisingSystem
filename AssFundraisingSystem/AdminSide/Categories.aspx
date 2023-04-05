<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/weiyao.css" rel="stylesheet" />
        <div class="title"><h1>Categories</h1> </div>
    <div class="box">
        <table class="fence">
            <tr>
                <th>Category ID</th>
                <th>Category Title</th>
                <th>Status</th>
                <th>Description</th>
                <th>Modified Date</th>    
                <th>Actions</th>
            </tr>
            <tr>
                <td>A001</td>
                <td>Charity Match</td>
                <td>Active</td>
                <td>Donate the register fees from the match.</td>
                <td>3 April 2023</td>
                <td>
                    <asp:LinkButton ID="view" runat="server">VIEW</asp:LinkButton>
                    <asp:LinkButton ID="edit" runat="server">EDIT</asp:LinkButton>
                    <asp:LinkButton ID="delete" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>
             <tr>
                <td>A002</td>
                <td>Food Event</td>
                <td>Active</td>
                <td>Donate food.</td>
                <td>3 April 2023</td>
                   <td>
                    <asp:LinkButton ID="viw" runat="server">VIEW</asp:LinkButton>
                    <asp:LinkButton ID="eit" runat="server">EDIT</asp:LinkButton>
                    <asp:LinkButton ID="deete" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>
             <tr>
                <td>A003</td>
                <td>Old Clothes Event</td>
                <td>Active</td>
                <td>Donate the clothes on the event.</td>
                <td>3 April 2023</td>
                   <td>
                    <asp:LinkButton ID="iew" runat="server">VIEW</asp:LinkButton>
                    <asp:LinkButton ID="dit" runat="server">EDIT</asp:LinkButton>
                    <asp:LinkButton ID="elete" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>

             <tr>
                <td>A004</td>
                <td>Free Haircut Event</td>
                <td>Active</td>
                <td>Provide free hair service.</td>
                <td>3 April 2023</td>
                   <td>
                    <asp:LinkButton ID="vie" runat="server">VIEW</asp:LinkButton>
                    <asp:LinkButton ID="edi" runat="server">EDIT</asp:LinkButton>
                    <asp:LinkButton ID="dele" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>

            <tr>
                <td>A005</td>
                <td>Education Event</td>
                <td>Active</td>
                <td>Provide free education service.</td>
                <td>3 April 2023</td>
                   <td>
                    <asp:LinkButton ID="LinkButton10" runat="server">VIEW</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton11" runat="server">EDIT</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton12" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>
        </table>
        <asp:Button class ="cCate" ID="cCate" runat="server" Text="Create Category" />
        <asp:Button class="refresh" ID="refresh" runat="server" Text="Refresh" />
    </div>
</asp:Content>
