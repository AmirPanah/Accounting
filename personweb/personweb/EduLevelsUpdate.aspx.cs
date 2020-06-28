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
    public partial class EduLevelsUpdate : System.Web.UI.Page
    {
        public void LoadLevelData(string Levelid)
        {
            try
            {
                EduLevelsRepository elir = new EduLevelsRepository();
                EduLevel level = elir.FindByid(Levelid.ToInt());
                

                if (level != null)
                {
                    lbltitle.Text = level.LevelTitle;
                  
                    lbllevelid.Text = level.LevelID.ToString();
                    TextBox1.Text = level.LevelTitle;
                   
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
            Session["LevelID"] = "";
            Session["LevelTitle"] = "";
            lbltitle.Text = "";
          
            lbllevelid.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["LevelID"];
                if (o != null)
                {
                    LoadLevelData(o.ToString());
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lbllevelid.Text.Length > 0)
            {

                try
                {

                    EduLevelsRepository elir = new EduLevelsRepository();

                    if (elir.FindBytitle(TextBox1.Text) != null)
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatTitle, Color.Red);

                        return;
                    }
                    EduLevel editlevel = new EduLevel();
                    if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                    {
                        editlevel.LevelTitle = TextBox1.Text;
                    }
                    
                    editlevel.LevelID = lbllevelid.Text.ToInt();
                    elir.SaveEduLevel(editlevel);

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
            Redirector.Goto(Redirector.PageName.EduLevelsManager);

        }
    }
}