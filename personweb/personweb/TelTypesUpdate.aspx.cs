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
    public partial class TelTypesUpdate : System.Web.UI.Page
    {

        public void LoadTelTypeData(string Telid)
        {
            try
            {
               TelTypesRepository etir = new TelTypesRepository();
               TelType Teltype = etir.FindByid(Telid.ToInt());


               if (Teltype != null)
                {
                    lbltitle.Text =Teltype.TelTypeTitle;
                    lblEmailTypeid.Text =Teltype.TelTypeID.ToString();
                    TextBox1.Text =Teltype.TelTypeTitle;



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
            Session["TelTypeID"] = "";
            Session["TelTypeTitle"] = "";
            lbltitle.Text = "";
            lblEmailTypeid.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["TelTypeID"];
                if (o != null)
                {

                    LoadTelTypeData(o.ToString());
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
                   TelTypesRepository etir = new TelTypesRepository();


                    if (etir.FindBytitle(TextBox1.Text) != null)
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatTitle, Color.Red);

                        return;
                    }



                   TelType editteltype = new TelType();
                   if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                   {
                     editteltype.TelTypeTitle = TextBox1.Text;
                   }
                    
                    editteltype.TelTypeID = lblEmailTypeid.Text.ToInt();

                    etir.SaveTelType(editteltype);
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
            Redirector.Goto(Redirector.PageName.TelTypesManagment);
        }
    }
}