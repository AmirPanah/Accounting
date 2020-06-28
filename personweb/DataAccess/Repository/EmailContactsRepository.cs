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
  public  class EmailContactsRepository
    {
        private Connection conn;


         public EmailContactsRepository()
          {
              conn = new Connection();
          }

     
        public EmailContact FindByid(int id)
        {
            EmailContact result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.EmailContacts
                          where r.ID==id
                          select r).FirstOrDefault();
            }

            return result;
        }
        public EmailContact FindByEmailAddrress(string email)
        {
            EmailContact result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.EmailContacts
                          where r.EmailAddrress==email
                          select r).FirstOrDefault();
            }

            return result;
        }
          public DataTable GetAllEmailContacts()
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in DC.EmailContacts
                      orderby r.ID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable Getexeldata()
          {
              List<VEmailContact> result = new List<VEmailContact>();

              using (PersonsDBEntities ent = conn.GetContext())
              {
                  System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                      WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

                  if (connectionStrings.Count > 0)
                  {
                      DataContext db = new DataContext(connectionStrings["ConnectionString"].ConnectionString);

                      result = db.ExecuteQuery<VEmailContact>(
                          string.Format(
                              "SELECT * from VEmailContacts"
                          )
                      ).ToList();
                  }
              }
              return PersonTools.ToDataTable(result);
          }

          public DataTable GetEmailContactList(int EmailContactid)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                      r.ID==EmailContactid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable GetEmailpersonContactList(int userid,int usertypeid)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                      r.UserID == userid && r.UserTypeID==usertypeid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable SearchEmailAddrress(string searchTitle)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                          r.EmailAddrress.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchpersonEmailAddrress(string searchTitle, int UserTypeID, int UserID)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                          r.EmailAddrress.Contains(searchTitle) && r.UserID==UserID && r.UserTypeID==UserTypeID


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                          r.ID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable SearchUserTypeid(int searchText)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                          r.UserTypeID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchUserid(int searchText)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                          r.UserID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchEmailTypeid(int searchText)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                          r.EmailTypeID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchpersonEmailTypeid(int searchText,int UserTypeID,int UserID)
          {
              List<EmailContact> result = new List<EmailContact>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EmailContact> pl =
                      from r in pb.EmailContacts
                      where
                          r.EmailTypeID == searchText && r.UserID==UserID && r.UserTypeID==UserTypeID


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public void SaveEmailContact(EmailContact EmailContact)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {

                  if (EmailContact.ID > 0)
                  {
                      //==== UPDATE ====
                      DC.EmailContacts.Attach(EmailContact);
                      DC.Entry(EmailContact).State = EntityState.Modified;
              
                  }
                  else
                  {
                      //==== INSERT ====
                      DC.EmailContacts.Add(EmailContact);
                     
                  }

                  DC.SaveChanges();
              }
          }

          public int EmailContactCount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.EmailContacts
                       select r).Count();
              }

              return result;
          }


          public void DeleteEmailContact(int EmailContactid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.EmailContacts
                      where r.ID==EmailContactid

                      select r;

                  if (selectedGroup != null)
                  {
                      DC.EmailContacts.Remove(selectedGroup as EmailContact);
                      DC.SaveChanges();
                  }
              }
          }
          public void DeleteEmailContact(List<int> EmailContactid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.EmailContacts
                      join at in EmailContactid
                      on r.ID equals at
                      select r;

                  foreach (var tel in selectedGroups)
                  {
                      DC.EmailContacts.Remove(tel as EmailContact);
                  }

                  DC.SaveChanges();
              }
          }
          public void DeletepersonEmailContact(List<int> EmailContactid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.EmailContacts
                      join at in EmailContactid
                      on r.UserID equals at
                      select r;

                  foreach (var tel in selectedGroups)
                  {
                      DC.EmailContacts.Remove(tel as EmailContact);
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

                      db.ExecuteCommand("TRUNCATE TABLE EmailContact");
                  }
              }
          }
    }
}
