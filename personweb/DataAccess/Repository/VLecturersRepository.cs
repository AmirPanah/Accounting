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
 public   class VLecturersRepository
    {
    
         private Connection conn;


         public VLecturersRepository()
         {
             conn = new Connection();
         }

         public VLecturer FindByFirstName(string FirstName)
         {
             VLecturer result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VLecturers
                           where r.FirstName == FirstName
                           select r).FirstOrDefault();
             }

             return result;
         }
         public VLecturer FindByLastName(string LastName)
         {
             VLecturer result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VLecturers
                           where r.LastName == LastName
                           select r).FirstOrDefault();
             }

             return result;
         }
      public VLecturer FindByuserName(string userName)
         {
             VLecturer result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VLecturers
                           where r.Username == userName
                           select r).FirstOrDefault();
             }

             return result;
         }
        public VLecturer FindBynationalcode(string text)
        {
            VLecturer result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VLecturers
                          where r.NationalCode == text
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VLecturer FindByid(int id)
         {
             VLecturer result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VLecturers
                           where r.LecturerID == id
                           select r).FirstOrDefault();
             }

             return result;
         }
         public Lecturer FindByLinkUrl(string LinkUrl)
         {
             Lecturer result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.Lecturers
                           where r.ImageFileName == LinkUrl
                           select r).FirstOrDefault();
             }

             return result;
         }
        public Lecturer FindByid2(int id)
        {
            Lecturer result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.Lecturers
                          where r.LecturerID == id
                          select r).FirstOrDefault();
            }

            return result;
        }
        public DataTable GetAllVLec()
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in DC.VLecturers
                     orderby r.LecturerID
                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable Getexeldata()
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities ent = conn.GetContext())
             {
                 System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                     WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

                 if (connectionStrings.Count > 0)
                 {
                     DataContext db = new DataContext(connectionStrings["ConnectionString"].ConnectionString);

                     result = db.ExecuteQuery<VLecturer>(
                         string.Format(
                             "SELECT *  from VLecturers"
                         )
                     ).ToList();
                 }
             }
             return PersonTools.ToDataTable(result);
         }

         public DataTable GetAllLec()
         {
             List<Lecturer> result = new List<Lecturer>();

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 IEnumerable<Lecturer> pl =
                     from r in DC.Lecturers
                     orderby r.LecturerID
                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable GetstdList(int lecid)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                     r.LecturerID == lecid

                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable Searchlecid(int searchTitle)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                           r.LecturerID == searchTitle



                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable SearchUserName(string searchTitle)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                         r.Username.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
       

         public DataTable SearchFirstName(string searchTitle)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                         r.FirstName.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }

         public DataTable SearchLastName(string searchTitle)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                         r.LastName.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable SearchFacultyTitle(string searchTitle)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                         r.FacultyTitle.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
        

         public DataTable SearchFieldTitle(string searchTitle)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                         r.FieldTitle.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable SearchTendencyTitle(string searchTitle)
         {
             List<VLecturer> result = new List<VLecturer>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VLecturer> pl =
                     from r in pb.VLecturers
                     where
                         r.TendencyTitle.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }


         public void Savestd(Lecturer lecturer)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {
                
                 if ( lecturer.LecturerID > 0)
                 {
                     //==== UPDATE ====
                     DC.Lecturers.Attach(lecturer);
                     DC.Entry(lecturer).State = EntityState.Modified;



                 }
                 else
                 {
                     //==== INSERT ====
                     DC.Lecturers.Add(lecturer);
                 }

                 DC.SaveChanges();
             }
         }

         public int leccount()
         {
             int result = 0;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 result =
                     (from r in DC.Lecturers
                      select r).Count();
             }

             return result;
         }


         public void DeleteLecturer(int lecid)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroup =
                     from r in DC.Lecturers
                     where r.LecturerID == lecid
                     select r;

                 if (selectedGroup != null)
                 {
                     DC.Lecturers.Remove(selectedGroup as Lecturer);
                     DC.SaveChanges();
                 }
             }
         }
         public void Deletelecturer(int lecturer)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroup =
                     from r in DC.Lecturers
                     where r.LecturerID == lecturer
                     select r;

                 if (selectedGroup != null)
                 {
                     DC.Lecturers.Remove(selectedGroup as Lecturer);
                     DC.SaveChanges();
                 }
             }
         }
         public void Deletelec(List<int>lecid)
         {

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroups =
                     from r in DC.Lecturers
                     join at in lecid
                     on r.LecturerID equals at
                     select r;

                 foreach (var lec in selectedGroups)
                 {
                     DC.Lecturers.Remove(lec as Lecturer);
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

                     db.ExecuteCommand("TRUNCATE TABLE Lecturer");
                 }
             }
         }
    
    }
}
