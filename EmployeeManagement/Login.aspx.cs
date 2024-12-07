using System;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ValidateUser", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                string role = Convert.ToString(cmd.ExecuteScalar());

                if (string.IsNullOrEmpty(role))
                {
                    lblMessage.Text = "Invalid username or password!";
                }
                else if (role == "Admin")
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
                else if (role == "Employee")
                {
                    Response.Redirect("EmployeeDashboard.aspx");
                }
            }
        }
    }
}
