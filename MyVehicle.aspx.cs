using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class MyVehicle : System.Web.UI.Page
    {
        Model.Userr u;
        Model.Vehicle uVehicle;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserKey"] != null)
            {
                u = Model.UserDb.GetUserById(Session["UserKey"]);

                Master.LabelOnMasterPage.Text = u.FullName;

                uVehicle = Model.VehicleDb.getVehicleByUserId(u.Id);

                // If the user has a vehicle registered, insert vehicle data in web forms.
                if (uVehicle != null)
                {
                    if(!IsPostBack) // This control is needed for update process.
                    {
                        txtModel.Text = uVehicle.Model;
                        txtYear.Text = uVehicle.Year.ToString();
                        txtLicenseNumber.Text = uVehicle.LicenseNumber;
                        txtCity.Text = uVehicle.City;
                        txtCost.Text = uVehicle.Cost.ToString();
                    }

                    // If the user has already a vehicle registered, show them update button.
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
                else
                {
                    // If the user has no vehicle registered, show them add button.
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnAddVehicle_Click(object sender, EventArgs e)
        {
            if (txtModel.Text.Trim() != "" && txtYear.Text.Trim() != "" && txtLicenseNumber.Text.Trim() != "" && txtCity.Text.Trim() != "" && txtCost.Text.Trim() != "")
            {
                Model.Vehicle v = new Model.Vehicle()
                {
                    DriverId = u.Id,
                    Model = txtModel.Text.Trim(),
                    Year = Int32.Parse(txtYear.Text.Trim()),
                    LicenseNumber = txtLicenseNumber.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Cost = float.Parse(txtCost.Text.Trim())
                };

                bool result = Model.VehicleDb.Save(v);

                if (result)
                    lblInfo.Text = "Your vehicle has been saved.";
                else
                    lblInfo.Text = "An error has been occured while saving your vehicle.";
            }
            else
                lblInfo.Text = "You must fill out all the required fields.";
        }

        protected void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            if (txtModel.Text.Trim() != "" && txtYear.Text.Trim() != "" && txtLicenseNumber.Text.Trim() != "" && txtCity.Text.Trim() != "" && txtCost.Text.Trim() != "")
            {
                Model.Vehicle v = new Model.Vehicle()
                {
                    Id = uVehicle.Id,
                    Model = txtModel.Text.Trim(),
                    Year = Int32.Parse(txtYear.Text.Trim()),
                    LicenseNumber = txtLicenseNumber.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Cost = float.Parse(txtCost.Text.Trim())
                };

                bool result = Model.VehicleDb.Update(v);

                if (result)
                    lblInfo.Text = "Your vehicle has been updated successfully.";
                else
                    lblInfo.Text = "An error has been occured while updating.";
            }
            else
                lblInfo.Text = "You must fill out all the required fields.";
        }
    }
}