using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeManagement
{
    public partial class ManageEmployees : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeGrid();
            }
        }

        private void BindEmployeeGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvEmployees.DataSource = dt;
                gvEmployees.DataBind();
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Position", txtPosition.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            txtName.Text = "";
            txtEmail.Text = "";
            txtPosition.Text = "";
            BindEmployeeGrid();
        }

        protected void gvEmployees_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            BindEmployeeGrid();
        }

        protected void gvEmployees_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int employeeID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            string name = (gvEmployees.Rows[e.RowIndex].FindControl("txtEditName") as System.Web.UI.WebControls.TextBox).Text;
            string email = (gvEmployees.Rows[e.RowIndex].FindControl("txtEditEmail") as System.Web.UI.WebControls.TextBox).Text;
            string position = (gvEmployees.Rows[e.RowIndex].FindControl("txtEditPosition") as System.Web.UI.WebControls.TextBox).Text;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Position", position);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            gvEmployees.EditIndex = -1;
            BindEmployeeGrid();
        }

        protected void gvEmployees_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int employeeID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            BindEmployeeGrid();
        }

        protected void gvEmployees_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            BindEmployeeGrid();
        }
    }
}
