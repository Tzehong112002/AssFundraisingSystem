<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="donationPayment.aspx.cs" Inherits="AssFundraisingSystem.UserSide.donationPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="callCheckout()">
    <script src="https://js.stripe.com/v3/"></script>
    <script type="text/javascript">

        var stripe = Stripe('pk_test_51MtAsHEIZcNmG8ht1SQIbsjozPjgF7GQwbtSM4GeTlUGsRWiNQiW9dWG2cziey7CkHqDREmXLoKRD1LzIuowFiRF00T83YS7be');

            function callCheckout() {

                stripe.redirectToCheckout({
                    //Make the id field from the Checkout session creation API response
                    //Available to this file, so you can provide it as parameter here
                    //Instead of the {{CHECKOUT_SESSION_ID}} placeholder.

                    sessionId: '<%= sessionId%>'
                }).then(function (result) {
                    //If `redirectToCheckout` fails due to a browser or network
                    //Error, display the localized error message to your customer
                    //Using `result.error.message`.
                })
            }
    </script>
</body>
</html>
