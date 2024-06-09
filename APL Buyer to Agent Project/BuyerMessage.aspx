<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyerMessage.aspx.cs" Inherits="APL_Buyer_to_Agent_Project.BuyerMessage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message from Admin to Buyer</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            max-width: 600px;
            margin: 0 auto;
        }
        .message-box {
            width: 100%;
            height: 100px;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Message fromjagfadsljfhasdljf Admin</h1>
        <div>
            <asp:Label ID="lblAdminMessage" runat="server" Text="No new messages"></asp:Label>
        </div>
        <div>
            <asp:HyperLink ID="lnkBackToBuyerForm" runat="server" NavigateUrl="~/Buyerform.aspx">Back to Buyer Form</asp:HyperLink>
        </div>
    </div>
</body>
</html>

