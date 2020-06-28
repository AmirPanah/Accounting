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
    public partial class PersonsAdmins : System.Web.UI.Page
    {
        public void LoadStdData()
        {
            try
            {

            
                
                PersonsAdminsRepository pair = new PersonsAdminsRepository();
                Session["padata"] = pair.GetAlldata();
                GridView1.DataSource = Session["padata"];
                GridView1.DataBind();

                lblrecordcount.Text = string.Format("{0} : {1}", pair.PersonAdmincount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

                lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["padata"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);

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
                //  ClearForm();
                LoadStdData();
            }
        }


      

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadStdData();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            lblmessage.Text = "";
            if (txtsearch.Text.Length > 0)
            {
                if (DropDownList1.SelectedValue == "0")
                {
                    try
                    {

                        PersonsAdminsRepository pair = new PersonsAdminsRepository();
                        Session["stddatafindid"] = pair.Searchid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["stddatafindid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", pair.PersonAdmincount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }

                }
                if (DropDownList1.SelectedValue == "1")
                {
                    try
                    {


                        PersonsAdminsRepository pair = new PersonsAdminsRepository();
                        Session["stddatafindcode"] = pair.SearchFirstName(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindcode"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", pair.PersonAdmincount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindcode"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }
                }
                if (DropDownList1.SelectedValue == "2")
                {
                    try
                    {


                        PersonsAdminsRepository pair = new PersonsAdminsRepository();
                        Session["stddatafindFirstName"] = pair.SearchLastName(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindFirstName"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", pair.PersonAdmincount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindFirstName"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }
                }
                if (DropDownList1.SelectedValue == "3")
                {
                    try
                    {


                        PersonsAdminsRepository pair = new PersonsAdminsRepository();

                        Session["stddatafindLasttName"] = pair.SearchUserName(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindLasttName"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", pair.PersonAdmincount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindLasttName"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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
                LoadStdData();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Redirector.Goto(Redirector.PageName.AddPersonsAdmin);
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


                    PersonsAdminsRepository pair = new PersonsAdminsRepository();
                    pair.DeletePerson(selectedRows);
                    LoadStdData();
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