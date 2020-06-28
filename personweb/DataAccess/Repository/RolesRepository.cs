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
 public   class RolesRepository
    {
          private Connection conn;


          public RolesRepository()
          {
              conn = new Connection();
          }

        public Role FindBytitle(string title)
        {
            Role result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Roles
                          where r.RoleTitle==title
                          select r).FirstOrDefault();
            }

            return result;
        }
        public Role FindByid(int id)
        {
            Role result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Roles
                          where r.RoleID==id
                          select r).FirstOrDefault();
            }

            return result;
        }

          public DataTable GetAllRoles()
          {
              List<Role> result = new List<Role>();

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  IEnumerable<Role> pl =
                      from r in DC.Roles
                      orderby r.RoleID
                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public DataTable GetRoleList(int Roleid)
          {
              List<Role> result = new List<Role>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<Role> pl =
                      from r in pb.Roles
                      where
                      r.RoleID==Roleid

                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }

          public DataTable SearchTitle(string searchTitle)
          {
              List<Role> result = new List<Role>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<Role> pl =
                      from r in pb.Roles
                      where
                          r.RoleTitle.Contains(searchTitle)


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }
          public DataTable Searchid(int searchText)
          {
              List<Role> result = new List<Role>();

              using (PersonsDBEntities pb = conn.GetContext())
              {
                  IEnumerable<Role> pl =
                      from r in pb.Roles
                      where
                          r.RoleID == searchText


                      select r;

                  result = pl.ToList();
              }

              return PersonTools.ToDataTable(result);
          }


          public void SaveRoles(Role role)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  if (role.RoleID > 0)
                  {
                      //==== UPDATE ====
                      DC.Roles.Attach(role);
                      DC.Entry(role).State = EntityState.Modified;



                  }
                  else
                  {
                      //==== INSERT ====
                      DC.Roles.Add(role);
                  }

                  DC.SaveChanges();
              }
          }

          public int Rolescount()
          {
              int result = 0;

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  result =
                      (from r in DC.Roles
                       select r).Count();
              }

              return result;
          }


          public void DeleteRole(int Roleid)
          {
              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroup =
                      from r in DC.Roles
                      where r.RoleID==Roleid
                      select r;

                  if (selectedGroup != null)
                  {
                      DC.Roles.Remove(selectedGroup as Role);
                      DC.SaveChanges();
                  }
              }
          }
          public void DeleteRole(List<int> Roleid)
          {

              using (PersonsDBEntities DC = conn.GetContext())
              {
                  var selectedGroups =
                      from r in DC.Roles
                      join at in Roleid
                      on r.RoleID equals at
                      select r;

                  foreach (var Role in selectedGroups)
                  {
                      DC.Roles.Remove(Role as Role);
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

                      db.ExecuteCommand("TRUNCATE TABLE Role");
                  }
              }
          }
    }
}
