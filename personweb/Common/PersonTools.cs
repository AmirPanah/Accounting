using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using PersianCalander;


namespace Common
{
  public static  class PersonTools
    {
        public static void ShowMessage(Label lbl, string msg, Color col)
        {

            lbl.Text = msg;
            lbl.ForeColor = col;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
            
        }
        static public string AddFirstZero(int num)
        {
            string retValue = num.ToString();

            if (num < 10)
            {
                retValue = "0" + retValue;
            }

            return retValue;
        }
        static public string CurrentTime()
        {
            return AddFirstZero(DateTime.Now.Hour) + ":" + AddFirstZero(DateTime.Now.Minute);
        }

        static public string CurrentTimeWithoutColons()
        {
            return AddFirstZero(DateTime.Now.Hour) + AddFirstZero(DateTime.Now.Minute);
        }
        static public string CurrentPersianDate()
        {

            FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());

            string d, m;
            d = pd.Day.ToString();
            m = pd.Month.ToString();

            if (d.Length == 1)
            {
                d = "0" + d;
            }

            if (m.Length == 1)
            {
                m = "0" + m;
            }

            return pd.Year.ToString() + "/" + m + "/" + d;
        }

        static public string CurrentPersianDateWithoutSlash()
        {
            FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now.ToString());

            string d, m;
            d = pd.Day.ToString();
            m = pd.Month.ToString();

            if (d.Length == 1)
            {
                d = "0" + d;
            }

            if (m.Length == 1)
            {
                m = "0" + m;
            }

            return pd.Year.ToString() + m + d;
        }
        static public string FarsiNum(string numStr)
        {
            string trim = numStr.Trim();
            char[] temp = new char[trim.Length];

            int i = 0;

            foreach (char c in trim)
            {
                if (char.IsDigit(c))
                {
                    temp[i] = ((char)(Convert.ToInt32(c) + 1728));
                }
                else
                {
                    temp[i] = c;
                }

                i++;
            }

            string persianNumber = "";
            foreach (char c in temp)
            {
                persianNumber += c.ToString();
            }

            return persianNumber;
        }

    }

}
