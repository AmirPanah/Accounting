using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DataAccess;
using DataAccess.Repository;
using System.Drawing;
using System.Data;
using System.Web.Security;

namespace personweb
{
    public partial class AddPersonsAdmins : System.Web.UI.Page
    {
      
        public void clearform()
        {
            txtlastname.Text = "";
            txtname.Text = "";
            txtpass.Text = "";
            txtusername.Text = "";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
           


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            PersonsAdminsRepository parir = new PersonsAdminsRepository();

            if (parir.FindByUserName(txtusername.Text) != null)
            {

                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }

          

            bool successfullCreateAccount = true;
            try
            {

                PersonsAdminsRepository pair = new PersonsAdminsRepository();
                PersonsAdmin newpa = new PersonsAdmin();
                newpa.FirstName=txtname.Text.Trim();
                newpa.LastName=txtlastname.Text.Trim();
                newpa.Username=txtusername.Text.Trim();
                newpa.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5");
                newpa.Status = (chkActiveAccount.Checked == true ? 0 : 1);

                pair.SavePerson(newpa);


                clearform();
               

            }
            catch (System.Exception err)
            {
                //OnlineTools.ShowMessage(lblMessage, err.Message, Color.Red);
                successfullCreateAccount = false;
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errAddFailed, Color.Red);


            }
            if (successfullCreateAccount)
            {
                // ClearForm();
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgAddSuccessfull, Color.Green);
            }
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.PersonsAdminsManagment);

        }
    }
}