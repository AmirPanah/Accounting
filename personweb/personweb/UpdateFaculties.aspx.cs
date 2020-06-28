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
    public partial class UpdateFaculties : System.Web.UI.Page
    {

        public void LoadFacultyData(string Fid)
        {
            try
            {
                FacultiesRepositpry fir = new FacultiesRepositpry();
                Faculty faculty = fir.FindByid(Fid.ToInt());


                if (faculty != null)
                {
                    lbltitle.Text = faculty.FacultyTitle;
                    lblFacultyid.Text = faculty.FacultyID.ToString();

                    TextBox1.Text = faculty.FacultyTitle;


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
            Session["FacultyID"] = "";
            Session["FacultyTitle"] = "";
            lbltitle.Text = "";
         lblFacultyid.Text="";

        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["FacultyID"];
                if (o != null)
                {
                    LoadFacultyData(o.ToString());
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            
               if (lblFacultyid.Text.Length > 0)
            {
                
                try
                {
                    FacultiesRepositpry fir=new FacultiesRepositpry();
                  
                     if ( fir.FindBytitle(TextBox1.Text) != null)
                    {
                         
                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatGroupTitle, Color.Red);

                        return;
                    }
                    Faculty editFulty=new Faculty();
                    if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                    {
 editFulty.FacultyTitle=TextBox1.Text;
                    }
                   
   editFulty.FacultyID=lblFacultyid.Text.ToInt();

              
                   fir.SaveFaculty(editFulty);
                   
                   
               
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
            Redirector.Goto(Redirector.PageName.FacultiesManager);
        }
    }
}