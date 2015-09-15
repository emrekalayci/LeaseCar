using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void buttonSignup_Click(Object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() != "" && txtEmail.Text.Trim() != "" && txtPassword.Text.Trim() != "" && txtUserName.Text.Trim() != "")
            {
                string MatchEmailPattern = 
                @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
		                [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
		                [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


                if (!Regex.IsMatch(txtEmail.Text, MatchEmailPattern))
                {
                    infoLabel.Text = "Invalid email adress!";
                    return;
                }

                int userType = Int32.Parse(radiobtnUserType.Text);

                Model.Userr user = new Model.Userr()
                {   
                    FullName = txtFullName.Text.Trim(),
                    Password = Library.Tools.MD5yapUTF8(txtPassword.Text.Trim()),
                    Username = txtUserName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    BirthDay = "",
                    RegistrationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    UserType = userType,
                };

                bool result = Model.UserDb.Save(user);

                txtFullName.Text="";
                txtPassword.Text="";
                txtUserName.Text="";
                txtPhoneNumber.Text="";
                txtEmail.Text="";
                radiobtnUserType.SelectedIndex = -1;

                if (result)
                    infoLabel.Text = "Your account has been created successfully.";
                else
                    infoLabel.Text = "An error has been occured while registration process.";            
            }
            else
               infoLabel.Text = "You must fill out the required fields.";    
        }

    }
}