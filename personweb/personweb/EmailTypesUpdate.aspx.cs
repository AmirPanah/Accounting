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
    public partial class EmailTypesUpdate : System.Web.UI.Page
    {
        public void LoadEmailTypeData(string emailid)
        {
            try
            {
                EmailTypesRepository etir = new EmailTypesRepository();
                EmailType emailtype = etir.FindByid(emailid.ToInt());


                if (emailtype != null)
                {
                    lbltitle.Text = emailtype.EmailTypeTitle;
                    lblEmailTypeid.Text = emailtype.EmailTypeID.ToString();
                    TextBox1.Text = emailtype.EmailTypeTitle;
                 


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
            Session["EmailTypeID"] = "";
            Session["EmailTypeTitle"] = "";
            lbltitle.Text = "";
            lblEmailTypeid.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["EmailTypeID"];
                if (o != null)
                {

                    LoadEmailTypeData(o.ToString());
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lblEmailTypeid.Text.Length > 0)
            {

                try
                {
                    EmailTypesRepository etir = new EmailTypesRepository();


                    if (etir.FindBytitle(TextBox1.Text) != null)
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatTitle, Color.Red);

                        return;
                    }
                   

                   
                    EmailType editemailtype = new EmailType();
                    if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                    {
                        
                      editemailtype.EmailTypeTitle = TextBox1.Text;
                    }
                   
                    editemailtype.EmailTypeID = lblEmailTypeid.Text.ToInt();

                    etir.SaveEmailType(editemailtype);
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
            Redirector.Goto(Redirector.PageName.EmailTypesManagment);
        }
    }
}