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
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace personweb
{
    public partial class TelContactsManagment : System.Web.UI.Page
    {

        public void LoadTelContactData()
        {

             TelContactsRepository dir = new  TelContactsRepository();
            Session["TelContactData"] = dir.GetAllTelContacts();

            GridView1.DataSource = Session["TelContactData"];


            GridView1.DataBind();
           
            lblrecordcount.Text = string.Format("{0} : {1}", dir.TelContactCount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

            lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["TelContactData"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  ClearForm();
                LoadTelContactData();
            }
        }

     

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadTelContactData();
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

                         TelContactsRepository dir = new  TelContactsRepository();

                        Session["ecid"] = dir.Searchid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["ecid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", dir. TelContactCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["ecid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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


                         TelContactsRepository dir = new  TelContactsRepository();

                        Session["ecutid"] = dir.SearchUserTypeid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["ecutid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", dir.TelContactCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["ecutid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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


                         TelContactsRepository dir = new  TelContactsRepository();

                        Session["ecuid"] = dir.SearchUserid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["ecuid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", dir.TelContactCount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["ecuid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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


                         TelContactsRepository dir = new  TelContactsRepository();

                        Session["ecetid"] = dir.SearchTelTypeid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["ecetid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", dir. TelContactCount().ToString(), Resources.DashboardText.RecordCount);
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


                         TelContactsRepository dir = new  TelContactsRepository();

                        Session["eceaid"] = dir.SearchTelNumber(txtsearch.Text.ToString());
                        GridView1.DataSource = Session["eceaid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", dir.TelContactCount().ToString(), Resources.DashboardText.RecordCount);
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
                LoadTelContactData();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Redirector.Goto(Redirector.PageName.AddTelContact);
        }

        


        private void DumpExcel(DataTable tbl, string fileNameWithoutExtension)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Requests");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(tbl, true);

                //Format the header for column 1-3
                using (ExcelRange rng = ws.Cells["A1:C1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                //Example how to Format Column 1 as numeric 
                using (ExcelRange col = ws.Cells[2, 1, 2 + tbl.Rows.Count, 1])
                {
                    col.Style.Numberformat.Format = "#,##0.00";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                //Write it back to the client
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", string.Format("attachment;  filename={0}.xlsx", fileNameWithoutExtension));
                Response.BinaryWrite(pck.GetAsByteArray());
            }
        }
        

     

        protected void Button3_Click2(object sender, EventArgs e)
        {
            TelContactsRepository vstdir = new TelContactsRepository();

            if (vstdir.Getexeldata() != null)
            {
                DumpExcel(vstdir.Getexeldata(), "TelContacts");
            }
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
                    TelContactsRepository dir = new TelContactsRepository();
                    dir.DeleteTelContact(selectedRows);
                    LoadTelContactData();


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