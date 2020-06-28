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
  public  class VStudentsRepository
    {
      private Connection conn;


      public VStudentsRepository()
        {
            conn = new Connection();
        }

        public VStudent FindByFirstName(string FirstName)
        {
            VStudent result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VStudents
                          where r.FirstName==FirstName
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VStudent FindByLastName(string LastName)
        {
            VStudent result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VStudents
                          where r.LastName == LastName
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VStudent FindByuserName(string userName)
        {
            VStudent result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VStudents
                          where r.Username == userName
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VStudent FindBynationatcode(string text)
        {
            VStudent result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VStudents
                          where r.NationalCode == text
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VStudent FindByid(int id)
        {
            VStudent result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VStudents
                          where r.StudentID==id
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VStudent FindBycode(string code)
        {
            VStudent result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VStudents
                          where r.StudentCode == code
                          select r).FirstOrDefault();
            }

            return result;
        }
        public Student FindByid2(int id)
        {
            Student result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Students
                          where r.StudentID == id
                          select r).FirstOrDefault();
            }

            return result;
        }
        public Student FindByLinkUrl(string LinkUrl)
        {
            Student result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Students
                          where r.ImageFileName == LinkUrl
                          select r).FirstOrDefault();
            }

            return result;
        }
       public DataTable GetAllvstd()
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities DC = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in DC.VStudents
                   orderby r.StudentID
                   select r;

               result = pl.ToList();
           }
           
           return PersonTools.ToDataTable(result);
       }
       public DataTable Getexeldatavstd()
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities DC = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in DC.VStudents
                   orderby r.StudentID
                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }

       //public VStudent Getexeldatavstd2()
       //{
       //    VStudent result = new VStudent();

       //    using (PersonsDBEntities ent = conn.GetContext())
       //    {
       //        System.Configuration.ConnectionStringSettingsCollection connectionStrings =
       //            WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

       //        if (connectionStrings.Count > 0)
       //        {
       //            DataContext db = new DataContext(connectionStrings["ConnectionString"].ConnectionString);
       //            result = db.ExecuteQuery<VStudent>(
       //                string.Format(
       //                    "SELECT Email AS emaill "
       //                )
       //            ).FirstOrDefault();
       //        }
       //    }
       //    return result;
       //}

       public DataTable Getexeldatavstd3()
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities ent = conn.GetContext())
           {
               System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                   WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

               if (connectionStrings.Count > 0)
               {
                   DataContext db = new DataContext(connectionStrings["ConnectionString"].ConnectionString);

                   result = db.ExecuteQuery<VStudent>(
                       string.Format(
                           "SELECT * from VStudents"
                       )
                   ).ToList();
               }
           }
           return PersonTools.ToDataTable(result);
       }


       public DataTable GetAllstd()
       {
           List<Student> result = new List<Student>();

           using (PersonsDBEntities DC = conn.GetContext())
           {
               IEnumerable<Student> pl =
                   from r in DC.Students
                   orderby r.StudentID
                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }

       public DataTable GetstdList(int stdid)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                   r.StudentID == stdid
                    
                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }


       public DataTable Searchstdid(int searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                         r.StudentID == searchTitle



                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
       public DataTable SearchUserName(string searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.Username.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
       public DataTable Searchstdcode(string searchText)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.StudentCode==searchText


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }

       public DataTable SearchFirstName(string searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.FirstName.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
       public DataTable SearchLastName(string searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.LastName.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
       public DataTable SearchFacultyTitle(string searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.FacultyTitle.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
       public DataTable SearchLevelTitle(string searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.LevelTitle.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }

       public DataTable SearchFieldTitle(string searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.FieldTitle.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }
       public DataTable SearchTendencyTitle(string searchTitle)
       {
           List<VStudent> result = new List<VStudent>();

           using (PersonsDBEntities pb = conn.GetContext())
           {
               IEnumerable<VStudent> pl =
                   from r in pb.VStudents
                   where
                       r.TendencyTitle.Contains(searchTitle)


                   select r;

               result = pl.ToList();
           }

           return PersonTools.ToDataTable(result);
       }


       public void Savestd(Student student)
       {
           using (PersonsDBEntities DC = conn.GetContext())
           {
           
               if ( student.StudentID > 0)
               {
                   //==== UPDATE ====
                   DC.Students.Attach(student);
                   DC.Entry(student).State = EntityState.Modified;



               }
               else
               {
                   //==== INSERT ====
                   DC.Students.Add(student);
               }

               DC.SaveChanges();
           }
       }

       public int stdcount()
       {
           int result = 0;

           using (PersonsDBEntities DC = conn.GetContext())
           {
               result =
                   (from r in DC.Students
                    select r).Count();
           }

           return result;
       }


       public void Deletestudent(int stdid)
       {
           using (PersonsDBEntities DC = conn.GetContext())
           {
               var selectedGroup =
                   from r in DC.Students
                   where r.StudentID==stdid
                   select r;

               if (selectedGroup != null)
               {
                   DC.Students.Remove(selectedGroup as Student);
                   DC.SaveChanges();
               }
           }
       }
       public void Deletestudent(string stdcode)
       {
           using (PersonsDBEntities DC = conn.GetContext())
           {
               var selectedGroup =
                   from r in DC.Students
                   where r.StudentCode == stdcode
                   select r;

               if (selectedGroup != null)
               {
                   DC.Students.Remove(selectedGroup as Student);
                   DC.SaveChanges();
               }
           }
       }
       public void Deletestudent(List<int> stdid)
       {

           using (PersonsDBEntities DC = conn.GetContext())
           {
               var selectedGroups =
                   from r in DC.Students
                   join at in stdid
                   on r.StudentID equals at
                   select r;

               foreach (var std in selectedGroups)
               {
                   DC.Students.Remove(std as Student);
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

                   db.ExecuteCommand("TRUNCATE TABLE Student");
               }
           }
       }



       //public VStudent StudentReport()
       //{
       //    IEnumerable<VStudent> result = null;

       //    using (PersonsDBEntities ent = conn.GetContext())
       //    {
       //        System.Configuration.ConnectionStringSettingsCollection connectionStrings =
       //            WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

       //        if (connectionStrings.Count > 0)
       //        {
       //            DataContext db = new DataContext(connectionStrings["NativeConnectionStr"].ConnectionString);

       //            #region query

       //            result = db.ExecuteQuery<VStudent>(string.Format(
       //                                "SELECT " +
       //                                "	( " +
       //                                "		SELECT * " +
       //                                "		FROM VStudent " +
       //                                "		 " +
       //                                "	) AS TotalConversations, "));
                                      
                                 

       //            #endregion
       //        }
       //    }

       //    return result.FirstOrDefault();
       //}



    }
}
