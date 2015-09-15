using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Cancel : System.Web.UI.Page
    {
        Model.Userr u;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserKey"] != null)
            {
                u = Model.UserDb.GetUserById(Session["UserKey"]);
                Master.LabelOnMasterPage.Text = u.FullName;
                // If the userType is not Passenger, redirect to main page.
                if (u.UserType != 1)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    if (Request.QueryString["id"] != "")
                    {
                        int rideId = Convert.ToInt32(Request.QueryString["id"]);

                        bool result = Model.RideDb.CancelRide(rideId);

                        if (result)
                        {
                            lblSuccess.Text = "Your ride has been cancelled successfully. Your payment will be refunded to your credit card in a while.";
                            pnlSuccess.Visible = true;
                            pnlError.Visible = false;
                        }
                         else
                        {
                            lblError.Text = "An error has been occured when cancelling the ride.";
                            pnlSuccess.Visible = false;
                            pnlError.Visible = true;
                        }
                            
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}