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
   public class PersonsAdminsRepository
    {
      
           private Connection conn;


           public PersonsAdminsRepository()
           {
               conn = new Connection();
           }

           public PersonsAdmin FindByFirstName(string FirstName)
           {
               PersonsAdmin result = null;

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                   result = (from r in DC.PersonsAdmins
                             where r.FirstName == FirstName
                             select r).FirstOrDefault();
               }

               return result;
           }
           public PersonsAdmin FindByUserName(string UserName)
           {
               PersonsAdmin result = null;

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                   result = (from r in DC.PersonsAdmins
                             where r.Username==UserName
                             select r).FirstOrDefault();
               }

               return result;
           }
           public PersonsAdmin FindByid(int id)
           {
               PersonsAdmin result = null;

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                   result = (from r in DC.PersonsAdmins
                             where r.AdminID == id
                             select r).FirstOrDefault();
               }

               return result;
           }

           public DataTable GetAlldata()
           {
               List<PersonsAdmin> result = new List<PersonsAdmin>();

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   IEnumerable<PersonsAdmin> pl =
                       from r in DC.PersonsAdmins
                       orderby r.AdminID
                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }


           public DataTable GetPersonAdminList(int Personid)
           {
               List<PersonsAdmin> result = new List<PersonsAdmin>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<PersonsAdmin> pl =
                       from r in pb.PersonsAdmins
                       where
                       r.AdminID == Personid

                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }

           public DataTable SearchFirstName(string searchTitle)
           {
               List<PersonsAdmin> result = new List<PersonsAdmin>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<PersonsAdmin> pl =
                       from r in pb.PersonsAdmins
                       where
                           r.FirstName.Contains(searchTitle)


                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }
        public DataTable SearchUserName(string searchTitle)
           {
               List<PersonsAdmin> result = new List<PersonsAdmin>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<PersonsAdmin> pl =
                       from r in pb.PersonsAdmins
                       where
                           r.Username.Contains(searchTitle)


                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }

        public DataTable SearchLastName(string searchTitle)
           {
               List<PersonsAdmin> result = new List<PersonsAdmin>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<PersonsAdmin> pl =
                       from r in pb.PersonsAdmins
                       where
                           r.LastName.Contains(searchTitle)


                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }

           public DataTable Searchid(int searchText)
           {
               List<PersonsAdmin> result = new List<PersonsAdmin>();

               using (PersonsDBEntities pb = conn.GetContext())
               {
                   IEnumerable<PersonsAdmin> pl =
                       from r in pb.PersonsAdmins
                       where
                           r.AdminID == searchText


                       select r;

                   result = pl.ToList();
               }

               return PersonTools.ToDataTable(result);
           }


           public void SavePerson(PersonsAdmin person)
           {
               using (PersonsDBEntities DC = conn.GetContext())
               {
                  
                   if ( person.AdminID > 0)
                   {
                       //==== UPDATE ====
                       DC.PersonsAdmins.Attach(person);
                       DC.Entry(person).State = EntityState.Modified;



                   }
                   else
                   {
                       //==== INSERT ====
                       DC.PersonsAdmins.Add(person);
                   }

                   DC.SaveChanges();
               }
           }

           public int PersonAdmincount()
           {
               int result = 0;

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   result =
                       (from r in DC.PersonsAdmins
                        select r).Count();
               }

               return result;
           }


           public void DeletePerson(int Personid)
           {
               using (PersonsDBEntities DC = conn.GetContext())
               {
                   var selectedGroup =
                       from r in DC.PersonsAdmins
                       where r.AdminID == Personid
                       select r;

                   if (selectedGroup != null)
                   {
                       DC.PersonsAdmins.Remove(selectedGroup as PersonsAdmin);
                       DC.SaveChanges();
                   }
               }
           }
           public void DeletePerson(List<int> Personid)
           {

               using (PersonsDBEntities DC = conn.GetContext())
               {
                   var selectedGroups =
                       from r in DC.PersonsAdmins
                       join at in Personid
                       on r.AdminID equals at
                       select r;

                   foreach (var pers in selectedGroups)
                   {
                       DC.PersonsAdmins.Remove(pers as PersonsAdmin);
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

                       db.ExecuteCommand("TRUNCATE TABLE PersonsAdmin");
                   }
               }
           }
      
    }
}
