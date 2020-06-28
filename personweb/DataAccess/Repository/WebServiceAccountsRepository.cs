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
 public   class WebServiceAccountsRepository
    {
       private Connection conn;


       public WebServiceAccountsRepository()
           {
               conn = new Connection();
           }

         
           public WebServiceAccount FindByUserName(string UserName)
           {
               WebServiceAccount result = null;

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                   result = (from r in DC.WebServiceAccounts
                             where r.Username==UserName
                             select r).FirstOrDefault();
               }

               return result;
           }
           public WebServiceAccount FindByid(int id)
           {
               WebServiceAccount result = null;

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                   result = (from r in DC.WebServiceAccounts
                             where r.AccountID == id
                             select r).FirstOrDefault();
               }

               return result;
           }

           public DataTable GetAlldata()
           {
               List<WebServiceAccount> result = new List<WebServiceAccount>();

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   IEnumerable<WebServiceAccount> pl =
                       from r in DC.WebServiceAccounts
                       orderby r.AccountID
                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }


           public DataTable GetwebaccountList(int id)
           {
               List<WebServiceAccount> result = new List<WebServiceAccount>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<WebServiceAccount> pl =
                       from r in pb.WebServiceAccounts
                       where
                       r.AccountID == id

                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }

          
        public DataTable SearchUserName(string searchTitle)
           {
               List<WebServiceAccount> result = new List<WebServiceAccount>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<WebServiceAccount> pl =
                       from r in pb.WebServiceAccounts
                       where
                           r.Username.Contains(searchTitle)


                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }

        
           public DataTable Searchid(int searchText)
           {
               List<WebServiceAccount> result = new List<WebServiceAccount>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<WebServiceAccount> pl =
                       from r in pb.WebServiceAccounts
                       where
                           r.AccountID == searchText


                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }


           public void Saveaccount(WebServiceAccount account)
           {
               using (PersonsDBEntities DC = conn.GetContext())
               {


                   if (account.AccountID > 0)
                   {
                       //==== UPDATE ====
                       DC.WebServiceAccounts.Attach(account);
                       DC.Entry(account).State = EntityState.Modified;



                   }
                   else
                   {
                       //==== INSERT ====
                       DC.WebServiceAccounts.Add(account);
                   }

                   DC.SaveChanges();
               }
           }

           public int webacountcount()
           {
               int result = 0;

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   result =
                       (from r in DC.WebServiceAccounts
                        select r).Count();
               }

               return result;
           }


           public void DeleteAccount(int id)
           {
               using (PersonsDBEntities DC = conn.GetContext())
               {
                   var selectedGroup =
                       from r in DC.WebServiceAccounts
                       where r.AccountID == id
                       select r;

                   if (selectedGroup != null)
                   {
                       DC.WebServiceAccounts.Remove(selectedGroup as WebServiceAccount);
                       DC.SaveChanges();
                   }
               }
           }
           public void DeleteAccount(List<int> id)
           {

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   var selectedGroups =
                       from r in DC.WebServiceAccounts
                       join at in id
                       on r.AccountID equals at
                       select r;

                   foreach (var pers in selectedGroups)
                   {
                       DC.WebServiceAccounts.Remove(pers as WebServiceAccount);
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

                       db.ExecuteCommand("TRUNCATE TABLE WebServiceAccount");
                   }
               }
           }
      
    }
}
