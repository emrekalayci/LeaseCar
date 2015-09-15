using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class PaymentCompleted : System.Web.UI.Page
    {
        Model.Userr u;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserKey"] != null)
            {
                u = Model.UserDb.GetUserById(Session["UserKey"]);

                Master.LabelOnMasterPage.Text = u.FullName;

                if(u.UserType != 1)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Model.Ride r = Model.RideDb.getLastPaidRide(u.Id);

                    double hourLeft = (r.StartDate - DateTime.Now).TotalHours;

                    if (hourLeft > 24)
                    {
                        lblInfo.Text = "Cancelletion is available until 24 hours prior to your ride. After 24 hours, no refunds will be processed.";
                    }
                    else
                    {
                        lblInfo.Text = "Cancellation is not available for your ride.";
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