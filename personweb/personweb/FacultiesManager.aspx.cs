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
    public partial class FacultiesManager : System.Web.UI.Page
    {

        public void LoadFacultyData()
        {
            FacultiesRepositpry fir = new FacultiesRepositpry();

            Session["FacultyData"] = fir.GetAllFaculties();

            GridView1.DataSource = Session["FacultyData"];


            GridView1.DataBind();

            lblrecordcount.Text = string.Format("{0} : {1}", fir.FacultyCount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

            lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["FacultyData"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  ClearForm();
                LoadFacultyData();
            }

        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadFacultyData();
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
                         FacultiesRepositpry fir = new FacultiesRepositpry();
                        Session["Facultydatafindid"] = fir.Searchid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["Facultydatafindid"];
                        GridView1.DataBind();
                        lblrecordcount.Text = string.Format("{0} : {1}",fir.FacultyCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["Facultydatafindid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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
                        
                        FacultiesRepositpry fir = new FacultiesRepositpry();

                        Session["Facultydatafindtitle"] = fir.SearchTitle(txtsearch.Text.ToString());
                        GridView1.DataSource = Session["Facultydatafindtitle"];
                        GridView1.DataBind();
                        lblrecordcount.Text = string.Format("{0} : {1}", fir.FacultyCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["Facultydatafindtitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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
                LoadFacultyData();
                   
                }
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Redirector.Goto(Redirector.PageName.AddFaculty);
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

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

                    FacultiesRepositpry fir = new FacultiesRepositpry();
                    fir.Deletefaculty(selectedRows);

                    LoadFacultyData();

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