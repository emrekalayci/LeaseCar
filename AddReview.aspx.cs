using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class AddReview : System.Web.UI.Page
    {
        Model.Userr u;
        Model.Ride r;
        Model.Vehicle v;
        Model.Review userReview;

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

                        r = Model.RideDb.GetRideById(rideId);

                        if(r == null)
                            Response.Redirect("Default.aspx");

                        lblDriverName.Text = Model.UserDb.GetUserById(r.DriverId).FullName;
                        lblModel.Text = Model.VehicleDb.getVehicleByUserId(r.DriverId).Model;
                        lblCost.Text = r.Charge.ToString();
                        lblStartDate.Text = r.StartDate.ToString("dd MMMM yyyy", new CultureInfo("en-US"));
                        lblEndDate.Text = r.EndDate.ToString("dd MMMM yyyy", new CultureInfo("en-US"));

                        userReview = Model.ReviewDb.GetReviewByRideId(r.Id);

                        if (userReview != null)
                        {
                            if (!IsPostBack) // This control is needed for update process.
                            {
                                rblVote.SelectedValue = userReview.Vote.ToString();
                                txtComment.Text = userReview.Comment;
                            }

                            btnSend.Visible = false;
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnSend.Visible = true;
                            btnUpdate.Visible = false;
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
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if(txtComment.Text == "" && rblVote.SelectedItem == null)
            {
                lblInfo.Text = "You should at least either vote or make a review regarding your experience.";
            }
            else
            {
                Model.Review rev = new Model.Review()
                {
                    RideId = r.Id,
                    Comment = txtComment.Text.Trim(),
                    Vote = Convert.ToInt32(rblVote.SelectedValue.ToString())
                };

                bool result = Model.ReviewDb.Save(rev);

                if (result)
                    lblInfo.Text = "Your review is live now.";
                else
                    lblInfo.Text = "An error has been occured when saving your review";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtComment.Text == "" && rblVote.SelectedItem == null)
            {
                lblInfo.Text = "You should at least either vote or make a review regarding your experience.";
            }
            else
            {
                Model.Review rev = new Model.Review()
                {
                    Id = userReview.Id,
                    // No need for RideId since they will never change.
                    Comment = txtComment.Text.Trim(),
                    Vote = Convert.ToInt32(rblVote.SelectedValue.ToString())
                };

                bool result = Model.ReviewDb.Update(rev);

                if (result)
                    lblInfo.Text = "Your review has been updated.";
                else
                    lblInfo.Text = "An error has been occured when updating your review.";
            }
        }
    }
}