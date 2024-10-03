<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUI.aspx.cs" Inherits="EchannelingSystem.View.TestUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript" src="https://www.payhere.lk/lib/payhere.js"></script>
        <button type="submit" id="payhere-payment">PayHere Pay</button>
        <script>
            // Payment completed. It can be a successful failure.
            payhere.onCompleted = function onCompleted(orderId) {
                console.log("Payment completed. OrderID:" + orderId);
                // Note: validate the payment and show success or failure page to the customer
            };

            // Payment window closed
            payhere.onDismissed = function onDismissed() {
                // Note: Prompt user to pay again or show an error page
                console.log("Payment dismissed");
            };

            // Error occurred
            payhere.onError = function onError(error) {
                // Note: show an error page
                console.log("Error:" + error);
            };

            // Put the payment variables here
            var payment = {
                "sandbox": true,
                "merchant_id": "1227884",    // Replace your Merchant ID
                "return_url": "http://localhost:50205/View/AppointmentUI.aspx",     // Important
                "cancel_url": "http://localhost:50205/View/AppointmentUI.aspx",     // Important
                "notify_url": "http://sample.com/notify",
                "order_id": "ItemNo12345",
                "items": "Door bell wireles",
                "amount": "1000.00",
                "currency": "LKR",
                "hash": to_upper_case(md5("1227884" + "ItemNo12345" + "1000.00" + "LKR" + to_upper_case(md5('MTA3ODk1MDM3NTI5MjA1NTMyNjcyNTA1NzY2NDU0MjYyOTE1MTAwMw==')))), // *Replace with generated hash retrieved from backend
                "first_name": "Saman",
                "last_name": "Perera",
                "email": "samanp@gmail.com",
                "phone": "0771234567",
                "address": "No.1, Galle Road",
                "city": "Colombo",
                "country": "Sri Lanka",
                "delivery_address": "No. 46, Galle road, Kalutara South",
                "delivery_city": "Kalutara",
                "delivery_country": "Sri Lanka",
                "custom_1": "",
                "custom_2": ""
            };

            // Show the payhere.js popup, when "PayHere Pay" is clicked
            document.getElementById('payhere-payment').onclick = function (e) {
                payhere.startPayment(payment);
            };
        </script>
    </form>
</body>
</html>
