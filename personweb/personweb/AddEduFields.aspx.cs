﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DataAccess;
using DataAccess.Repository;
using System.Drawing;


namespace personweb
{
    public partial class AddEduFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ClearForm()
        {
            TextBox1.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
          
            EduFieldsRepository edu = new EduFieldsRepository();
            if (edu.FindBytitle(TextBox1.Text) != null)
            {
                
                PersonTools.ShowMessage(lblmessage, Resources.DashboardText.errDuplicateUsername, Color.Red);
                return;
            }



            bool successfullCreateAccount = true;


            try
            {
            EduField newfield = new EduField();
         newfield.FieldTitle= TextBox1.Text.Trim();
                            
                EduFieldsRepository efir = new EduFieldsRepository();
                efir.SaveEdufield(newfield);

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

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Redirector.Goto(Redirector.PageName.EduFieldsManager);
        }
    }
}