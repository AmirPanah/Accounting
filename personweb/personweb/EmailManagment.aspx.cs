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
    public partial class EmailManagment : System.Web.UI.Page
    {


        public void LoadEmailContactData(string userid,string usertypeid)
        {
            try
            {

                EmailContactsRepository dir = new EmailContactsRepository();
                Session["EmailPersonContactData"] = dir.GetEmailpersonContactList(userid.ToInt(), usertypeid.ToInt());

                GridView1.DataSource = Session["EmailPersonContactData"];


                GridView1.DataBind();

                lblrecordcount.Text = string.Format("{0} : {1}", dir.EmailContactCount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

                lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["EmailPersonContactData"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);

                switch (Session["UserTypeID"].ToString())
                {
                    case "1":
                        {
                            VStudentsRepository vstdir = new VStudentsRepository();
                            VStudent std = vstdir.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "دانشجو" + ":" + std.FirstName + " " + std.LastName;
                        }
                        break;
                    case "2":
                        {
                            VLecturersRepository vlec = new VLecturersRepository();
                            VLecturer lec = vlec.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "استاد" + ":" + lec.FirstName + " " + lec.LastName;
                        }
                        break;
                    case "3":
                        {
                            VEmployeesRepository vlec = new VEmployeesRepository();
                            VEmployee emp = vlec.FindByid(Session["UserID"].ToString().ToInt());
                            Label9.Text = "کارمند" + ":" + emp.FirstName + " " + emp.LastName;
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

                object o = Page.RouteData.Values["UserTypeID"];
                Session["UserTypeID"] = o.ToString();
                object oo=Page.RouteData.Values["UserID"];
                Session["UserID"]=oo.ToString();
                if (o != null && oo!=null)
                {
                    LoadEmailContactData(Session["UserID"].ToString(), Session["UserTypeID"].ToString());
                    
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

       
       

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
             lblmessage.Text = "";
            if (txtsearch.Text.Length > 0)
            {
                
              

                if (DropDownList1.SelectedValue == "3")
                {
                    try
                    {


                        EmailContactsRepository dir = new EmailContactsRepository();
                        
                        Session["ecetid"] = dir.SearchpersonEmailTypeid(txtsearch.Text.ToInt(),Session["UserTypeID"].ToString().ToInt(),Session["UserID"].ToString().ToInt());
                        GridView1.DataSource = Session["ecetid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", dir.EmailContactCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["ecetid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {
                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }
                }
                if (DropDownList1.SelectedValue == "4")
                {
                    try
                    {


                        EmailContactsRepository dir = new EmailContactsRepository();
                        
                        Session["eceaid"] = dir.SearchpersonEmailAddrress(txtsearch.Text.ToString(), Session["UserTypeID"].ToString().ToInt(),Session["UserID"].ToString().ToInt());
                        GridView1.DataSource = Session["eceaid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", dir.EmailContactCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["eceaid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {
                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }
                }


            }
            else
            {
                  LoadEmailContactData(Session["UserID"].ToString(), Session["UserTypeID"].ToString());
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
          GridView1.PageIndex = e.NewPageIndex;
             LoadEmailContactData(Session["UserID"].ToString(), Session["UserTypeID"].ToString());
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddEmail/" + Session["UserTypeID"].ToString() + "/" + Session["UserID"].ToString() + "");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> selectedRows = new List<int>();

                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    if ((gvr.FindControl("CheckBox2") as CheckBox).Checked == true)
                    {
                        selectedRows.Add(gvr.Cells[0].Text.ToInt());
                    }
                }

                if (selectedRows.Count > 0)
                {
                    EmailContactsRepository dir = new EmailContactsRepository();
                    dir.DeleteEmailContact(selectedRows);
                    LoadEmailContactData(Session["UserID"].ToString(), Session["UserTypeID"].ToString());


                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgDeleteSuccessfull, Color.Green);

                }
            }
            catch
            {
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDeleteFailed, Color.Red);
            }
        }

       

      
    }
}