using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;


namespace personweb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public void Logout()
        {
            Session.Clear();
            Redirector.Goto(Redirector.PageName.SystemLogin);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] == null)
            {
                Logout();
            }
            else
            {
                PersonsAdmin cuser = (Session["CurrentUser"] as PersonsAdmin);

                ////lblWelcome.Text = string.Format("{0} {1}", Resources.DashboardText.WelcomeDearUser,
                //                                cuser.FirstName
                //                                );
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "24")
            {
                Logout();
            }
        }
    }
}