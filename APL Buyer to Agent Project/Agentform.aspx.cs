using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace APL_Buyer_to_Agent_Project
{
    public partial class Agentform : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["real_estateConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayMessage();
            }
        }

        private void DisplayMessage()
        {
            if (Session["AdminToAgentMessage"] != null)
            {
                //lblMessage.Text = "Message from Admin:";
                agentMessage.Text = Session["AdminToAgentMessage"].ToString();
                Session["AdminToAgentMessage"] = null;
            }
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            string agentMessageText = agentMessage.Text.Trim();

            if (string.IsNullOrEmpty(agentMessageText))
            {
                return;
            }

            SaveMessageToDatabase("Agent", "Buyer", agentMessageText);
            Session["AgentMessage"] = agentMessageText;
            Response.Redirect("Admin.aspx");
        }

        private void SaveMessageToDatabase(string sender, string receiver, string messageText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO realestate_table (Sender, Receiver, MessageText, IsEdited) VALUES (@Sender, @Receiver, @MessageText, 0)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Sender", sender);
                command.Parameters.AddWithValue("@Receiver", receiver);
                command.Parameters.AddWithValue("@MessageText", messageText);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        protected void btnViewMessages_Click(object sender, EventArgs e)
        {
            DisplayMessages();
        }

        private void DisplayMessages()
        {
            // Define your connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["real_estateConnectionString"].ConnectionString;

            // Define your SQL query to retrieve messages
            string query = "SELECT * FROM realestate_table";

            // Create a new DataTable to store the results
            DataTable dt = new DataTable();

            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a new SqlDataAdapter and execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Fill the DataTable with the results
                adapter.Fill(dt);
            }

            // Bind the DataTable to the GridView
            GridViewMessages.DataSource = dt;
            GridViewMessages.DataBind();

            // Show the GridView
            GridViewMessages.Visible = true;
        }

    }
}
