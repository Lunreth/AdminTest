using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace AdminTest
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLastName.Text.Trim();
            var newUser = txtNewUser.Text.Trim();
            var newPassword = txtNewPassword.Text.Trim();
            var repeatPassword = txtRepeatPassword.Text.Trim();

            // Validations
            if (firstName == "")
            {
                lblError.Text = "Enter a valid first name.";
                return;
            }
            else
            {
                lblError.Text = "";
            }

            if (newPassword != repeatPassword)
            {
                lblError.Text = "Passwords don't match";
                return;
            }

            var user = new Domain.Users
            {
                Username = newUser,
                Password = newPassword,
                FirstName = firstName,
                LastName = lastName
            };

            if (UsersDAL.Insert(user))
            {
                lblError.Text = "New user registered successfully!";
            }
            else
            {
                lblError.Text = "Failed to register new user!";
            }
        }
    }
}