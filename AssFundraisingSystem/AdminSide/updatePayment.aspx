<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="updatePayment.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.updatePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/bupdate.css" rel="stylesheet" />
    <link href="css/formBtn.css" rel="stylesheet" />
    <div class="title"><h1>Update Payment Status</h1> </div>

    <div class ="container">

        <p> Are you sure you wan to update the following payment status?</p>
     <table>
                <tr>
                    <td class="formRow">Id: </td>
                    <td class="formRow">
                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                 <tr class="formRow">
                    <td class="formRow">Name: </td>
                    <td class="formRow">
                        <asp:Label ID="lblName" runat="server" Text="" ></asp:Label>
                    </td>
                </tr>
                <tr class="formRow">
                    <td class="formRow">Payment Status: </td>
                    <td class="formRow">
                        <asp:RadioButtonList ID="paymentStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Paid" Selected="True">Paid</asp:ListItem>
                                <asp:ListItem Value="Unpaid">Unpaid</asp:ListItem>
                            </asp:RadioButtonList>
                    </td>
                </tr>
                <tr class="formRow">
                    <td class="formRow"></td>
                    <td class="formRow">
                        <asp:Button ID="btnUpdate" CssClass="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        
                        <asp:Button ID="btnCancel" CssClass="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
                
    </div>
</asp:Content>
