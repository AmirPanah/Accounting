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
    public partial class DepatrmentsUpdate : System.Web.UI.Page
    {
        public void LoadDepartmentData(string Depid)
        {
            try
            {
                DepartmentsRepository dir = new DepartmentsRepository();
                Department department = dir.FindByid(Depid.ToInt());

                if (department != null)
                {
                    lbltitle.Text = department.DepartmentTitle;
                   
                    lblDepartmentid.Text = department.DepartmentID.ToString();
                    TextBox1.Text = department.DepartmentTitle;

                    
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

        public void ClearForm()
        {
            TextBox1.Text = "";
            Session["DepartmentID"] = "";
            Session["DepartmentTitle"] = "";
            lbltitle.Text = "";
            lblDepartmentid.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["DepartmentID"];
                if (o != null)
                {

                    LoadDepartmentData(o.ToString());
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lblDepartmentid.Text.Length > 0)
            {

                try
                {
                    DepartmentsRepository dir = new DepartmentsRepository();

                    if (dir.FindBytitle(TextBox1.Text) != null)
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatTitle, Color.Red);

                        return;
                    }
                    Department editdepartment = new Department();
                    
                    editdepartment.DepartmentID = lblDepartmentid.Text.ToInt();
                    if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                    {
                        
                       
                        
                        editdepartment.DepartmentTitle = TextBox1.Text;

                    }

                    dir.SaveDepartment(editdepartment);



                    ClearForm();


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
            Redirector.Goto(Redirector.PageName.DepartmentsManager);
        }
    }
}