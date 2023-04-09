<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="Ban.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.Ban" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/BUpdate.css" rel="stylesheet" />
<div class="title"><h1>Update Account</h1> </div>
    <p> Are you sure you wan to update the following account?</p>
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
                <tr>
                    <td>Ban: </td>
                    <td>
                        <asp:RadioButtonList ID="banStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Yes" Selected="True">Ban</asp:ListItem>
                                <asp:ListItem Value="No">Unban</asp:ListItem>
                            </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
                <br />
            <asp:Button ID="btnBan" runat="server" Text="Ban" OnClick="btnBan_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
</asp:Content>
