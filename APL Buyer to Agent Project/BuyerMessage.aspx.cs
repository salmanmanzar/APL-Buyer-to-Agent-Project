using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APL_Buyer_to_Agent_Project
{
    public partial class BuyerMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    if (Session["AdminToBuyerMessage"] != null)
                    {
                        lblAdminMessage.Text = Session["AdminToBuyerMessage"].ToString();
                        Session["AdminToBuyerMessage"] = null;
                    }
                    else
                    {
                        lblAdminMessage.Text = "No new messages.";
                    }
                }
            }
        }
    }
}