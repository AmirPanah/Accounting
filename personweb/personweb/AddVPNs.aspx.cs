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


namespace personweb
{
    public partial class AddVPNss : System.Web.UI.Page
    {
        public void loadform()
        {
            DepartmentsRepository etr = new DepartmentsRepository();
            DataTable dt = etr.GetAllDepartment();
            
            ddldepartment.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ddldepartment.Items.Add(new ListItem(dr["DepartmentTitle"].ToString(), dr["DepartmentID"].ToString()));
            }

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
            VPNsRepository vpn = new VPNsRepository();
            if (vpn.FindByUsername(txtusername.Text) != null)
            {

                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }

            bool successfullCreateAccount = true;

            try
            {
                VPN newvpn = new VPN();
                newvpn.DepartmentID=ddldepartment.SelectedValue.ToInt();
                newvpn.UserTypeID = DropDownList1.SelectedValue.ToInt();
                newvpn.UserID = ddluserid.SelectedValue.ToInt();
                newvpn.Username = txtusername.Text;
                newvpn.Password = txtpass.Text;
                newvpn.VPNDescription = txtdes.Text;
                VPNsRepository vpnir = new VPNsRepository();
                vpnir.Savevpn(newvpn);

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
            Redirector.Goto(Redirector.PageName.VPNsManagment);
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


        }

      
    }
}