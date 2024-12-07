<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageEmployees.aspx.cs" Inherits="EmployeeManagement.ManageEmployees" %>

<!DOCTYPE html>
<html>
<head>
    <title>Manage Employees</title>
</head>
<body>
    <h2>Manage Employees</h2>
    <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="false" OnRowEditing="gvEmployees_RowEditing"
        OnRowUpdating="gvEmployees_RowUpdating" OnRowDeleting="gvEmployees_RowDeleting" OnRowCancelingEdit="gvEmployees_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Position" HeaderText="Position" />
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <br />
    <h3>Add New Employee</h3>
    <asp:TextBox ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
    <asp:TextBox ID="txtPosition" runat="server" Placeholder="Position"></asp:TextBox>
    <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" OnClick="btnAddEmployee_Click" />
</body>
</html>
