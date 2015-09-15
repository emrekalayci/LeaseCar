using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Lease : System.Web.UI.Page
    {
        Model.Userr u;
        Model.Vehicle v;
        int vehicleId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserKey"] != null)
            {
                u = Model.UserDb.GetUserById(Session["UserKey"]);
                Master.LabelOnMasterPage.Text = u.FullName;

                // If the userType is not Passenger, redirect to main page.
                if(u.UserType != 1)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    if (Request.QueryString["id"] != "")
                    {
                        vehicleId = Convert.ToInt32(Request.QueryString["id"]);
                        v = Model.VehicleDb.getVehicleById(vehicleId);

                        lblDriver.Text = Model.UserDb.GetUserById(v.DriverId).FullName;
                        lblModel.Text = v.Model;
                        lblCost.Text = v.Cost.ToString();
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

        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (clStartDate.SelectedDate != DateTime.MinValue && clEndDate.SelectedDate != DateTime.MinValue)
            {
                if(clStartDate.SelectedDate <= DateTime.Now)
                {
                    lblInfo.Text = "Start date should be after than today.";
                }
                else if(clStartDate.SelectedDate > clEndDate.SelectedDate)
                {
                    lblInfo.Text = "You cannot select the end date before the star date.";
                }
                else
                {
                    Model.Ride r = new Model.Ride()
                    {
                        PassengerId = u.Id,
                        DriverId = v.DriverId,
                        Description = txtDescription.Text.Trim(),
                        StartDate = clStartDate.SelectedDate,
                        EndDate = clEndDate.SelectedDate,
                        Charge = v.Cost * (clEndDate.SelectedDate - clStartDate.SelectedDate).TotalDays, //Calculate charge based on the number of days for ride.
                    };

                    bool result = Model.RideDb.Save(r);

                    if (result)
                        Response.Redirect("PaymentCompleted.aspx");
                    else
                        lblInfo.Text = "An error has been occured while saving your ride.";
                }
            }
            else
            {
                lblInfo.Text = "Make sure that you have selected start and end date of your trip.";
            }
        }


    }
}