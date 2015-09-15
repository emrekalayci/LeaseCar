using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class SearchResults : System.Web.UI.Page
    {
        Model.Userr u;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserKey"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
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
                    if (Request.QueryString["city"] == "")
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        string city = Request.QueryString["city"];

                        rptSearchResult.DataSource = Model.VehicleDb.Search(city);
                        rptSearchResult.DataBind();
                    }
                }              
            }                  
        }
    }
}