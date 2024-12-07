<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="YourProjectNamespace.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Admin Dashboard</h1>
            <asp:Button ID="btnManageEmployees" runat="server" Text="Manage Employees" OnClick="btnManageEmployees_Click" />

        </div>
        <div>
            <!-- Employee Management Table -->
            <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID" OnRowEditing="gvEmployees_RowEditing" OnRowUpdating="gvEmployees_RowUpdating" OnRowDeleting="gvEmployees_RowDeleting" OnRowCancelingEdit="gvEmployees_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="EmployeeID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="JobTitle" HeaderText="Job Title" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnAddNewEmployee" runat="server" Text="Add New Employee" OnClick="btnAddNewEmployee_Click" />
        </div>
    </form>
</body>
</html>
