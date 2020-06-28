using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DataAccess;
using System.Drawing;


namespace personweb
{
    public partial class SystemLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateCaptchaText();
            }
        }
        protected void btnSubmitCaptcha_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (Session["Captcha"] != null)
            {
                //Match captcha text entered by user and the one stored in session
                if (Convert.ToString(Session["Captcha"]) == txtCaptchaText.Text.Trim())
                {
                    success = true;
                }

            }

            lblStatus.Visible = true;
            if (success)
            {
                lblStatus.Text = "Success";
                PersonsAdminsRepository perir = new PersonsAdminsRepository();
                PersonsAdmin currentuser = perir.FindByUserName(tbxusername.Text);

                if (currentuser == null)
                {
                    
                    PersonTools.ShowMessage(lblStatus, Resources.DashboardText.errInvalidUserPass, Color.Red);

                    return;
                }

                if (tbxpass.Text != currentuser.Password)
                {
                    PersonTools.ShowMessage(lblStatus, Resources.DashboardText.errInvalidUserPass, Color.Red);
                    return;
                }

                if (currentuser.Status.Value == 1)
                {
                    PersonTools.ShowMessage(lblStatus, Resources.DashboardText.errAccountIsLocked, Color.Red);
                    return;
                }


                Session["CurrentUser"] = currentuser;

                Redirector.Goto(Redirector.PageName.DepartmentsManager);
            }
            else
            {
               
                PersonTools.ShowMessage(lblStatus, Resources.DashboardText.errInvalidUserPass, Color.Red);
            }
        }

        protected void imgbReGenerate_Click(object sender, EventArgs e)
        {
            UpdateCaptchaText();
        }

        private void UpdateCaptchaText()
        {
            txtCaptchaText.Text = string.Empty;
            lblStatus.Visible = false;
            //Store the captcha text in session to validate
            Session["Captcha"] = Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}