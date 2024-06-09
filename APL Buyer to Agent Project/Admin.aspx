<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="APL_Buyer_to_Agent_Project.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Form</title>
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
            max-width: 600px;
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
        textarea,
        .asp-TextBox {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        input[type="button"],
        input[type="submit"],
        .asp-Button {
            width: 100%;
            padding: 10px;
            background-color: #28a745;
            border: none;
            border-radius: 4px;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
            margin-bottom: 10px;
        }
        input[type="button"]:hover,
        input[type="submit"]:hover,
        .asp-Button:hover {
            background-color: #218838;
        }
        .grid-view {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Admin Form</h1>
        <div class="form-group">
            <label for="adminMessage">Message</label>
            <asp:TextBox ID="adminMessage" runat="server" TextMode="MultiLine" Rows="4" CssClass="asp-TextBox"></asp:TextBox>
        </div>
        <asp:Button ID="btnSendToAgent" runat="server" Text="Send to Agent" OnClick="btnSendToAgent_Click" CssClass="asp-Button" />
        <asp:Button ID="btnSendToBuyer" runat="server" Text="Send to Buyer" OnClick="btnSendToBuyer_Click" CssClass="asp-Button" />
        <asp:Button ID="btnViewMessages" runat="server" Text="View Messages" OnClick="btnViewMessages_Click" CssClass="asp-Button" />
        <div class="grid-view">
            <asp:GridView ID="GridViewMessages" runat="server" AutoGenerateColumns="False" Visible="False" DataKeyNames="Id" OnRowEditing="GridViewMessages_RowEditing" OnRowUpdating="GridViewMessages_RowUpdating" OnRowCancelingEdit="GridViewMessages_RowCancelingEdit" OnRowDeleting="GridViewMessages_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Sender" HeaderText="Sender" />
                    <asp:BoundField DataField="Receiver" HeaderText="Receiver" />
                    <asp:BoundField DataField="MessageText" HeaderText="Message Text" />
                    <asp:BoundField DataField="IsEdited" HeaderText="Edited" />
                    <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
