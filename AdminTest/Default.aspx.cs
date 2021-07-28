using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DAL;
using Domain;

namespace AdminTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("user"))
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUsername.Text.Trim() == "") || (txtPassword.Text.Trim() == ""))
            {
                this.lblError.Text = "Please fill the username and password text fields";
            }
            else
            {
                this.lblError.Text = "";

                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text.Trim();

                var obj = new Users
                {
                    Username = username,
                    Password = password
                };

                var user = UsersDAL.CheckLogin(obj);

                if (user != null)
                {
                    //lblError.Text = "Login Success!";
                    //Response.Redirect("Home.aspx");
                    string roles = "user";
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(2880), false, roles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    if (!ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    //FormsAuthentication.GetRedirectUrl(username, false);
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    lblError.Text = "Invalid Username or Password";
                }
            }
        }
    }
}