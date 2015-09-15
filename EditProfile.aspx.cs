using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class EditProfile : System.Web.UI.Page
    {
        Model.Userr u;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserKey"] != null)
            {
                u = Model.UserDb.GetUserById(Session["UserKey"]);
                Master.LabelOnMasterPage.Text = u.FullName;

                if (!IsPostBack)
                {
                    txtFullName.Text = u.FullName;
                    txtPhoneNumber.Text = u.PhoneNumber;
                    txtEmail.Text = u.Email;
                    lblInfo.Visible = false;
                }
            }
            else
                Response.Redirect("Default.aspx");                
       }

        

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Model.Userr user = new Model.Userr()
            {
                Id = u.Id,
                FullName = txtFullName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Email = txtEmail.Text.Trim(),
              };

            lblInfo.Visible = true;

            if (Model.UserDb.Update(user))
                lblInfo.Text = "The profile has been updated successfully.";
            else
                lblInfo.Text = "An error occurs while updating process. :(";
        }
    }
}