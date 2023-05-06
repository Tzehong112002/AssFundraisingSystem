<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error403.aspx.cs" Inherits="AssFundraisingSystem.Error.Error403" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/403Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="scene">
  <div class="overlay"></div>
  <div class="overlay"></div>
  <div class="overlay"></div>
  <div class="overlay"></div>
  <span class="bg-403">403</span>
  <div class="text">
    <span class="hero-text"></span>
    <span class="msg">can't let <span>you</span> in.</span>
    <span class="support">
      <span>unexpected?</span>
      <asp:HyperLink ID="HyperLink1" runat="server"> <a href="../UserSide/Login.aspx" id="">Go Back</a></asp:HyperLink>
    </span>
  </div>
  <div class="lock"></div>
</div>
    </form>
</body>
</html>
