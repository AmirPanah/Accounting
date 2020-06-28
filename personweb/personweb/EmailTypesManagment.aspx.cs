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
    public partial class EmailTypesManagment : System.Web.UI.Page
    {
        public void LoadEmailTypeData()
        {

        
            EmailTypesRepository etir = new EmailTypesRepository();
            Session["EmailTypeData"] = etir.GetAllEmailTypes();

            GridView1.DataSource = Session["EmailTypeData"];


            GridView1.DataBind();
           
            lblrecordcount.Text = string.Format("{0} : {1}", etir.EmailtypeCount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

            lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["EmailTypeData"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  ClearForm();
                LoadEmailTypeData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Redirector.Goto(Redirector.PageName.AddEmailType);
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
                     
                        
                        EmailTypesRepository etir = new EmailTypesRepository();
                        Session["EmailTypedatafindid"] = etir.Searchid(txtsearch.Text.ToInt());

                        GridView1.DataSource = Session["EmailTypedatafindid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", etir.EmailtypeCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["EmailTypedatafindid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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

                      
               
                        EmailTypesRepository etir=new EmailTypesRepository();
                        Session["EmailTypedatafindtitle"] = etir.SearchTitle(txtsearch.Text.ToString());
                        GridView1.DataSource = Session["EmailTypedatafindtitle"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", etir.EmailtypeCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["EmailTypedatafindtitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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
LoadEmailTypeData();          
            }
           
        
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
             GridView1.PageIndex = e.NewPageIndex;
           LoadEmailTypeData();  
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

                    EmailTypesRepository etir = new EmailTypesRepository();
                    etir.DeleteEmailType(selectedRows);
                    LoadEmailTypeData();

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