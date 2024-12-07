using System;
using System.Data;
using System.Data.SqlClient; // For database connection and commands
using System.Configuration; // For ConfigurationManager
using System.Web.UI; // For TextBox and other web controls
using System.Web.UI.WebControls; // For GridView and Button controls


namespace YourProjectNamespace
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("GetEmployees", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvEmployees.DataSource = dt;
                gvEmployees.DataBind();
            }
        }

        protected void btnManageEmployees_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        protected void gvEmployees_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            LoadEmployees();
        }

        protected void gvEmployees_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int employeeID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            string firstName = ((TextBox)gvEmployees.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string lastName = ((TextBox)gvEmployees.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string email = ((TextBox)gvEmployees.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string phoneNumber = ((TextBox)gvEmployees.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string jobTitle = ((TextBox)gvEmployees.Rows[e.RowIndex].Cells[5].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@JobTitle", jobTitle);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void gvEmployees_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int employeeID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadEmployees();
        }

        protected void gvEmployees_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }
    }
}
