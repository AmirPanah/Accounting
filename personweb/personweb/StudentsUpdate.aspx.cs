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
    public partial class StudentsUpdate : System.Web.UI.Page
    {

        public void loadform(string stdi)
        {


            //try
            //{

                FacultiesRepositpry fair = new FacultiesRepositpry();
                DataTable dt = fair.GetAllFaculties();
                ddlfacultuy.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ddlfacultuy.Items.Add(new ListItem(dr["FacultyTitle"].ToString(), dr["FacultyID"].ToString()));
                }


                EduLevelsRepository leveir = new EduLevelsRepository();
                DataTable dtlevel = leveir.GetAllEduLevels();
                foreach (DataRow dr in dtlevel.Rows)
                {

                    ddllevel.Items.Add(new ListItem(dr["LevelTitle"].ToString(), dr["LevelID"].ToString()));
                }

                EduFieldsRepository fieldir = new EduFieldsRepository();
                DataTable dtfield = fieldir.GetAllEduFields();
                foreach (DataRow dr in dtfield.Rows)
                {

                    ddlfield.Items.Add(new ListItem(dr["FieldTitle"].ToString(), dr["FieldID"].ToString()));
                }

                VEduTendenciesRepository tenir = new VEduTendenciesRepository();
                DataTable ten = tenir.GetAllTendency();
                foreach (DataRow dr in ten.Rows)
                {

                    ddltendency.Items.Add(new ListItem(dr["TendencyTitle"].ToString(), dr["TendencyID"].ToString()));
                }

                VStudentsRepository vstir = new VStudentsRepository();
                VStudent std = vstir.FindByid(stdi.ToInt());
                if (std != null)
                {
                    lblstdid.Text = std.StudentID.ToString();
                    txtstdcode.Text = std.StudentCode;
                    txtname.Text = std.FirstName;
                    txtlastname.Text = std.LastName;
                    RadioButtonList1.SelectedValue = std.Gender.ToString();
                    txtnationalcode.Text = std.NationalCode;
                    lblfaculty.Text = std.FacultyTitle;
                    lbllevel.Text = std.LevelTitle;
                    lblfield.Text = std.FieldTitle;
                    lbltend.Text = std.TendencyTitle;
                    RadioButtonList2.SelectedValue = std.EntryTerm.ToString();

                    lblusername.Text = std.Username;
                    if(txtpass.Text!=null)
                    {
                         txtpass.Text = std.Password;
                    }
                   
                    //  ImageButton1.ImageUrl = std.ImageFileName;
                    Session["newfacultyid"] = std.FacultyID.ToString();
                    Session["newlevelid"] = std.LevelID.ToString();
                    Session["newfieldid"] = std.FieldID.ToString();
                    Session["newtenid"] = std.TendencyID.ToString();
                    Session["pass"]=std.Password;
                    chkActiveAccount.Checked = (std.Status.Value == 0 ? true : false);
                    Session["imageurl"] = std.ImageFileName;
                    if (Session["imageurl"].ToString()!=null)
                    {
    ImageButton2.ImageUrl = "~/file/" + std.ImageFileName;
                    }
                

                   
                }
                else
                {
                   Redirector.Goto(Redirector.PageName.errorpage);
                }



            //}
            //catch
            //{
            //       Redirector.Goto(Redirector.PageName.errorpage);

            //}

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["StudentID"];
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

            if (lblstdid.Text.Length > 0)
            {

                try
                {
                    string serverpath = Server.MapPath(Request.ApplicationPath) + @"\file\" + PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;
                    string filename = PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;

                    VStudentsRepository vstdir = new VStudentsRepository();

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
                            filename = Session["imageurl"].ToString();
                        }
                    }

                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {
                        if (vstdir.FindByuserName(txtusername.Text) != null)
                        {


                            PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatuserTitle, Color.Red);

                            return;
                        }
                    }
                    VStudentsRepository vstdirr = new VStudentsRepository();
                    Student std = new Student();
                    std.StudentID = lblstdid.Text.ToInt();
                    std.StudentCode = txtstdcode.Text;
                    std.FirstName = txtname.Text;
                    std.LastName = txtlastname.Text;
                    std.Gender = RadioButtonList1.SelectedValue.ToInt();
                    std.NationalCode = txtnationalcode.Text;
                    std.FacultyID=Session["newfacultyid"].ToString().ToInt();
                    std.LevelID = Session["newlevelid"].ToString().ToInt();
                    std.FieldID = Session["newfieldid"].ToString().ToInt();
                    std.TendencyID = Session["newtenid"].ToString().ToInt();
                    std.EntryTerm = RadioButtonList2.SelectedValue.ToInt();
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {
                        std.Username = txtusername.Text;

                    }
                    else
                    {
                        std.Username = lblusername.Text;
                    }

                    if (txtpass.Text.Length > 0)
                    {
                        std.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5");
                    }
                    else
                    {
                        std.Password = Session["pass"].ToString();
                    }

                    std.Status = (chkActiveAccount.Checked == true ? 0 : 1);
                    std.ImageFileName = filename;
                    vstdirr.Savestd(std);
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                }
                catch
                {
                      PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
                }
            }
        }

        protected void ddlfacultuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newfacultyid"] = ddlfacultuy.SelectedValue.ToString();
          
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.StudentsManagment);
        }

        protected void ddllevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newlevelid"] = ddllevel.SelectedValue.ToString();
           
        }

        protected void ddlfield_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newfieldid"] = ddlfield.SelectedValue.ToString();
           
        }

        protected void ddltendency_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["newtenid"] = ddltendency.SelectedValue.ToString();
        }
    }
}