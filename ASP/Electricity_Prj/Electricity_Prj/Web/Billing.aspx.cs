using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Electricity_Prj.Web.Models;
using Electricity_Prj.Web.Services;
using Electricity_Prj.Web.Utils;
namespace Electricity_Prj.Web
{
    public partial class Billing : System.Web.UI.Page
    {
        private readonly ElectricityBoard board = new ElectricityBoard();
        private readonly BillValidator validator = new BillValidator();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                lblMsg.Text = "";
                lblMsg.CssClass = "message-label";
                lblMsg0.Text = "";
                lblMsg0.CssClass = "message-label";
            }
        }
        protected void btnSetTotal_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTotalBills.Text, out int total) && total > 0)
            {
                Session["TotalBills"] = total;
                Session["RemainingBills"] = total;

                pnlBillForm.Visible = true;
                lblRemaining.Text = $"Remaining Bills: {total}";
                lblMsg.Text = "";
                lblMsg.CssClass = "message-label";
                btnSetTotal.Enabled = false;
                txtTotalBills.Text = " ";
            }
            else
            {
                lblMsg.Text = "Please enter a valid number of bills.";
                lblMsg.CssClass = "message-label error";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["RemainingBills"] == null)
                {
                    lblMsg.Text = "Please set the number of bills first.";
                    lblMsg.CssClass = "message-label error";
                    pnlBillForm.Visible = false;
                    btnSetTotal.Enabled = true;
                    return;
                }

                int remaining = (int)Session["RemainingBills"];
                if (remaining <= 0)
                {
                    lblMsg.Text = "All bills have already been entered.";
                    lblMsg.CssClass = "message-label error";
                    pnlBillForm.Visible = false;
                    btnSetTotal.Enabled = true;
                    txtTotalBills.Text = "";
                    return;
                }

                var eb = new ElectricityBill
                {
                    ConsumerNumber = txtCno.Text.Trim(),
                    ConsumerName = txtCname.Text.Trim()
                };

                if (string.IsNullOrWhiteSpace(eb.ConsumerName))
                {
                    lblMsg.Text = "Consumer name should not be null or empty.";
                    lblMsg.CssClass = "message-label error";
                    return;
                }
                if (eb.ConsumerName.Length < 4)
                {
                    lblMsg.Text = "Consumer name should be greater than or Equal to 4 Characters.";
                    lblMsg.CssClass = "message-label error";
                    eb.ConsumerName = "";
                    return;
                }


                if (!int.TryParse(txtUnits.Text, out int units))
                {
                    lblMsg.Text = "Units must be a valid number.Please Re-Enter";
                    lblMsg.CssClass = "message-label error";
                    txtUnits.Text = "";
                    return;
                }

                string msg = validator.ValidateUnitsConsumed(units);
                if (!string.IsNullOrEmpty(msg))
                {
                    lblMsg.Text = msg;
                    lblMsg.CssClass = "message-label error";
                    return;
                }

                eb.UnitsConsumed = units;
                board.CalculateBill(eb);
                board.AddBill(eb);

                remaining--;
                Session["RemainingBills"] = remaining;

                lblMsg.Text = $"Bill added successfully. Amount: {eb.BillAmount}.";
                lblMsg.CssClass = "message-label success";
                lblRemaining.Text = $"Remaining Bills: {remaining}";

                txtCno.Text = txtCname.Text = txtUnits.Text = "";

                if (remaining == 0)
                {
                    lblMsg.Text += " All bills have been entered.";
                    pnlBillForm.Visible = false;
                    btnSetTotal.Enabled = true;
                    txtTotalBills.Text = "";
                }
            }
            catch (FormatException ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.CssClass = "message-label error";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
                lblMsg.CssClass = "message-label error";
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtN.Text, out int n) && n > 0)
            {
                //gvBills.DataSource = board.Generate_N_BillDetails(n);
                //gvBills.DataBind();
                LoadLastNBills(n);
                lblMsg0.Text = "";
                lblMsg0.CssClass = "message-label";
            }
            else
            {
                lblMsg0.Text = "Please enter a valid N.";
                lblMsg0.CssClass = "message-label error";
            }
        }
        private void LoadLastNBills(int n)
        {
            var bills = board.Generate_N_BillDetails(n);
            gvBills.DataSource = bills;
            gvBills.DataBind();
            if (bills.Count < n)
            {
                lblSummary.Text = $"Only {bills.Count} bill(s) are available in the Database.<br/> Details of last {bills.Count} bill(s):<br/>";
            }
            else
            {
                lblSummary.Text = $"Details of last {bills.Count} bill(s):<br/>";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var i in bills)
            {
                sb.AppendLine($"EB Bill for {i.ConsumerName} is {i.BillAmount} <br/>");
            }
            litDetails.Text = sb.ToString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}