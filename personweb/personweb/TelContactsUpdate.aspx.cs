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
    public partial class TelContactsUpdate : System.Web.UI.Page
    {
        public void LoadData(string id)
        {
            try
            {

                TelContactsRepository ecrir = new TelContactsRepository();
                TelContact Tel = ecrir.FindByid(id.ToInt());
                lblid.Text = Tel.ID.ToString();
                Session["UserID"] = Tel.UserID.ToString();
                Session["TelTypeID"] = Tel.TelTypeID.ToString();
                Session["UserType"] = Tel.UserTypeID.ToString();
                lbltelnumber.Text = Tel.TelNumber;
                
                Session["newuserid"] = Tel.UserID.ToString();
                Session["newteltype"] = Tel.TelTypeID.ToString();



                VStudentsRepository vstdir = new VStudentsRepository();
                VStudent std = vstdir.FindByid(Session["UserID"].ToString().ToInt());
                if (std != null)
                {
                    Label7.Text = std.FirstName.ToString() + " " + std.LastName.ToString();
                   
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }



                TelTypesRepository etir = new TelTypesRepository();
                TelType Teltype = etir.FindByid(Session["TelTypeID"].ToString().ToInt());
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
                ddlTeltype.Items.Clear();
                
                foreach (DataRow dr in dt2.Rows)
                {
             ddlTeltype.Items.Add(new ListItem(dr["TelTypeTitle"].ToString(), dr["TelTypeID"].ToString()));
                    
                }



                switch ((Session["UserType"].ToString()))
                {
                    case "1":
                        {
                            DropDownList1.SelectedValue = "1";
                            VStudentsRepository vstd = new VStudentsRepository();
                            DataTable dtstd = vstd.GetAllstd();

                            ddluserid.Items.Clear();
                            foreach (DataRow dr in dtstd.Rows)
                            {
                                ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["StudentID"].ToString()));
                            }


                        }
                        break;

                    case "2":
                        {
                            DropDownList1.SelectedValue = "2";

                            VLecturersRepository vlrir = new VLecturersRepository();
                            DataTable dtlec = vlrir.GetAllLec();
                            ddluserid.Items.Clear();
                            foreach (DataRow dr in dtlec.Rows)
                            {
                                ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["LecturerID"].ToString()));
                            }
                        }
                        break;
                    case "3":
                        {
                            DropDownList1.SelectedValue = "3";
                            VEmployeesRepository verir = new VEmployeesRepository();
                            DataTable dtemp = verir.GetAllEmp();
                            ddluserid.Items.Clear();
                            foreach (DataRow dr in dtemp.Rows)
                            {
                                ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["EmployeeID"].ToString()));
                            }

                        }
                        break;

                }




            }
            catch
            {
                Redirector.Goto(Redirector.PageName.errorpage);

            }

        }
        public void clearform()
        {
            lblid.Text = "";
            Label7.Text = "";
            lblTeltype.Text = "";
            TextBox2.Text = "";
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["ID"];
                if (o != null)
                {
                    LoadData(o.ToString());

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
                    TelContact tel = new TelContact();
                    tel.UserTypeID = DropDownList1.SelectedItem.Value.ToInt();
                   // tel.UserID = ddluserid.SelectedValue.ToInt();
                    tel.UserID = Session["newuserid"].ToString().ToInt();
                    tel.TelTypeID=  Session["newteltype"].ToString().ToInt();
                 //   tel.TelTypeID = ddlTeltype.SelectedValue.ToInt();
                  
                    tel.ID = lblid.Text.ToInt();
                    if ((TextBox2.Text.Length > 0) && (TextBox2.Text != lbltelnumber.Text))
                    {
                        
                        tel.TelNumber = TextBox2.Text.Trim();

                    }
                    ecrir.SavetelContact(tel);
                   
              

                    clearform();


                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                }
                catch
                {
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
                }
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                VStudentsRepository vstd = new VStudentsRepository();
                DataTable dtstd = vstd.GetAllstd();

                ddluserid.Items.Clear();
                foreach (DataRow dr in dtstd.Rows)
                {
                    ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["StudentID"].ToString()));
                }

            }
            if (DropDownList1.SelectedValue == "2")
            {

                VLecturersRepository vlrir = new VLecturersRepository();
                DataTable dtlec = vlrir.GetAllLec();
                ddluserid.Items.Clear();
                foreach (DataRow dr in dtlec.Rows)
                {
                    ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["LecturerID"].ToString()));
                }

            }


            if (DropDownList1.SelectedValue == "3")
            {


                VEmployeesRepository verir = new VEmployeesRepository();
                DataTable dtemp = verir.GetAllEmp();
                ddluserid.Items.Clear();
                foreach (DataRow dr in dtemp.Rows)
                {
                    ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["EmployeeID"].ToString()));
                }

            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.TelContactsManagment);
        }

        protected void ddluserid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Session["newuserid"] = ddluserid.SelectedValue.ToString();
            
        }

        protected void ddlTeltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newteltype"] = ddlTeltype.SelectedValue.ToString();
        }
    }
}