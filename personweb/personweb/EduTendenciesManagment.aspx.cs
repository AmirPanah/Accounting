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
    public partial class EduTendenciesManageraspx : System.Web.UI.Page
    {
        public void LoadTendencyData()
        {

          
            VEduTendenciesRepository vtr = new VEduTendenciesRepository();
            Session["TendencyData"] = vtr.GetAllTendency();
         
            GridView1.DataSource = Session["TendencyData"];


            GridView1.DataBind();

            lblrecordcount.Text = string.Format("{0} : {1}", vtr.tendencycount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

            lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["TendencyData"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  ClearForm();
                LoadTendencyData();
            }
        }
        
       
      

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
           
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

                        VEduTendenciesRepository vtrir = new VEduTendenciesRepository();
                        Session["Tendencydatafindid"] = vtrir.Searchid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["Tendencydatafindid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vtrir.tendencycount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["Tendencydatafindid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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



                        VEduTendenciesRepository vtrir = new VEduTendenciesRepository();

                        Session["Tendencydatafindtitle"] = vtrir.Searchtitle(txtsearch.Text.ToString());
                        GridView1.DataSource = Session["Tendencydatafindtitle"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vtrir.tendencycount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["Departmentdatafindtitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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

                        VEduTendenciesRepository vtrir = new VEduTendenciesRepository();

                        Session["Tendencydatafindtitle"] = vtrir.searchFieldtitle(txtsearch.Text.ToString());
                        GridView1.DataSource = Session["Tendencydatafindtitle"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vtrir.tendencycount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["Departmentdatafindtitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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
                LoadTendencyData();
            }
           
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Redirector.Goto(Redirector.PageName.AddEduTendency);
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

                    VEduTendenciesRepository vtrir = new VEduTendenciesRepository();

                    vtrir.Deletetendency(selectedRows);
                    LoadTendencyData();

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