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
    public partial class VPNsUpdate : System.Web.UI.Page
    {
        public void LoadData(string id)
        {
            try
            {
                VPNsRepository vpnir = new VPNsRepository();
               // EmailContactsRepository ecrir = new EmailContactsRepository();
                VVPN vpn = vpnir.FindByid(id.ToInt());

                lblid.Text = id;
                Session["UserID"] = vpn.UserID.ToString();
               
                Session["UserType"] = vpn.UserTypeID.ToString();
                Session["DepartmentID"] = vpn.DepartmentID;
                lblusername.Text = vpn.Username;

                Lbldep.Text = vpn.DepartmentTitle;
                VStudentsRepository vstdir = new VStudentsRepository();
                VStudent std = vstdir.FindByid(Session["UserID"].ToString().ToInt());
                if (std != null)
                {
                    Label7.Text = std.FirstName.ToString() + " " + std.LastName.ToString();
                }
                else
                {
                   Redirector.Goto(Redirector.PageName.errorpage);
                }


                DepartmentsRepository etr = new DepartmentsRepository();
                DataTable dt = etr.GetAllDepartment();

                ddldepartment.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ddldepartment.Items.Add(new ListItem(dr["DepartmentTitle"].ToString(), dr["DepartmentID"].ToString()));
                }


                switch ((Session["UserType"].ToString()))
                {
                    case "1":
                        {
                            DropDownList1.SelectedValue = "1";
                            VStudentsRepository vstd = new VStudentsRepository();
                            DataTable dtstd = vstd.GetAllstd();

                            ddluserid.Items.Clear();
                            foreach (DataRow dr in dtstd.Rows)
                            {
                                ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["StudentID"].ToString()));
                            }


                        }
                        break;

                    case "2":
                        {
                            DropDownList1.SelectedValue = "2";

                            VLecturersRepository vlrir = new VLecturersRepository();
                            DataTable dtlec = vlrir.GetAllLec();
                            ddluserid.Items.Clear();
                            foreach (DataRow dr in dtlec.Rows)
                            {
                                ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["LecturerID"].ToString()));
                            }
                        }
                        break;
                    case "3":
                        {
                            DropDownList1.SelectedValue = "3";
                            VEmployeesRepository verir = new VEmployeesRepository();
                            DataTable dtemp = verir.GetAllEmp();
                            ddluserid.Items.Clear();
                            foreach (DataRow dr in dtemp.Rows)
                            {
                                ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["EmployeeID"].ToString()));
                            }

                        }
                        break;

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

                object o = Page.RouteData.Values["VPNID"];
                if (o != null)
                {
                    LoadData(o.ToString());

                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        
        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lblid.Text.Length > 0)
            {

                try
                {

                    VPNsRepository vpnir = new VPNsRepository();
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {

                        if (vpnir.FindByUsername(txtusername.Text) != null)
                        {
                            PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatemailTitle, Color.Red);
                            return;
                        }
                    }
                    VPN vpn = vpnir.FindvpnByid(lblid.Text.ToInt());
                    vpn.UserTypeID = Session["UserType"].ToString().ToInt();
                    vpn.UserID = Session["UserID"].ToString().ToInt();
                    vpn.DepartmentID = Session["DepartmentID"].ToString().ToInt();
                    if ((txtusername.Text.Length > 0) && (txtusername.Text != lblusername.Text))
                    {
                        vpn.Username = txtusername.Text;
                    }
                    if ((txtpass.Text != null))
                    {
                        vpn.Password = txtpass.Text;
                    }
                    vpnir.Savevpn(vpn);

                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                }
                catch
                {
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
                }
            }
        }




        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                VStudentsRepository vstd = new VStudentsRepository();
                DataTable dtstd = vstd.GetAllstd();

                ddluserid.Items.Clear();
                foreach (DataRow dr in dtstd.Rows)
                {
                    ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["StudentID"].ToString()));
                }

            }
            if (DropDownList1.SelectedValue == "2")
            {

                VLecturersRepository vlrir = new VLecturersRepository();
                DataTable dtlec = vlrir.GetAllLec();
                ddluserid.Items.Clear();
                foreach (DataRow dr in dtlec.Rows)
                {
                    ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["LecturerID"].ToString()));
                }

            }


            if (DropDownList1.SelectedValue == "3")
            {


                VEmployeesRepository verir = new VEmployeesRepository();
                DataTable dtemp = verir.GetAllEmp();
                ddluserid.Items.Clear();
                foreach (DataRow dr in dtemp.Rows)
                {
                    ddluserid.Items.Add(new ListItem(dr["FirstName"].ToString() + " " + dr["LastName"].ToString(), dr["EmployeeID"].ToString()));
                }

            }
            Session["UserTypeID"] = DropDownList1.SelectedValue.ToString();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.VPNsManagment);

        }

      

        protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["DepartmentID"] = ddldepartment.SelectedValue.ToString();
        }

        protected void ddluserid_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["UserID"] = ddluserid.SelectedValue.ToString();
        }
    }
}