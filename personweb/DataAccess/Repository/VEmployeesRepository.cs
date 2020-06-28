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
   public class VEmployeesRepository
    {
       
         private Connection conn;


         public VEmployeesRepository()
         {
             conn = new Connection();
         }

         public VEmployee FindByFirstName(string FirstName)
         {
             VEmployee result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VEmployees
                           where r.FirstName == FirstName
                           select r).FirstOrDefault();
             }

             return result;
         }
         public VEmployee FindByLastName(string LastName)
         {
             VEmployee result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VEmployees
                           where r.LastName == LastName
                           select r).FirstOrDefault();
             }

             return result;
         }
      public VEmployee FindByuserName(string userName)
         {
             VEmployee result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VEmployees
                           where r.Username == userName
                           select r).FirstOrDefault();
             }

             return result;
         }
        public Employee FindByuserName2(string userName)
        {
            Employee result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Employees
                          where r.Username == userName
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VEmployee FindBynationalcode(string text)
        {
            VEmployee result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VEmployees
                          where r.NationalCode == text
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VEmployee FindByid(int id)
         {
             VEmployee result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VEmployees
                           where r.EmployeeID == id
                           select r).FirstOrDefault();
             }

             return result;
         }
        public Employee FindByid2(int id)
        {
            Employee result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Employees
                          where r.EmployeeID == id
                          select r).FirstOrDefault();
            }

            return result;
        }

        public Employee FindByLinkUrl(string LinkUrl)
         {
            Employee result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.Employees
                           where r.ImageFileName == LinkUrl
                           select r).FirstOrDefault();
             }

             return result;
         }
         public DataTable Getexeldata()
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities ent = conn.GetContext())
             {
                 System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                     WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

                 if (connectionStrings.Count > 0)
                 {
                     DataContext db = new DataContext(connectionStrings["ConnectionString"].ConnectionString);

                     result = db.ExecuteQuery<VEmployee>(
                         string.Format(
                             "SELECT * from VEmployees"
                         )
                     ).ToList();
                 }
             }
             return PersonTools.ToDataTable(result);
         }
         public DataTable GetAllvEmp()
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in DC.VEmployees
                     orderby r.EmployeeID
                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }

         public DataTable GetAllEmp()
         {
             List<Employee> result = new List<Employee>();

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 IEnumerable<Employee> pl =
                     from r in DC.Employees
                     orderby r.EmployeeID
                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable GetstdList(int empid)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                     r.EmployeeID == empid

                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }

         public DataTable SearchUserName(string searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.Username.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
       

         public DataTable SearchFirstName(string searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.FirstName.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }

         public DataTable SearchLastName(string searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.LastName.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable searchuser(string searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.Username.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }

         public DataTable searchDepartmenttitle(string searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.DepartmentTitle.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable searchRoletitle(string searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.RoleTitle.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable Searchid(int searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.EmployeeID==searchTitle


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable SearchNationalcode(string searchTitle)
         {
             List<VEmployee> result = new List<VEmployee>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEmployee> pl =
                     from r in pb.VEmployees
                     where
                         r.NationalCode == searchTitle


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }

         public void Saveemp(Employee employee)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {

                 if (employee.EmployeeID > 0)
                 {
                     //==== UPDATE ====
                     DC.Employees.Attach(employee);
                     DC.Entry(employee).State = EntityState.Modified;



                 }
                 else
                 {
                     //==== INSERT ====
                     DC.Employees.Add(employee);
                 }

                 DC.SaveChanges();
             }
         }

         public int Empcount()
         {
             int result = 0;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 result =
                     (from r in DC.Employees
                      select r).Count();
             }

             return result;
         }


         public void Deleteemployee(int Empid)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroup =
                     from r in DC.Employees
                     where r.EmployeeID == Empid
                     select r;

                 if (selectedGroup != null)
                 {
                     DC.Employees.Remove(selectedGroup as Employee);
                     DC.SaveChanges();
                 }
             }
         }
         public void DeleteEmp(int emp)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroup =
                     from r in DC.Employees
                     where r.EmployeeID == emp
                     select r;

                 if (selectedGroup != null)
                 {
                     DC.Employees.Remove(selectedGroup as Employee);
                     DC.SaveChanges();
                 }
             }
         }
         public void Deleteemp(List<int>empid)
         {

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroups =
                     from r in DC.Employees
                     join at in empid
                     on r.EmployeeID equals at
                     select r;

                 foreach (var emp in selectedGroups)
                 {
                     DC.Employees.Remove(emp as Employee);
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

                     db.ExecuteCommand("TRUNCATE TABLE Emloyee");
                 }
             }
         }
    }
}
