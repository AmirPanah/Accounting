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
    public partial class AddTelContacts : System.Web.UI.Page
    {

        public void loadform()
        {
             TelTypesRepository etr = new  TelTypesRepository();
            DataTable dt = etr.GetAllTelType();
            ddlTeltype.Items.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                ddlTeltype.Items.Add(new ListItem(dr["TelTypeTitle"].ToString(), dr["TelTypeID"].ToString()));
            }




        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadform();


            }

        }


        public void ClearForm()
        {
            TextBox1.Text = "";
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            TelContactsRepository tel = new TelContactsRepository();
            if (tel.FindBytelnumber(TextBox1.Text) != null)
            {


                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }

            bool successfullCreateAccount = true;

            try
            {

             TelContact newcontact = new  TelContact();
            newcontact.UserTypeID = DropDownList1.SelectedValue.ToInt();
            newcontact.UserID = ddluserid.SelectedValue.ToInt();
            newcontact.TelTypeID = ddlTeltype.SelectedValue.ToInt();
            newcontact.TelNumber = TextBox1.Text.Trim();
           
                 TelContactsRepository ecrir = new  TelContactsRepository();
               

                ecrir.SavetelContact(newcontact);

                ClearForm();
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgAddSuccessfull, Color.Green);

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
            Redirector.Goto(Redirector.PageName. TelContactsManagment);
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

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {


        }
    }
}