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
    public partial class RolesUpdate : System.Web.UI.Page
    {

        public void LoadDepartmentData(string Roleid)
        {
            try
            {
               
                RolesRepository rrir = new RolesRepository();
                Role role = rrir.FindByid(Roleid.ToInt());

                if (role != null)
                {


                    lbltitle.Text = role.RoleTitle;
                    lblRoleid.Text = role.RoleID.ToString();

                    TextBox1.Text = role.RoleTitle;


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
            Session["RoleID"] = "";
            Session["RoleTitle"] = "";
            lbltitle.Text = "";
          
            lblRoleid.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["RoleID"];
                if (o != null)
                {

                    LoadDepartmentData(o.ToString());
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lblRoleid.Text.Length > 0)
            {

                try
                {

                    RolesRepository rrir = new RolesRepository();
                    if (rrir.FindBytitle(TextBox1.Text) != null)
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatTitle, Color.Red);

                        return;
                    }
                  
                    Role editRole = new Role();
                    if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                    {
                     editRole.RoleTitle = TextBox1.Text;
                    }
                   
                    editRole.RoleID = lblRoleid.Text.ToInt();

                    rrir.SaveRoles(editRole);



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
            Redirector.Goto(Redirector.PageName.RolesManagmet);

        }
    }
}