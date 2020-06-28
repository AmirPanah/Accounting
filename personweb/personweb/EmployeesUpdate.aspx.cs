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
    public partial class EmployeesUpdateaspx : System.Web.UI.Page
    {
        public void loadform(string empid)
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

                VEmployeesRepository vstir = new VEmployeesRepository();
                VEmployee emp = vstir.FindByid(empid.ToInt());
                if (emp != null)
                {
                    
                    lblempid.Text = emp.EmployeeID.ToString();
                    txtname.Text = emp.FirstName;
                    txtlastname.Text = emp.LastName;
                    RadioButtonList1.SelectedValue = emp.Gender.ToString();
                    txtnationalcode.Text = emp.NationalCode;
                    lbldep.Text = emp.DepartmentTitle;
                    lblrole.Text = emp.RoleTitle;


                    lblusername.Text = emp.Username.ToString();
                    if(txtpass.Text!=null)
                    {
                         txtpass.Text = emp.Password.ToString();
                    }
                   
                    //  ImageButton1.ImageUrl = emp.ImageFileName;
                    Session["newdep"] = emp.DepartmentID.ToString();
                    Session["pass"] = emp.Password.ToString();
                    Session["newrole"] = emp.RoleID.ToString();
                   
                    chkActiveAccount.Checked = (emp.Status.Value == 0 ? true : false);

                    Session["imageurl"] = emp.ImageFileName.ToString();
                    if (Session["imageurl"].ToString() != null)
                    {
                        ImageButton2.ImageUrl = "~/file/" + emp.ImageFileName;

                    }


                    

                  
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

                object o = Page.RouteData.Values["EmployeeID"];
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

            if (lblempid.Text.Length > 0)
            {

                try
                {
                    string serverpath = Server.MapPath(Request.ApplicationPath) + @"\file\" + PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;
                    string filename = PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;

                  
                    VEmployeesRepository vLecir = new VEmployeesRepository();
                    if (vLecir.FindByLinkUrl(filename) != null)
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
                            filename = Session["imageurl"].ToString();
                        }
                    }

                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {
                        if (vLecir.FindByuserName(txtusername.Text) != null)
                        {


                            PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatuserTitle, Color.Red);

                            return;
                        }
                    }

                    VEmployeesRepository vempirr = new VEmployeesRepository();
                    Employee emp = new Employee();

                    emp.EmployeeID = lblempid.Text.ToInt();

                    emp.FirstName = txtname.Text;
                    emp.LastName = txtlastname.Text;
                    emp.Gender = RadioButtonList1.SelectedValue.ToInt();
                    emp.NationalCode = txtnationalcode.Text;
                    emp.DepartmentID = Session["newdep"].ToString().ToInt();
                    emp.RoleID = Session["newrole"].ToString().ToInt();
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                     {
                        emp.Username = txtusername.Text;
                          
                        }
                    else
                    {
                        emp.Username = lblusername.Text;
                    }

                    //emp.Password = (txtpass.Text.Length > 0 ? FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5") : emp.Password);
                    if (txtpass.Text.Length > 0)
                    {
                        emp.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5");
                    }
                    else
                    {
                        emp.Password = Session["pass"].ToString();
                    }
                    emp.Status = (chkActiveAccount.Checked == true ? 0 : 1);
                    
                    emp.ImageFileName = filename;
                    vempirr.Saveemp(emp);
                   
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                }
                catch
                {
                      PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
                }
            }
        }

        protected void ddldep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newdep"] = ddldep.SelectedValue.ToString();
        }

        protected void ddlrole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newrole"] = ddlrole.SelectedValue.ToString();
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.EmployeesManagment);
        }


    }
}