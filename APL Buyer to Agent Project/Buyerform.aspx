<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buyerform.aspx.cs" Inherits="APL_Buyer_to_Agent_Project.Buyerform" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buyer Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        form {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
        }
        h1 {
            margin-bottom: 20px;
            font-size: 24px;
            color: #333;
            text-align: center;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        input[type="text"],
        textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        input[type="button"],
        input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #28a745;
            border: none;
            border-radius: 4px;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        input[type="button"]:hover,
        input[type="submit"]:hover {
            background-color: #218838;
        }
        .grid-view {
            margin-top: 20px;
        }
        .grid-view table {
            width: 100%;
            border-collapse: collapse;
        }
        .grid-view th,
        .grid-view td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: left;
        }
        .grid-view th {
            background-color: #f8f8f8;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Buyer Form</h1>
        <div class="form-group">
            <label for="buyerMessage">Message</label>
            
            <asp:TextBox ID="buyerMessage" runat="server" OnTextChanged="buyerMessage_TextChanged"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" OnClick="btnSendMessage_Click" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnViewMessages" runat="server" Text="View Messages" OnClick="btnViewMessages_Click" />
        </div>
        <div class="grid-view">
            <asp:GridView ID="GridViewMessages" runat="server" Visible="False">
                <Columns>
                    <asp:BoundField DataField="MessageText" HeaderText="Message" />
                    <asp:BoundField DataField="Sender" HeaderText="Sender" />
                    <asp:BoundField DataField="Receiver" HeaderText="Receiver" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
