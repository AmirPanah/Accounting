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
    public partial class LecturersUpdate : System.Web.UI.Page
    {
        public void loadform(string Leci)
        {


            try
            {
                FacultiesRepositpry fair = new FacultiesRepositpry();
                DataTable dt = fair.GetAllFaculties();
                ddlfacultuy.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ddlfacultuy.Items.Add(new ListItem(dr["FacultyTitle"].ToString(), dr["FacultyID"].ToString()));
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

                VLecturersRepository vstir = new VLecturersRepository();
                VLecturer Lec = vstir.FindByid(Leci.ToInt());
                if (Lec != null)
                {
                    
                   lbllecid.Text = Lec.LecturerID.ToString();
                    txtname.Text = Lec.FirstName;
                    txtlastname.Text = Lec.LastName;
                    RadioButtonList1.SelectedValue = Lec.Gender.ToString();
                    txtnationalcode.Text = Lec.NationalCode;
                    lblfaculty.Text = Lec.FacultyTitle;
                 
                    lblfield.Text = Lec.FieldTitle;
                    lbltend.Text = Lec.TendencyTitle;

                    lblusername.Text = Lec.Username;
                    if(txtpass.Text!=null)
                    {
                         txtpass.Text = Lec.Password;
                    }
                   
                    //  ImageButton1.ImageUrl = Lec.ImageFileName;
                    Session["newfacultyid"] = Lec.FacultyID.ToString();
                    Session["pass"] = Lec.Password.ToString();
                    Session["newfieldid"] = Lec.FieldID.ToString();
                    Session["newtenid"] = Lec.TendencyID.ToString();
                    chkActiveAccount.Checked = (Lec.Status.Value == 0 ? true : false);

                    Session["imageurl"] = Lec.ImageFileName.ToString();
                    if (Session["imageurl"].ToString() != null)
                    {
                        ImageButton2.ImageUrl = "~/file/" + Lec.ImageFileName;

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

                object o = Page.RouteData.Values["LecturerID"];
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

            if (lbllecid.Text.Length > 0)
            {

                try
                {
                    string serverpath = Server.MapPath(Request.ApplicationPath) + @"\file\" + PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;
                    string filename = PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;

                    VLecturersRepository vLecir = new VLecturersRepository();

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

                    VLecturersRepository vLecirr = new VLecturersRepository();
                    Lecturer Lec = new Lecturer();

                    Lec.LecturerID = lbllecid.Text.ToInt();
                 
                    Lec.FirstName = txtname.Text;
                    Lec.LastName = txtlastname.Text;
                    Lec.Gender = RadioButtonList1.SelectedValue.ToInt();
                    Lec.NationalCode = txtnationalcode.Text;
                    Lec.FacultyID = Session["newfacultyid"].ToString().ToInt();
                 
                    Lec.FieldID = Session["newfieldid"].ToString().ToInt();
                    Lec.TendencyID = Session["newtenid"].ToString().ToInt();
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {
                        
                      Lec.Username = txtusername.Text;
                    }
                    else
                    {
                        Lec.Username = lblusername.Text;
                    }
                    //Lec.Password = (txtpass.Text.Length > 0 ? FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5") : Lec.Password);
                    if (txtpass.Text.Length > 0)
                    {
                        Lec.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5");
                    }
                    else
                    {
                        Lec.Password = Session["pass"].ToString();
                    }
                    Lec.Status = (chkActiveAccount.Checked == true ? 0 : 1);
                    Lec.ImageFileName = filename;
                    vLecirr.Savestd(Lec);
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
            Redirector.Goto(Redirector.PageName.LecturersManagment);
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