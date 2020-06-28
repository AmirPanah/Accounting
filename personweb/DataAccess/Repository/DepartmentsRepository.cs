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
   public class DepartmentsRepository
    {
        private Connection conn;


        public DepartmentsRepository()
        {
            conn = new Connection();
        }

        public Department FindBytitle(string title)
        {
            Department result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Departments
                          where r.DepartmentTitle==title
                          select r).FirstOrDefault();
            }

            return result;
        }
        public Department FindByid(int id)
        {
            Department result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Departments
                          where r.DepartmentID==id
                          select r).FirstOrDefault();
            }

            return result;
        }


       public DataTable GetAllDepartment()
       {
           List<Department> result = new List<Department>();

           using (PersonsDBEntities DC = conn.GetContext())
           {
               IEnumerable<Department> pl =
                   from r in DC.Departments
                   orderby r.DepartmentID
                   select r;

               result = pl.ToList();
           }
           
           return PersonTools.ToDataTable(result);
       }


       public DataTable GetAntiList(int departmentid)
       {
           List<Department> result = new List<Department>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<Department> pl =
                   from r in pb.Departments
                   where
                   r.DepartmentID==departmentid

                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }

       public DataTable SearchTitle(string searchTitle)
       {
           List<Department> result = new List<Department>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<Department> pl =
                   from r in pb.Departments
                   where
                       r.DepartmentTitle.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
       public DataTable Searchdepid(int searchText)
       {
           List<Department> result = new List<Department>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<Department> pl =
                   from r in pb.Departments
                   where
                       r.DepartmentID==searchText


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
      

       public void SaveDepartment(Department department)
       {
           using (PersonsDBEntities DC = conn.GetContext())
           {

               if (department.DepartmentID > 0)
               {
                   //==== UPDATE ====
                   DC.Departments.Attach(department);
                   DC.Entry(department).State = EntityState.Modified;



               }
               else
               {
                   //==== INSERT ====
                   DC.Departments.Add(department);
               }

               DC.SaveChanges();
           }
       }

       public int DepartmanetCount()
       {
           int result = 0;

           using (PersonsDBEntities DC = conn.GetContext())
           {
               result =
                   (from r in DC.Departments
                    select r).Count();
           }

           return result;
       }


       public void DeleteDepartment(int departmentid)
       {
           using (PersonsDBEntities DC = conn.GetContext())
           {
               var selectedGroup =
                   from r in DC.Departments
                   where r.DepartmentID==departmentid
                   select r;

               if (selectedGroup != null)
               {
                   DC.Departments.Remove(selectedGroup as Department);
                   DC.SaveChanges();
               }
           }
       }
       public void DeleteDepartment(List<int> Departmentid)
       {

           using (PersonsDBEntities DC = conn.GetContext())
           {
               var selectedGroups =
                   from r in DC.Departments
                   join at in Departmentid
                   on r.DepartmentID equals at
                   select r;

               foreach (var dep in selectedGroups)
               {
                   DC.Departments.Remove(dep as Department);
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

                   db.ExecuteCommand("TRUNCATE TABLE Department");
               }
           }
       }
    }
}
