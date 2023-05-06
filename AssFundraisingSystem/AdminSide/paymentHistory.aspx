<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="paymentHistory.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.paymentHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="css/dataTable1.css">
    <link rel="stylesheet" href="css/dataTable2.css">
    <link href="css/adminNav.css" rel="stylesheet" />
    <link href="css/formBtn.css" rel="stylesheet" />

    <div class="writingPage">
    <div class="title"><h1>Payment History</h1> </div>
    <asp:GridView ID="paymentListForm" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" style="width:100%" ClientIDMode="Static">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="ContactNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField="PaymentStatus" HeaderText="Status" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="paymentUpdate" CssClass="formUpdateBtn" Text="Update" NavigateUrl='<%# "updatePayment.aspx?id=" + HttpUtility.UrlEncode(Eval("PaymentID").ToString())%>'></asp:HyperLink>
                    <asp:HyperLink runat="server" ID="paymentDelete" CssClass="formDeleteBtn" Text="Delete" NavigateUrl='<%# "deletePayment.aspx?id=" + HttpUtility.UrlEncode(Eval("PaymentID").ToString())%>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=paymentListForm]").DataTable(
                {
                    bLengthChange: true,
                    bFilter: true,
                    bSort: true,
                    bPaginate: true
                });
        });
    </script>
</asp:Content>
