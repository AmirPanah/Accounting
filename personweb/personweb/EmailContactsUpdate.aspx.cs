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
    public partial class EmailContactsUpdate : System.Web.UI.Page
    {
        public void LoadData(string id)
        {
            try
            {
               
                EmailContactsRepository ecrir = new EmailContactsRepository();
                EmailContact email = ecrir.FindByid(id.ToInt());
                lblid.Text = email.ID.ToString();
                Session["UserID"] = email.UserID.ToString();
                Session["EmailType"] = email.EmailTypeID.ToString();
                Session["UserType"] = email.UserTypeID.ToString();

                lblEmailaddrress.Text = email.EmailAddrress.ToString();
                Session["newuserid"] = email.UserID.ToString();
                Session["newemailtype"] = email.EmailTypeID.ToString();
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



               switch((Session["UserType"].ToString()))
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
            lblEmailtype.Text = "";
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

                     EmailContactsRepository ecrir = new EmailContactsRepository();
                 if ((TextBox2.Text.Length > 0) && (TextBox2.Text != lblEmailaddrress.Text))
                 {

                     if (ecrir.FindByEmailAddrress(TextBox2.Text) != null)
                     {


                         PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatemailTitle, Color.Red);

                         return;
                     }


                 }
                   
                    EmailContact email = new EmailContact();
                    email.UserTypeID = DropDownList1.SelectedItem.Value.ToInt();
                  // email.UserID=ddluserid.SelectedValue.ToInt();
                 //  email.EmailTypeID = ddlemailtype.SelectedValue.ToInt();
                    email.UserID = Session["newuserid"].ToString().ToInt();
                    email.EmailTypeID = Session["newemailtype"].ToString().ToInt();
                  
                   email.ID = lblid.Text.ToInt();
                   ecrir.SaveEmailContact(email);
               if ((TextBox2.Text.Length > 0) && (TextBox2.Text != lblEmailaddrress.Text))
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
            Redirector.Goto(Redirector.PageName.EmailContactsManagment);

        }

        protected void ddluserid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newuserid"] = ddluserid.SelectedValue.ToString();
        }

        protected void ddlemailtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newemailtype"] = ddlemailtype.SelectedValue.ToString();
        }

       
    }
}