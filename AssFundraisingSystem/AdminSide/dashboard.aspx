<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/dashboardStyle.css" rel="stylesheet" />

    <div class="title">

        <h1 style="margin:0px;">Dashboard</h1> 
    </div>

    <div class="home-content">
      <div class="overview-boxes">
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Event</div>
              <asp:Label ID="totalEvent" runat="server" Text="Label" class="number"></asp:Label>

            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from yesterday</span>
            </div>
          </div>
          <i class='bx bx-cart-alt cart'></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total User Account</div>
              <asp:Label ID="totalUser" runat="server" Text="Label" class="number"></asp:Label>
            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from yesterday</span>
            </div>
          </div>
          <i class='bx bxs-cart-add cart two' ></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Donation </div>
            <asp:Label ID="totalDonationLabel" runat="server"  class="number"></asp:Label>
            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from Just Now</span>
            </div>
          </div>
          <i class='bx bx-cart cart three' ></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Visitor</div>
            <asp:Label ID="ttlVisitor" runat="server" Text="50" class="number"></asp:Label>
            <div class="indicator">
              <i class='bx bx-down-arrow-alt down'></i>
              <span class="text">Up From Just Now</span>
            </div>
          </div>
          <i class='bx bxs-cart-download cart four' ></i>
        </div>
      </div>

      <div class="sales-boxes">
        <div class="top-sales box">
          <div class="title">Event</div>
          <ul class="top-sales-details">
            <li>
            <a href="#">
              <img src="../Images/dgorescue.jpg" alt="">
              <span class="product">Animal recuise</span>
            </a>
            <span class="price">RM1107</span>
          </li>


          </ul>
        </div>
        <div class="top-sales box">
          <div class="title">Event</div>
          <ul class="top-sales-details">
            <li>
            <a href="#">
              <img src="../Images/dgorescue.jpg" alt="">
              <span class="product">Animal recuise</span>
            </a>
            <span class="price">RM1107</span>
          </li>


          </ul>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
