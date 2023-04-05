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
            <div class="number">50</div>
            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from yesterday</span>
            </div>
          </div>
          <i class='bx bx-cart-alt cart'></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total User</div>
            <div class="number">1000</div>
            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from yesterday</span>
            </div>
          </div>
          <i class='bx bxs-cart-add cart two' ></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Donation</div>
            <div class="number">RM12,876</div>
            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from yesterday</span>
            </div>
          </div>
          <i class='bx bx-cart cart three' ></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Categories</div>
            <div class="number">10</div>
            <div class="indicator">
              <i class='bx bx-down-arrow-alt down'></i>
              <span class="text">Down From Today</span>
            </div>
          </div>
          <i class='bx bxs-cart-download cart four' ></i>
        </div>
      </div>

      <div class="sales-boxes">
        <div class="recent-sales box">
          <div class="title">Recent Donation</div>
          <div class="sales-details">
            <ul class="details">
              <li class="topic">Date</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>
              <li>>02 Jan 2023</li>


            </ul>
            <ul class="details">
            <li class="topic">User</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>
            <li>Peter</li>

          </ul>
          <ul class="details">
            <li class="topic">Event</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>
            <li>Animal recuise</li>

          </ul>
          <ul class="details">
            <li class="topic">Donation</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
            <li>RM50.00</li>
 
          </ul>
          </div>

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
