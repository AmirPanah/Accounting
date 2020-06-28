using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DataAccess
{
  public  class EduFieldsRepository
    {
      
          private Connection conn;


          public EduFieldsRepository()
          {
              conn = new Connection();
          }

          public EduField FindBytitle(string title)
          {
              EduField result = null;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                  result = (from r in DC.EduFields
                            where r.FieldTitle==title
                            select r).FirstOrDefault();
              }

              return result;
          }
          public EduField FindByid(int id)
          {
              EduField result = null;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                  result = (from r in DC.EduFields
                            where r.FieldID==id
                            select r).FirstOrDefault();
              }

              return result;
          }


          public DataTable GetAllEduFields()
          {
              List<EduField> result = new List<EduField>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<EduField> pl =
                      from r in DC.EduFields
                      orderby r.FieldID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public DataTable GetAntiList(int fieldid)
          {
              List<EduField> result = new List<EduField>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EduField> pl =
                      from r in pb.EduFields
                      where
                      r.FieldID == fieldid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchTitle(string searchTitle)
          {
              List<EduField> result = new List<EduField>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EduField> pl =
                      from r in pb.EduFields
                      where
                          r.FieldTitle.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<EduField> result = new List<EduField>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<EduField> pl =
                      from r in pb.EduFields
                      where
                          r.FieldID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public void SaveEdufield(EduField edufield)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                 
                  if ( edufield.FieldID > 0)
                  {
                      //==== UPDATE ====
                      DC.EduFields.Attach(edufield);
                      DC.Entry(edufield).State = EntityState.Modified;



                  }
                  else
                  {
                      //==== INSERT ====
                      DC.EduFields.Add(edufield);
                  }

                  DC.SaveChanges();
              }
          }

          public int FieldCount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.EduFields
                       select r).Count();
              }

              return result;
          }


          public void DeleteEduField(int fieldid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.EduFields
                      where r.FieldID == fieldid
                      select r;

                  if (selectedGroup != null)
                  {
                      DC.EduFields.Remove(selectedGroup as EduField);
                      DC.SaveChanges();
                  }
              }
          }
          public void DeleteEduField(List<int> EduFieldid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.EduFields
                      join at in EduFieldid
                      on r.FieldID equals at
                      select r;

                  foreach (var edufield in selectedGroups)
                  {
                      DC.EduFields.Remove(edufield as EduField);
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

                      db.ExecuteCommand("TRUNCATE TABLE EduField");
                  }
              }
          }
      }
    
}
