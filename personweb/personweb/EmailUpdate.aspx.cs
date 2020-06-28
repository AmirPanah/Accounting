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


namespace personweb
{
    public partial class EmailUpdateaspx : System.Web.UI.Page
    {
        public void loadform()
        {
            try
            {

                 EmailContactsRepository ecrir = new EmailContactsRepository();
                EmailContact email = ecrir.FindByid(  Session["ID"].ToString().ToInt());
                lblid.Text = email.ID.ToString();
              lbluserid.Text= Session["UserID"].ToString();
                lblusertypeid.Text=Session["UserTypeID"].ToString();
                Session["EmailType"] = email.EmailTypeID.ToString();

                lblemailaddrress.Text = email.EmailAddrress;
              
                Session["newemailtype"] = email.EmailTypeID.ToString();

 
                switch (Session["UserTypeID"].ToString())
                {
                    case "1":
                        {
                            VStudentsRepository vstdir = new VStudentsRepository();
                            VStudent std = vstdir.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text="دانشجو"+":"+std.FirstName+" "+ std.LastName;
                        }
                        break;
                    case "2":
                        {
                            VLecturersRepository vlec=new VLecturersRepository();
                            VLecturer lec=vlec.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "استاد" +":"+ lec.FirstName + " " + lec.LastName;
                        }
                        break;
                    case "3":
                        {
                            VEmployeesRepository vlec = new VEmployeesRepository();
                            VEmployee emp=vlec.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "کارمند" +":"+ emp.FirstName + " " + emp.LastName;
                        }
                        break;
                }


              
               
               



                EmailTypesRepository etir = new EmailTypesRepository();
                EmailType emailtype = etir.FindByid(Session["EmailType"].ToString().ToInt());
                if (emailtype != null)
                {
                    lblEmailtype.Text = emailtype.EmailTypeTitle;
                    // Label7.Text = std.FirstName.ToString() + " " + std.LastName.ToString();
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }


                EmailTypesRepository etr = new EmailTypesRepository();
                DataTable dt2 = etr.GetAllEmailTypes();
                ddlemailtype.Items.Clear();

                foreach (DataRow dr in dt2.Rows)
                {
                    ddlemailtype.Items.Add(new ListItem(dr["EmailTypeTitle"].ToString(), dr["EmailTypeID"].ToString()));
                }



            
              


            }
            catch
            {
                Redirector.Goto(Redirector.PageName.errorpage);

            }
            
           
        }
        public void clearform()
        {
            
            lblEmailtype.Text = "";
            TextBox2.Text = "";

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                object o=Page.RouteData.Values["ID"];
                Session["ID"] = o.ToString();
                object oo = Page.RouteData.Values["UserTypeID"];
                Session["UserTypeID"] = oo.ToString();
                object ooo = Page.RouteData.Values["UserID"];
                Session["UserID"] = ooo.ToString();
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

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lblid.Text.Length > 0)
            {

                try
                {
                        EmailContactsRepository ecrir = new EmailContactsRepository();
                        if ((TextBox2.Text.Length > 0) && (TextBox2.Text != lblemailaddrress.Text))
                        {

                            if (ecrir.FindByEmailAddrress(TextBox2.Text) != null)
                            {


                                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatemailTitle, Color.Red);

                                return;
                            }


                        }



                        //  EmailContactsRepository ecrir = new EmailContactsRepository();
                        EmailContact email = new EmailContact();
                        email.UserTypeID = Session["UserTypeID"].ToString().ToInt();
                        // email.UserID=ddluserid.SelectedValue.ToInt();
                        //  email.EmailTypeID = ddlemailtype.SelectedValue.ToInt();
                        email.UserID = Session["UserID"].ToString().ToInt();
                        email.EmailTypeID = Session["newemailtype"].ToString().ToInt();

                        email.ID = lblid.Text.ToInt();
                        ecrir.SaveEmailContact(email);

                        if ((TextBox2.Text.Length > 0) && (TextBox2.Text != lblemailaddrress.Text))
                        {

                            email.EmailAddrress = TextBox2.Text.Trim();
                        }


                        clearform();


                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                    }
                    catch
                    {
                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
                    }
                }
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/EmailManagment/" + Session["UserTypeID"].ToString() + "/" + Session["UserID"].ToString() + "");
        }

        protected void ddlemailtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newemailtype"] = ddlemailtype.SelectedValue.ToString();
        }
    }
}