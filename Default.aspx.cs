using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if(Session["UserKey"] != null)
            {
                pnlWelcome.Visible = false;
                pnlHome.Visible = true;

                Model.Userr u = Model.UserDb.GetUserById(Session["UserKey"]);

                Master.LabelOnMasterPage.Text = u.FullName;

                if (u.UserType == 1)
                {
                    pnlPassanger.Visible = true;
                    pnlDriver.Visible = false;

                    rptUpcomingRides.DataSource = Model.RideDb.GetUpcomingRides(u.Id);
                    rptUpcomingRides.DataBind();

                    rptRecentRides.DataSource = Model.RideDb.GetRecentRides(u.Id);
                    rptRecentRides.DataBind(); 
                }
                else
                {
                    pnlDriver.Visible = true;
                    pnlPassanger.Visible = false;

                    lblDriverName.Text = u.FullName;
                    lblRides.Text = Model.RideDb.CountRide(u.Id).ToString();
                    lblIncome.Text = Model.RideDb.CalculateTotalIncome(u.Id).ToString();

                    rptDriverUpcomingRides.DataSource = Model.RideDb.GetUpcomingRidesDriver(u.Id);
                    rptDriverUpcomingRides.DataBind();
                }       
            }
            else
            {
                pnlWelcome.Visible = true;
                pnlHome.Visible = false;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Model.Userr u = new Model.Userr()
            {
                Username = txtUserName.Text.Trim(),
                Password = Library.Tools.MD5yapUTF8(txtPassword.Text.Trim()),
            };

            Model.Userr user = Model.UserDb.GetUser(u);

            if(user != null)
            {
                Session["UserKey"] = user.Id.ToString();
                Response.Redirect("Default.aspx");
            }  
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchResults.aspx?city="+txtSearch.Text.Trim());
        }
    }
}