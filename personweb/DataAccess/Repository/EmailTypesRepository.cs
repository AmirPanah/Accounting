using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DataAccess.Repository
{
  public  class EmailTypesRepository
    {
         private Connection conn;


        public EmailTypesRepository()
          {
              conn = new Connection();
          }

        public EmailType FindBytitle(string title)
        {
            EmailType result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.EmailTypes
                          where r.EmailTypeTitle==title
                          select r).FirstOrDefault();
            }

            return result;
        }
        public EmailType FindByid(int id)
        {
            EmailType result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.EmailTypes
                          
                          where r.EmailTypeID==id
                          select r).FirstOrDefault();
            }

            return result;
        }

          public DataTable GetAllEmailTypes()
          {
              List<EmailType> result = new List<EmailType>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<EmailType> pl =
                      from r in DC.EmailTypes
                      orderby r.EmailTypeID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable GetFacultyList(int emailtypeid)
          {
              List<EmailType> result = new List<EmailType>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailType> pl =
                      from r in pb.EmailTypes
                      where
                      r.EmailTypeID==emailtypeid
                    

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchTitle(string searchTitle)
          {
              List<EmailType> result = new List<EmailType>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailType> pl =
                      from r in pb.EmailTypes
                      where

                         r.EmailTypeTitle.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<EmailType> result = new List<EmailType>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailType> pl =
                      from r in pb.EmailTypes
                      where

                           r.EmailTypeID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public void SaveEmailType(EmailType emailtype)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {

                  if (emailtype.EmailTypeID > 0)
                  {
                      //==== UPDATE ====
                      DC.EmailTypes.Attach(emailtype);
                      DC.Entry(emailtype).State = EntityState.Modified;



                  }
                  else
                  {
                      //==== INSERT ====
                      DC.EmailTypes.Add(emailtype);
                  }

                  DC.SaveChanges();
              }
          }

          public int EmailtypeCount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.EmailTypes
                       select r).Count();
              }

              return result;
          }


          public void DeleteEmailType(int EmailTypeid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.EmailTypes
                      where r.EmailTypeID==EmailTypeid
                     
                      select r;

                  if (selectedGroup != null)
                  {
                      DC.EmailTypes.Remove(selectedGroup as EmailType);

                      DC.SaveChanges();
                  }
              }
          }
          public void DeleteEmailType(List<int> EmailTypeid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.EmailTypes
                      join at in EmailTypeid
                      on r.EmailTypeID equals at
                      select r;

                  foreach (var Email in selectedGroups)
                  {
                      DC.EmailTypes.Remove(Email as EmailType);
                    
                  }

                  DC.SaveChanges();
              }
          }
          public void DeleteAll()
          {
              using (PersonsDBEntities pb = conn.GetContext())
              {
                  System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                      WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

                  if (connectionStrings.Count > 0)
                  {
                      System.Data.Linq.DataContext db = new System.Data.Linq.DataContext(connectionStrings["ConnectionString"].ConnectionString);

                      db.ExecuteCommand("TRUNCATE TABLE EmailType");
                  }
              }
          }
    }
}
