using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DataAccess.Repository
{
 public   class TelContactsRepository
    {
           private Connection conn;


         public TelContactsRepository()
          {
              conn = new Connection();
          }

     
        public TelContact FindByid(int id)
        {
            TelContact result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.TelContacts
                          where r.ID==id
                          select r).FirstOrDefault();
            }

            return result;
        }
        public TelContact FindBytelnumber(string tel)
        {
            TelContact result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.TelContacts
                          where r.TelNumber==tel
                          select r).FirstOrDefault();
            }

            return result;
        }

          public DataTable GetAllTelContacts()
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in DC.TelContacts
                      orderby r.ID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Getexeldata()
          {
              List<VTelContact> result = new List<VTelContact>();

              using (PersonsDBEntities ent = conn.GetContext())
              {
                  System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                      WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

                  if (connectionStrings.Count > 0)
                  {
                      DataContext db = new DataContext(connectionStrings["ConnectionString"].ConnectionString);

                      result = db.ExecuteQuery<VTelContact>(
                          string.Format(
                              "SELECT *  from VTelContacts"
                          )
                      ).ToList();
                  }
              }
              return PersonTools.ToDataTable(result);
          }
          public DataTable GetTelContactList(int TelContactid)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts
                      where
                      r.ID==TelContactid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable GetTelpersonContactList(int userid, int usertypeid)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts
                      where
                      r.UserID == userid && r.UserTypeID == usertypeid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

         
          public DataTable SearchpersonTelNumber(string searchTitle, int UserTypeID, int UserID)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts

                      where
                          r.TelNumber.Contains(searchTitle) && r.UserID==UserID && r.UserTypeID==UserTypeID


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public DataTable SearchTelNumber(string searchTitle)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts

                      where
                          r.TelNumber.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts
                      where
                          r.ID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable SearchUserTypeid(int searchText)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts
                      where
                          r.UserTypeID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchUserid(int searchText)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts
                      where
                          r.UserID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchTelTypeid(int searchText)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts
                      where
                          r.TelTypeID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public DataTable SearchpersonTelTypeid(int searchText, int UserTypeID, int UserID)
          {
              List<TelContact> result = new List<TelContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelContact> pl =
                      from r in pb.TelContacts
                      where
                      r.TelTypeID== searchText && r.UserID == UserID && r.UserTypeID == UserTypeID
                                                    

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public void SavetelContact(TelContact TelContact)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {

                  if (TelContact.ID > 0)
                  {
                      //==== UPDATE ====
                      DC.TelContacts.Attach(TelContact);
                     DC.Entry(TelContact).State=EntityState.Modified;
                    
                  }
                  else
                  {
                      //==== INSERT ====
                  
                      DC.TelContacts.Add(TelContact);
                  }

                  DC.SaveChanges();
              }
          }

          public int TelContactCount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.TelContacts
                       select r).Count();
              }

              return result;
          }


          public void DeleteTelContact(int TelContactid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.TelContacts
                      where r.ID==TelContactid

                      select r;

                  if (selectedGroup != null)
                  {
                      DC.TelContacts.Remove(selectedGroup as TelContact);
                      DC.SaveChanges();
                  }
              }
          }
          public void DeleteTelContact(List<int> TelContactid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.TelContacts
                      join at in TelContactid
                      on r.ID equals at
                      select r;

                  foreach (var tel in selectedGroups)
                  {
                      DC.TelContacts.Remove(tel as TelContact);
                  }

                  DC.SaveChanges();
              }
          }
          public void DeletepersonTelContact(List<int> EmailContactid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.TelContacts
                      join at in EmailContactid
                      on r.UserID equals at
                      select r;

                  foreach (var tel in selectedGroups)
                  {
                      DC.TelContacts.Remove(tel as TelContact);
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

                      db.ExecuteCommand("TRUNCATE TABLE TelContact");
                  }
              }
          }
    }
}
