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
  public  class EduLevelsRepository
    {
     

          private Connection conn;


          public EduLevelsRepository()
          {
              conn = new Connection();
          }

          public EduLevel FindBytitle(string title)
          {
              EduLevel result = null;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                  result = (from r in DC.EduLevels
                            where r.LevelTitle==title
                            select r).FirstOrDefault();
              }

              return result;
          }
          public EduLevel FindByid(int id)
          {
              EduLevel result = null;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                  result = (from r in DC.EduLevels
                            where r.LevelID == id
                            select r).FirstOrDefault();
              }

              return result;
          }


          public DataTable GetAllEduLevels()
          {
              List<EduLevel> result = new List<EduLevel>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<EduLevel> pl =
                      from r in DC.EduLevels
                      orderby r.LevelID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public DataTable GetAntiList(int Levelid)
          {
              List<EduLevel> result = new List<EduLevel>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EduLevel> pl =
                      from r in pb.EduLevels
                      where
                      r.LevelID==Levelid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchTitle(string searchTitle)
          {
              List<EduLevel> result = new List<EduLevel>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EduLevel> pl =
                      from r in pb.EduLevels
                      where
                          r.LevelTitle.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<EduLevel> result = new List<EduLevel>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EduLevel> pl =
                      from r in pb.EduLevels
                      where
                          r.LevelID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public void SaveEduLevel(EduLevel edulevel)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  
                  if (edulevel.LevelID> 0)
                  {
                      //==== UPDATE ====
                      DC.EduLevels.Attach(edulevel);
                      DC.Entry(edulevel).State = EntityState.Modified;



                  }
                  else
                  {
                      //==== INSERT ====
                      DC.EduLevels.Add(edulevel);
                  }

                  DC.SaveChanges();
              }
          }

          public int EduLevelCount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.EduLevels
                       select r).Count();
              }

              return result;
          }


          public void DeleteEduLevel(int levelid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.EduLevels
                      where r.LevelID==levelid
                      select r;

                  if (selectedGroup != null)
                  {
                      DC.EduLevels.Remove(selectedGroup as EduLevel);
                      DC.SaveChanges();
                  }
              }
          }
          public void DeleteEdulevel(List<int> edulevelid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.EduLevels
                      join at in edulevelid
                      on r.LevelID equals at
                      select r;

                  foreach (var edulevel in selectedGroups)
                  {
                      DC.EduLevels.Remove(edulevel as EduLevel);
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

                      db.ExecuteCommand("TRUNCATE TABLE EduLevel");
                  }
              }
          }
    
    }
}
