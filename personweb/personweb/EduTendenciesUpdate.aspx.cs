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
    public partial class EduTendenciesUpdate : System.Web.UI.Page
    {
        public void LoadTendencyData(string Tendencyid)
        {
            try
            {
                EduFieldsRepository efir = new EduFieldsRepository();

                DataTable dt = efir.GetAllEduFields();

                ddlfield.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ddlfield.Items.Add(new ListItem(dr["FieldTitle"].ToString(), dr["FieldID"].ToString()));
                }
            

                VEduTendenciesRepository vtrir = new VEduTendenciesRepository();
                VEduTendency tendency = vtrir.FindByid(Tendencyid.ToInt());

                if (tendency != null)
                {

                    lblTendencytid.Text = tendency.TendencyID.ToString();

                    Label7.Text = tendency.FieldTitle;
                    lbltitle.Text = tendency.TendencyTitle;
                    
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
            catch
            {
                Redirector.Goto(Redirector.PageName.errorpage);

            }

        }

        public void ClearForm()
        {
            TextBox1.Text = "";
            Session["TendencyID"] = "";
            Session["TendencyTitle"] = "";
            lblTendencytid.Text = "";
            TextBox1.Text = "";
            Label7.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                object o = Page.RouteData.Values["TendencyID"];
                if (o != null)
                {
                    LoadTendencyData(o.ToString());
                    
                }
                else
                {
                    Redirector.Goto(Redirector.PageName.errorpage);
                }

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (lblTendencytid.Text.Length > 0)
            {

                try
                {
                    

                 
 VEduTendenciesRepository vtrir = new VEduTendenciesRepository();
                    if (vtrir.FindByTendencyTitle(TextBox1.Text) != null)
                    {


                        PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errRepeatTitle, Color.Red);

                        return;
                    }
                   

                    
                    EduTendency edittendency = new EduTendency();
                    if ((TextBox1.Text.Length > 0) && (TextBox1.Text != lbltitle.Text))
                    {
 edittendency.TendencyTitle = TextBox1.Text;
                    }
                   
                    edittendency.TendencyID = lblTendencytid.Text.ToInt();
                    edittendency.FieldID = ddlfield.SelectedValue.ToInt();

                    vtrir.SaveTen(edittendency);
                  
                    ClearForm();


                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.msgUpdateSuccessfull, Color.Green);

                }
                catch
                {
                    PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errUpdateFailed, Color.Red);
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.EduTendenciesManagment);

        }
    }
}