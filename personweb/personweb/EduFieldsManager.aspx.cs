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
    public partial class EduFieldsManager : System.Web.UI.Page
    {
        public void LoadFieldData()
        {
      
            EduFieldsRepository efir = new EduFieldsRepository();
            Session["FieldData"] = efir.GetAllEduFields();

            GridView1.DataSource = Session["FieldData"];


            GridView1.DataBind();

            lblrecordcount.Text = string.Format("{0} : {1}", efir.FieldCount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

            lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["FieldData"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  ClearForm();
                LoadFieldData();
            }
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
                        EduFieldsRepository efir = new EduFieldsRepository();
                      
                        Session["Fielddatafindid"] = efir.Searchid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["Fielddatafindid"];
                        GridView1.DataBind();
                        lblrecordcount.Text = string.Format("{0} : {1}", efir.FieldCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["Fielddatafindid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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

                        EduFieldsRepository efir = new EduFieldsRepository();
                        Session["Fielddatafindtitle"] = efir.SearchTitle(txtsearch.Text.ToString());
                        GridView1.DataSource = Session["Fielddatafindtitle"];
                        GridView1.DataBind();
                        lblrecordcount.Text = string.Format("{0} : {1}", efir.FieldCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["Fielddatafindtitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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
                LoadFieldData();

            }
           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadFieldData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Redirector.Goto(Redirector.PageName.AddEduField);
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
                    EduFieldsRepository efir = new EduFieldsRepository();
                    efir.DeleteEduField(selectedRows);


                    LoadFieldData();

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