<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="YourProjectNamespace.AddEmployee" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Employee</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add New Employee</h1>
            <label>First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" />
            <br />
            <label>Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" />
            <br />
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" />
            <br />
            <label>Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" />
            <br />
            <label>Job Title:</label>
            <asp:TextBox ID="txtJobTitle" runat="server" />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
