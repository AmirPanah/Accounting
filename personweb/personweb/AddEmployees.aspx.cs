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
    public partial class AddEmployees : System.Web.UI.Page
    {

        public void loadform()
        {
            try
            {

                DepartmentsRepository depir = new DepartmentsRepository();
                DataTable dep = depir.GetAllDepartment();
               
                foreach (DataRow dr in dep.Rows)
                {

                    ddldep.Items.Add(new ListItem(dr["DepartmentTitle"].ToString(), dr["DepartmentID"].ToString()));
                }

                RolesRepository roleir = new RolesRepository();
                DataTable role = roleir.GetAllRoles();
                foreach (DataRow dr in role.Rows)
                {
                   
                    ddlrole.Items.Add(new ListItem(dr["RoleTitle"].ToString(), dr["RoleID"].ToString()));
                }
            }
            catch
            {
                Redirector.Goto(Redirector.PageName.errorpage);
            }
        }
        public void clearform()
        {
           
            txtname.Text = "";
            txtlastname.Text = "";

            txtnationalcode.Text = "";
            txtusername.Text = "";
            txtpass.Text = "";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadform();


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            VEmployeesRepository emp = new VEmployeesRepository();

            if (emp.FindByuserName(txtusername.Text) != null)
            {
               
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }



            bool successfullCreateAccount = true;
            try
            {
                string serverpath = Server.MapPath(Request.ApplicationPath) + @"\file\" + PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;
                string filename = PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;

              
                VEmployeesRepository vstdir=new VEmployeesRepository();
                if (vstdir.FindByLinkUrl(filename) != null)
                {
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errAddFailedFileUploadrepeat, Color.Red);

                    return;
                }
                else
                {

                    if (FileUpload1.FileName.Length > 0)
                    {
                        int filesize = FileUpload1.FileBytes.Length / 1024;
                        if (filesize >= 4000)
                        {
                            PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errAddFailedFileUploadsize, Color.Red);
                            return;
                        }
                        else
                        {

                            FileUpload1.SaveAs(serverpath);
                        }
                    }
                    else
                    {
                        //  PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errAddFailedFileUploadempty, Color.Red);
                        //  return;
                        filename = "";
                    }
                }



               Employee newemp = new Employee();

               newemp.DepartmentID = ddldep.SelectedValue.ToInt();
               newemp.RoleID = ddlrole.SelectedValue.ToInt();
                newemp.FirstName = txtname.Text;
                newemp.LastName = txtlastname.Text;
                newemp.Gender = RadioButtonList1.SelectedValue.ToInt();
                newemp.NationalCode = txtnationalcode.Text;
                
                newemp.Username = txtusername.Text;
                newemp.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5");
                
                newemp.ImageFileName = filename;
                newemp.Status = (chkActiveAccount.Checked == true ? 0 : 1);

                VEmployeesRepository vstdirr = new VEmployeesRepository();
                vstdirr.Saveemp(newemp);


                clearform();
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgAddSuccessfull, Color.Green);

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
            Redirector.Goto(Redirector.PageName.EmployeesManagment);

        }
    }
}