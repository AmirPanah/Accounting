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
  public  class FacultiesRepositpry
    {
        private Connection conn;


        public FacultiesRepositpry()
          {
              conn = new Connection();
          }

        public Faculty FindBytitle(string title)
        {
            Faculty result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Faculties
                          where r.FacultyTitle==title
                          select r).FirstOrDefault();
            }

            return result;
        }
        public Faculty FindByid(int id)
        {
            Faculty result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Faculties
                          where r.FacultyID==id
                          select r).FirstOrDefault();
            }

            return result;
        }

          public DataTable GetAllFaculties()
          {
              List<Faculty> result = new List<Faculty>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<Faculty> pl =
                      from r in DC.Faculties
                      orderby r.FacultyID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable GetFacultyList(int Facultyid)
          {
              List<Faculty> result = new List<Faculty>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<Faculty> pl =
                      from r in pb.Faculties
                      where
                      r.FacultyID==Facultyid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchTitle(string searchTitle)
          {
              List<Faculty> result = new List<Faculty>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<Faculty> pl =
                      from r in pb.Faculties
                      where
                          r.FacultyTitle.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<Faculty> result = new List<Faculty>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<Faculty> pl =
                      from r in pb.Faculties
                      where
                          r.FacultyID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public void SaveFaculty(Faculty faculty)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {

                  if (faculty.FacultyID > 0)
                  {
                      //==== UPDATE ====
                      DC.Faculties.Attach(faculty);
                      DC.Entry(faculty).State = EntityState.Modified;



                  }
                  else
                  {
                      //==== INSERT ====
                      DC.Faculties.Add(faculty);
                  }

                  DC.SaveChanges();
              }
          }

          public int FacultyCount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.Faculties
                       select r).Count();
              }

              return result;
          }


          public void Deletefaculty(int facultyid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.Faculties
                      where r.FacultyID==facultyid
                      select r;

                  if (selectedGroup != null)
                  {
                      DC.Faculties.Remove(selectedGroup as Faculty);
                      DC.SaveChanges();
                  }
              }
          }
          public void Deletefaculty(List<int> facultyid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.Faculties
                      join at in facultyid
                      on r.FacultyID equals at
                      select r;

                  foreach (var fac in selectedGroups)
                  {
                      DC.Faculties.Remove(fac as Faculty);
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

                      db.ExecuteCommand("TRUNCATE TABLE Faculty");
                  }
              }
          }
    
    }
}
