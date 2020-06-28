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
    public partial class TelUpdate : System.Web.UI.Page
    {
        public void loadform()
        {
            try
            {

                TelContactsRepository ecrir = new TelContactsRepository();
                TelContact Tel = ecrir.FindByid(Session["ID"].ToString().ToInt());
                lblid.Text = Tel.ID.ToString();
                lbluserid.Text = Session["UserID"].ToString();
                lblusertypeid.Text = Session["UserTypeID"].ToString();
                Session["TelType"] = Tel.TelTypeID.ToString();

                lbltelnumber.Text = Tel.TelNumber.ToString();

                Session["newTeltype"] = Tel.TelTypeID.ToString();


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








                TelTypesRepository etir = new TelTypesRepository();
                TelType Teltype = etir.FindByid(Session["TelType"].ToString().ToInt());
                if (Teltype != null)
                {
                  
                    lblTeltype.Text = Teltype.TelTypeTitle.ToString();
                    // Label7.Text = std.FirstName.ToString() + " " + std.LastName.ToString();
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }


                TelTypesRepository etr = new TelTypesRepository();
                DataTable dt2 = etr.GetAllTelType();
                ddlteltype.Items.Clear();
                
                foreach (DataRow dr in dt2.Rows)
                {
                    ddlteltype.Items.Add(new ListItem(dr["TelTypeTitle"].ToString(), dr["TelTypeID"].ToString()));
                }







            }
            catch
            {
                Redirector.Goto(Redirector.PageName.errorpage);

            }


        }
        public void clearform()
        {

          
            TextBox2.Text = "";

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                object o = Page.RouteData.Values["ID"];
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
                  
                    TelContactsRepository telir = new TelContactsRepository();
                    if ((TextBox2.Text.Length > 0) && (TextBox2.Text != lbltelnumber.Text))
                    {

                        if (telir.FindBytelnumber(TextBox2.Text) != null)
                        {
                          

                            PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatetelTitle, Color.Red);

                            return;
                        }


                    }

                    TelContactsRepository ecrir = new TelContactsRepository();
                    TelContact Tel = new TelContact();
                    Tel.UserTypeID = Session["UserTypeID"].ToString().ToInt();
                    // Tel.UserID=ddluserid.SelectedValue.ToInt();
                    //  Tel.TelTypeID = ddlTeltype.SelectedValue.ToInt();
                    Tel.UserID = Session["UserID"].ToString().ToInt();
                    Tel.TelTypeID = Session["newTeltype"].ToString().ToInt();
                    Tel.TelNumber = TextBox2.Text.Trim();
                    Tel.ID = lblid.Text.ToInt();
                    if ((TextBox2.Text.Length > 0) && (TextBox2.Text != lbltelnumber.Text))
                    {
                        

                        Tel.TelNumber = TextBox2.Text.Trim();
                    }
                    ecrir.SavetelContact(Tel);


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
            Response.Redirect("~/TelManagment/" + Session["UserTypeID"].ToString() + "/" + Session["UserID"].ToString() + "");
        }

       

        protected void ddlteltype_SelectedIndexChanged1(object sender, EventArgs e)
        {
 Session["newTeltype"] = ddlteltype.SelectedValue.ToString();
        }
    }
}