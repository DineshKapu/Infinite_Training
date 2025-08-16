using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace Electricity_Prj.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var u = ConfigurationManager.AppSettings["AdminUsername"];
            var p = ConfigurationManager.AppSettings["AdminPassword"];

            if (txtUser.Text == u && txtPass.Text == p)
            {
                Session["IsAdmin"] = true;
                Response.Redirect("Billing.aspx");
            }
            else if (txtUser.Text == u)
            {
                lblMsg.Text = "Invalid Password";
                lblMsg.CssClass = "message-label error";

            }
            else if (txtUser.Text == p)
            {
                lblMsg.Text = "Invalid Username";
                lblMsg.CssClass = "message-label error";
            }
            else
            {
                lblMsg.Text = "Invalid Credentials";
                lblMsg.CssClass = "message-label error";
            }
        }
    }
}