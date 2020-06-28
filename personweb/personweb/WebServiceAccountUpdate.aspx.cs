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
using System.IO;
using System.Data;
using System.Web.Security;

namespace personweb
{
    public partial class WebServiceAccountUpdate : System.Web.UI.Page
    {
        public void loadform(string perid)
        {


            try
            {


             
                WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
                WebServiceAccount account = webir.FindByid(perid.ToInt());
                if (account != null)
                {
                    lbllecid.Text = account.AccountID.ToString();


                    lblusername.Text = account.Username;

                    chkActiveAccount.Checked = (account.Status.Value == 0 ? true : false);



                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }



            }
            catch
            {
                Redirector.Goto(Redirector.PageName.errorpage);

            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["AccountID"];
                if (o != null)
                {
                    loadform(o.ToString());
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                    //try
                    //{

                    if (lbllecid.Text.Length > 0)
                {
                  
                    WebServiceAccountsRepository webir = new WebServiceAccountsRepository();
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {

                        if (webir.FindByUserName(txtusername.Text) != null)
                        {


                            PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatuserTitle, Color.Red);

                            return;
                        }
                    }

                WebServiceAccountsRepository webirr = new WebServiceAccountsRepository();
                WebServiceAccount account = new WebServiceAccount();
                   
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {

                        account.Username = txtusername.Text;
                    }
            
                account.AccountID = lbllecid.Text.ToInt();
                account.Password = (txtpass.Text.Length > 0 ? FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5") : account.Password);
                    account.Status = (chkActiveAccount.Checked == true ? 0 : 1);
                    webirr.Saveaccount(account);
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                }
            //}
            //catch
            //{
            //    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
            //}

        }


        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.WebServiceManagement);
        }


    }
}