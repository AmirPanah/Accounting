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
    public partial class AddLecturers : System.Web.UI.Page
    {

        public void loadform()
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
            
            VLecturersRepository vlec = new VLecturersRepository();
            if (vlec.FindByuserName(txtusername.Text) != null)
            {
               
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }



            bool successfullCreateAccount = true;
            try
            {
                string serverpath = Server.MapPath(Request.ApplicationPath) + @"\file\" + PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;
                string filename = PersonTools.CurrentPersianDateWithoutSlash() + PersonTools.CurrentTimeWithoutColons() + FileUpload1.FileName;

                VLecturersRepository vstdir = new VLecturersRepository();
              
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



                Lecturer newstd = new Lecturer();
             
                newstd.FirstName = txtname.Text;
                newstd.LastName = txtlastname.Text;
                newstd.Gender = RadioButtonList1.SelectedValue.ToInt();
                newstd.NationalCode = txtnationalcode.Text;
                newstd.FacultyID = ddlfacultuy.SelectedValue.ToInt();
             
                newstd.FieldID = ddlfield.SelectedValue.ToInt();
                newstd.TendencyID = ddltendency.SelectedValue.ToInt();
             
                newstd.Username = txtusername.Text;
                newstd.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text, "MD5");
               
                newstd.ImageFileName = filename;
                newstd.Status = (chkActiveAccount.Checked == true ? 0 : 1);


                VLecturersRepository vstdirr = new VLecturersRepository();
                vstdirr.Savestd(newstd);


                clearform();
          

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
            Redirector.Goto(Redirector.PageName.LecturersManagment);

        }
    }
}