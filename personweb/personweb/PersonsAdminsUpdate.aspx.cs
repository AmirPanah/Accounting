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
    public partial class PersonsAdminUpdate : System.Web.UI.Page
    {
        public void loadform(string perid)
        {


            try
            {
                
               
                PersonsAdminsRepository per = new PersonsAdminsRepository();
                PersonsAdmin person = per.FindByid(perid.ToInt());

                if (person != null)
                {

                    lbllecid.Text = person.AdminID.ToString();
                    txtname.Text = person.FirstName;
                    txtlastname.Text = person.LastName;
                    lblusername.Text = person.Username;
                    Session["pass"] = person.Password;
                    chkActiveAccount.Checked = (person.Status.Value == 0 ? true : false);

                   

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

                object o = Page.RouteData.Values["AdminID"];
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
            try
            {
            if (lbllecid.Text.Length > 0)
            {
                   VLecturersRepository vLecirr = new VLecturersRepository();

                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {
                        if (vLecirr.FindByuserName(txtusername.Text) != null)
                        {


                            PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatuserTitle, Color.Red);

                            return;
                        }
                    }

                 
                  
                PersonsAdmin person=new PersonsAdmin();
                person.AdminID=lbllecid.Text.ToInt();
                  
                    person.FirstName = txtname.Text;
                    person.LastName = txtlastname.Text;
                   
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {

                        person.Username = txtusername.Text;
                    }
                    else
                    {
                        person.Username = lblusername.Text;
                    }
                    //person.Password = (txtpass.Text.Length > 0 ? FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5") : person.Password);
                    if (txtpass.Text.Length > 0)
                    {
                        person.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5");
                    }
                    else
                    {
                        person.Password = Session["pass"].ToString();
                    }
                person.Status = (chkActiveAccount.Checked == true ? 0 : 1);
                    
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                }
        }
                catch
                {
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
                }
            
        }

       
        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.PersonsAdminsManagment);
        }



        
    }
}