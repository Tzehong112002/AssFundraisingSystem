<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="AssFundraisingSystem.UserSide.invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/invoice.css" rel="stylesheet" />
    <div class="text-center">
        <div class="container" id="container1">
            <asp:Image ID="Image1" runat="server" ImageUrl="invoice.png" CssClass="invoiceImg" />

            <asp:Panel ID="Panel1" runat="server" CssClass="panelBox">
                <table class="invoice1">
                    <tr>
                        <td class="auto-style2">Invoice</td>
                    </tr>
                    <tr>
                        <td class="invoice3">
                            <br />
                            <asp:Label ID="lbl1" runat="server" Text="Name : " Font-Bold="True"></asp:Label>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lbl2" runat="server" Text="Donation Date : " Font-Bold="true"></asp:Label>
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lbl6" runat="server" Text="Donation Time : " Font-Bold="true"></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" Width="100%" BorderColor="#CCCCCC" CellPadding="10" ForeColor="Black" GridLines="Horizontal" ShowFooter="True" BorderStyle="None" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="No." HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Donate Event" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEvent" runat="server" Text='Donation Event'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total Amount:
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Donate Amount" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblamt" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" CssClass="footer-grid" />
                                <HeaderStyle BackColor="#CCB323" Font-Bold="True" ForeColor="Black" BorderColor="#CCB323" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </td>
                    </tr>

                    <tr class="footerText">
                        <td>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="Thank You" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr class="footerText">
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="If you have any question, feel free to contact us."></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
    <asp:LinkButton ID="downloadbtn" runat="server" CssClass="lnkbtn" OnClick="DownloadBtn_Click">Download Invoice</asp:LinkButton>
    <br />
    <asp:Button ID="backbtn" class="btn" runat="server" Text="Back to Event Page" OnClick="BackBtn_Click" CssClass="backBtn" />



</asp:Content>
