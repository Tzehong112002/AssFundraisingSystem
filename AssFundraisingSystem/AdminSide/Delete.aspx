<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="title"><h1>Delete</h1> </div>
    <p> Are you sure you wan to delete the following record?</p>
     <table>
                <tr>
                    <td>Id: </td>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td>Name: </td>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="" ></asp:Label>
                    </td>
                </tr>      
            </table>
                <br />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

</asp:Content>
