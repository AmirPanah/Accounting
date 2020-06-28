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
    public partial class LecturersManagment : System.Web.UI.Page
    {
        public void LoadStdData()
        {
            try
            {


                VLecturersRepository vstdir = new VLecturersRepository();
                Session["lecdata"] = vstdir.GetAllVLec();
                GridView1.DataSource = Session["lecdata"];


                GridView1.DataBind();

                lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString().ToFarsiNumber(), Resources.DashboardText.RecordCount);

                lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["lecdata"] as DataTable).Rows.Count.ToString().ToFarsiNumber(), Resources.DashboardText.SelectRecordCount);

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


                        VLecturersRepository vstdir = new VLecturersRepository();

                        Session["stddatafindid"] = vstdir.Searchlecid(txtsearch.Text.ToInt());
                        GridView1.DataSource = Session["stddatafindid"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindid"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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


                        VLecturersRepository vstdir = new VLecturersRepository();
                        Session["stddatafindFirstName"] = vstdir.SearchFirstName(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindFirstName"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString(), Resources.DashboardText.RecordCount);
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


                        VLecturersRepository vstdir = new VLecturersRepository();
                        Session["stddatafindLasttName"] = vstdir.SearchLastName(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindLasttName"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindLasttName"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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


                        VLecturersRepository vstdir = new VLecturersRepository();
                        Session["stddatafindUsername"] = vstdir.SearchUserName(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindUsername"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindUsername"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }
                }
                if (DropDownList1.SelectedValue == "5")
                {
                    try
                    {


                        VLecturersRepository vstdir = new VLecturersRepository();
                        Session["stddatafindFacultyTitle"] = vstdir.SearchFacultyTitle(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindFacultyTitle"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindFacultyTitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }
                }

               

                if (DropDownList1.SelectedValue == "7")
                {
                    try
                    {


                        VLecturersRepository vstdir = new VLecturersRepository();
                        Session["stddatafindFielsTitle"] = vstdir.SearchFieldTitle(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindFielsTitle"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindFielsTitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
                    }
                    catch
                    {

                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errSearch, Color.Red);
                        lblrecordcount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", "0", Resources.DashboardText.SelectRecordCount);
                    }
                }

                if (DropDownList1.SelectedValue == "8")
                {
                    try
                    {


                        VLecturersRepository vstdir = new VLecturersRepository();
                        Session["stddatafindTendencyTitle"] = vstdir.SearchTendencyTitle(txtsearch.Text);
                        GridView1.DataSource = Session["stddatafindTendencyTitle"];
                        GridView1.DataBind();

                        lblrecordcount.Text = string.Format("{0} : {1}", vstdir.leccount().ToString(), Resources.DashboardText.RecordCount);
                        lblSelectedDataCount.Text = string.Format("{0} : {1}", (Session["stddatafindTendencyTitle"] as DataTable).Rows.Count.ToString(), Resources.DashboardText.SelectRecordCount);
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
            Redirector.Goto(Redirector.PageName.AddLecturer);
         
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

                    VLecturersRepository vstdir = new VLecturersRepository();
                    vstdir.Deletelec(selectedRows);
                    //   vstdir.Deletelecturer(selectedRows);
                    LoadStdData();

                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgDeleteSuccessfull, Color.Green);


                    EmailContactsRepository emrir = new EmailContactsRepository();
                    emrir.DeletepersonEmailContact(selectedRows);
                    LoadStdData();

                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgDeleteSuccessfull, Color.Green);

                    TelContactsRepository trir = new TelContactsRepository();
                    trir.DeletepersonTelContact(selectedRows);
                    LoadStdData();


                }
            }
            catch
            {
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDeleteFailed, Color.Red);
            }
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
        protected void Button3_Click(object sender, EventArgs e)
        {

            VLecturersRepository vstdir = new VLecturersRepository();

            if (vstdir.Getexeldata() != null)
            {
                DumpExcel(vstdir.Getexeldata(), "VLecturers");
            }


        }

       

    }
}