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

namespace personweb
{
    public partial class AddEmail : System.Web.UI.Page
    {
        public void loadform()
        {
            try
            {

                lbluserid.Text = Session["UserID"].ToString();
                lblusertypeid.Text = Session["UserTypeID"].ToString();
                EmailTypesRepository etr = new EmailTypesRepository();
                DataTable dt = etr.GetAllEmailTypes();
                ddlemailtype.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ddlemailtype.Items.Add(new ListItem(dr["EmailTypeTitle"].ToString(), dr["EmailTypeID"].ToString()));
                }






                switch (Session["UserTypeID"].ToString())
                {
                    case "1":
                        {
                            VStudentsRepository vstdir = new VStudentsRepository();
                            VStudent std = vstdir.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "دانشجو" + ":" + std.FirstName + " " + std.LastName;
                        }
                        break;
                    case "2":
                        {
                            VLecturersRepository vlec = new VLecturersRepository();
                            VLecturer lec = vlec.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "استاد" + ":" + lec.FirstName + " " + lec.LastName;
                        }
                        break;
                    case "3":
                        {
                            VEmployeesRepository vlec = new VEmployeesRepository();
                            VEmployee emp = vlec.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "کارمند" + ":" + emp.FirstName + " " + emp.LastName;
                        }
                        break;
                }

            }
            catch
            {
                Redirector.Goto(Redirector.PageName.errorpage);

            }



        }

        public void ClearForm()
        {
            TextBox1.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["UserTypeID"];
                Session["UserTypeID"] = o.ToString();
                object oo = Page.RouteData.Values["UserID"];
                Session["UserID"] = oo.ToString();
                if (o != null && oo != null)
                {
                    loadform();

                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

          
            EmailContactsRepository email = new EmailContactsRepository();
            if (email.FindByEmailAddrress(TextBox1.Text) != null)
            {

                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }



            bool successfullCreateAccount = true;


 try
            {
            EmailContact newcontact = new EmailContact();
            newcontact.UserTypeID = lblusertypeid.Text.ToInt();

            newcontact.UserID = lbluserid.Text.ToInt();
            newcontact.EmailTypeID = ddlemailtype.SelectedValue.ToInt();
            newcontact.EmailAddrress = TextBox1.Text.Trim();
           
                EmailContactsRepository ecrir = new EmailContactsRepository();
                ecrir.SaveEmailContact(newcontact);



                ClearForm();
              
            }
            catch (System.Exception err)
            {
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
            Response.Redirect("~/EmailManagment/" + Session["UserTypeID"].ToString() + "/" + Session["UserID"].ToString() + "");
        }
    }
}