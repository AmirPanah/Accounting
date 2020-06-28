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
    public partial class AddEduTendencies : System.Web.UI.Page
    {
        public void loadform()
        {
            EduFieldsRepository efir = new EduFieldsRepository();

            DataTable dt = efir.GetAllEduFields();

            ddlfield.Items.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                ddlfield.Items.Add(new ListItem(dr["FieldTitle"].ToString(), dr["FieldID"].ToString()));
            }
             
        }

        public void ClearForm()
        {
            TextBox1.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                loadform();
            }
            
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.EduTendenciesManagment);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
           VEduTendenciesRepository ten = new VEduTendenciesRepository();
           if (ten.FindByTendencyTitle(TextBox1.Text) != null)
            {
                

                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }



            bool successfullCreateAccount = true;

 
            try
            {
              
            
            EduTendency newTendency = new EduTendency();

                VEduTendenciesRepository ctrir = new VEduTendenciesRepository();
                newTendency.TendencyTitle = TextBox1.Text.Trim();

                newTendency.FieldID = ddlfield.SelectedValue.ToInt();
                ctrir.SaveTen(newTendency);
                ClearForm();
               
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

       
    }
}