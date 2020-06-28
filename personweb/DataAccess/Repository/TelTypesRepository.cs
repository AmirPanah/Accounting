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
   public class TelTypesRepository
    {
         private Connection conn;


         public TelTypesRepository()
          {
              conn = new Connection();
          }

        public TelType FindBytitle(string title)
        {
            TelType result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.TelTypes
                          where r.TelTypeTitle==title
                          select r).FirstOrDefault();
            }

            return result;
        }
        public TelType FindByid(int id)
        {
            TelType result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.TelTypes
                          where r.TelTypeID==id
                          select r).FirstOrDefault();
            }

            return result;
        }

          public DataTable GetAllTelType()
          {
              List<TelType> result = new List<TelType>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<TelType> pl =
                      from r in DC.TelTypes
                      orderby r.TelTypeID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable GetTelTypeList(int TelTypeid)
          {
              List<TelType> result = new List<TelType>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelType> pl =
                      from r in pb.TelTypes
                      where
                      r.TelTypeID==TelTypeid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchTitle(string searchTitle)
          {
              List<TelType> result = new List<TelType>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelType> pl =
                      from r in pb.TelTypes
                      where
                          r.TelTypeTitle.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<TelType> result = new List<TelType>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<TelType> pl =
                      from r in pb.TelTypes
                      where
                          r.TelTypeID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public void SaveTelType(TelType TelType)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {

                  if (TelType.TelTypeID > 0)
                  {
                      //==== UPDATE ====
                      DC.TelTypes.Attach(TelType);
                      DC.Entry(TelType).State = EntityState.Modified;
              
                  }
                  else
                  {
                      //==== INSERT ====
                      DC.TelTypes.Add(TelType);
                     
                  }

                  DC.SaveChanges();
              }
          }

          public int TelTypeCount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.TelTypes
                       select r).Count();
              }

              return result;
          }


          public void DeleteTelType(int TelTypeid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.TelTypes
                      where r.TelTypeID==TelTypeid

                      select r;

                  if (selectedGroup != null)
                  {
                      DC.TelTypes.Remove(selectedGroup as TelType);
                      DC.SaveChanges();
                  }
              }
          }
          public void DeleteTelType(List<int> TelTypeid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.TelTypes
                      join at in TelTypeid
                      on r.TelTypeID equals at
                      select r;

                  foreach (var tel in selectedGroups)
                  {
                      DC.TelTypes.Remove(tel as TelType);
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

                      db.ExecuteCommand("TRUNCATE TABLE TelType");
                  }
              }
          }
    }
}
