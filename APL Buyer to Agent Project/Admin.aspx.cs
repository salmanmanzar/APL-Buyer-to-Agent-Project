using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APL_Buyer_to_Agent_Project
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayMessage();
            }
        }

        private void DisplayMessage()
        {
            if (Session["BuyerMessage"] != null)
            {
                adminMessage.Text = Session["BuyerMessage"].ToString();
                btnSendToAgent.Visible = true;
                btnSendToBuyer.Visible = false;
            }
            else if (Session["AgentMessage"] != null)
            {
                adminMessage.Text = Session["AgentMessage"].ToString();
                btnSendToAgent.Visible = false;
                btnSendToBuyer.Visible = true;
            }
        }

        protected void btnSendToAgent_Click(object sender, EventArgs e)
        {
            string adminMessageText = adminMessage.Text.Trim();
            if (string.IsNullOrEmpty(adminMessageText))
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["real_estateConnectionString"].ConnectionString))
            {
                string query = "INSERT INTO realestate_table (Sender, Receiver, MessageText, IsEdited) VALUES (@Sender, @Receiver, @MessageText, 0)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Sender", "Admin");
                command.Parameters.AddWithValue("@Receiver", "Agent");
                command.Parameters.AddWithValue("@MessageText", adminMessageText);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Session["BuyerMessage"] = null;
            Response.Redirect("Agentform.aspx");
        }

        protected void btnSendToBuyer_Click(object sender, EventArgs e)
        {
            string adminMessageText = adminMessage.Text.Trim();
            if (string.IsNullOrEmpty(adminMessageText))
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["real_estateConnectionString"].ConnectionString))
            {
                string query = "INSERT INTO realestate_table (Sender, Receiver, MessageText, IsEdited) VALUES (@Sender, @Receiver, @MessageText, 0)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Sender", "Admin");
                command.Parameters.AddWithValue("@Receiver", "Buyer");
                command.Parameters.AddWithValue("@MessageText", adminMessageText);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Session["AgentMessage"] = null;
            Response.Redirect("Buyerform.aspx");
        }

        protected void btnViewMessages_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["real_estateConnectionString"].ConnectionString))
            {
                string query = "SELECT * FROM realestate_table";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridViewMessages.DataSource = dt;
                GridViewMessages.DataBind();
                GridViewMessages.Visible = true;
            }
        }

        protected void GridViewMessages_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewMessages.EditIndex = e.NewEditIndex;
            btnViewMessages_Click(sender, e); // Refresh the grid
        }

        protected void GridViewMessages_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int messageId = Convert.ToInt32(GridViewMessages.DataKeys[e.RowIndex].Value);
            string newMessageText = ((TextBox)GridViewMessages.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["real_estateConnectionString"].ConnectionString))
            {
                string query = "UPDATE realestate_table SET MessageText = @MessageText, IsEdited = 1 WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MessageText", newMessageText);
                command.Parameters.AddWithValue("@Id", messageId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            GridViewMessages.EditIndex = -1;
            btnViewMessages_Click(sender, e); // Refresh the grid
        }

        protected void GridViewMessages_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewMessages.EditIndex = -1;
            btnViewMessages_Click(sender, e); // Refresh the grid
        }

        protected void GridViewMessages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int messageId = Convert.ToInt32(GridViewMessages.DataKeys[e.RowIndex].Value);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["real_estateConnectionString"].ConnectionString))
            {
                string query = "DELETE FROM realestate_table WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", messageId);

                connection.Open();
                command.ExecuteNonQuery();
            }
            btnViewMessages_Click(sender, e); // Refresh the grid
        }
    }
}