<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="DonationList.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.DonationList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                </td>
                <td>
                    <asp:Label ID="ContactNumberLabel" runat="server" Text='<%# Eval("ContactNumber") %>' />
                </td>
                <td>
                    <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <div class="writingPage">
            <link rel="stylesheet" href="css/dataTable1.css">
            <link rel="stylesheet" href="css/dataTable2.css">

            <div class="title"><h1>Donation History</h1> </div>
                <table id="example" class="table table-striped table-bordered" style="width:100%">
                    <thead>
                        <tr runat="server" style="">
                            <th runat="server">Name</th>
                            <th runat="server">Email</th>
                            <th runat="server">ContactNumber</th>
                            <th runat="server">Amount</th>
                        </tr>
                    </thead>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </div>
        </LayoutTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MYConnectionString %>" SelectCommand="SELECT [Name], [Email], [ContactNumber], [Amount] FROM [Payment]"></asp:SqlDataSource>
    
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap4.min.js"></script>
   
    <script>
        $(document).ready(function () {
            $('#example').DataTable();
        });
    </script>
</asp:Content>
