<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="deletePayment.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.deletePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/bupdate.css" rel="stylesheet" />
    <link href="css/formBtn.css" rel="stylesheet" />
    <div class="title"><h1>Delete Payment History</h1> </div>

    <div class ="container">

        <p> Are you sure you wan to delete the following payment history?</p>
     <table>
                <tr>
                    <td class="formRow">Id: </td>
                    <td class="formRow">
                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td class="formRow">Name: </td>
                    <td class="formRow">
                        <asp:Label ID="lblName" runat="server" Text="" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formRow"></td>
                    <td class="formRow">
                        <asp:Button ID="btnDelete" CssClass="btnBan" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        
                        <asp:Button ID="btnCancel" CssClass="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
                
    </div>
</asp:Content>
