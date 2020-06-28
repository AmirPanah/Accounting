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
    public partial class EduFieldsUpdate : System.Web.UI.Page
    {
        public void LoadFieldData(string Fieldid)
        {
            try
            {
               
                EduFieldsRepository efir = new EduFieldsRepository();
                EduField field = efir.FindByid(Fieldid.ToInt());

                if (field != null)
                {


                    lbltitle.Text = field.FieldTitle;
                    
                    lblFieldid.Text = field.FieldID.ToString();
                    TextBox1.Text = field.FieldTitle;

                   
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
            Session["FieldID"] = "";
            Session["FieldTitle"] = "";
            lbltitle.Text = "";
            lblFieldid.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["FieldID"];
                if (o != null)
                {
                    LoadFieldData(o.ToString());
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lblFieldid.Text.Length > 0)
            {

                try
                {
                    EduFieldsRepository efir = new EduFieldsRepository();

                    if (efir.FindBytitle(TextBox1.Text) != null)
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatTitle, Color.Red);

                        return;
                    }
                    EduField editfield = new EduField();
                    if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                    {
                     editfield.FieldTitle= TextBox1.Text;
                    }
                  
                   editfield.FieldID = lblFieldid.Text.ToInt();
                   efir.SaveEdufield(editfield);

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
            Redirector.Goto(Redirector.PageName.EduFieldsManager);
        }
    }
}