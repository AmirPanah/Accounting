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
  public  class VEduTendenciesRepository
    {
        private Connection conn;


        public VEduTendenciesRepository()
         {
             conn = new Connection();
         }

        
      public VEduTendency FindByTendencyTitle(string title)
         {
             VEduTendency result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VEduTendencies
                           where r.TendencyTitle == title
                           select r).FirstOrDefault();
             }

             return result;
         }
         public VEduTendency FindByid(int id)
         {
             VEduTendency result = null;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                 result = (from r in DC.VEduTendencies
                           where r.TendencyID == id
                           select r).FirstOrDefault();
             }

             return result;
         }
      
         public DataTable GetAllTendency()
         {
             List<VEduTendency> result = new List<VEduTendency>();

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 IEnumerable<VEduTendency> pl =
                     from r in DC.VEduTendencies
                     orderby r.TendencyID
                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }


         public DataTable GettendencyList(int tendencyid)
         {
             List<VEduTendency> result = new List<VEduTendency>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEduTendency> pl =
                     from r in pb.VEduTendencies
                     where
                     r.TendencyID == tendencyid

                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }

         public DataTable Searchtitle(string searchTitle)
         {
             List<VEduTendency> result = new List<VEduTendency>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEduTendency> pl =
                     from r in pb.VEduTendencies
                     where
                         r.TendencyTitle.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
       

        

         public DataTable searchFieldtitle(string searchTitle)
         {
             List<VEduTendency> result = new List<VEduTendency>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEduTendency> pl =
                     from r in pb.VEduTendencies
                     where
                         r.FieldTitle.Contains(searchTitle)


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
         public DataTable Searchid(int searchTitle)
         {
             List<VEduTendency> result = new List<VEduTendency>();

             using (PersonsDBEntities pb = conn.GetContext())
             {
                 IEnumerable<VEduTendency> pl =
                     from r in pb.VEduTendencies
                     where
                         r.TendencyID==searchTitle


                     select r;

                 result = pl.ToList();
             }

             return PersonTools.ToDataTable(result);
         }
       

         public void SaveTen(EduTendency edutendency)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {

                 if (edutendency.TendencyID > 0)
                 {
                     //==== UPDATE ====
                     DC.EduTendencies.Attach(edutendency);
                     DC.Entry(edutendency).State = EntityState.Modified;



                 }
                 else
                 {
                     //==== INSERT ====
                     DC.EduTendencies.Add(edutendency);
                 }

                 DC.SaveChanges();
             }
         }

         public int tendencycount()
         {
             int result = 0;

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 result =
                     (from r in DC.EduTendencies
                      select r).Count();
             }

             return result;
         }


         public void DeleteTendency(int Tendencyid)
         {
             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroup =
                     from r in DC.EduTendencies
                     where r.TendencyID == Tendencyid
                     select r;

                 if (selectedGroup != null)
                 {
                     DC.EduTendencies.Remove(selectedGroup as EduTendency);
                     DC.SaveChanges();
                 }
             }
         }
        
         public void Deletetendency(List<int>tendencyid)
         {

             using (PersonsDBEntities DC = conn.GetContext())
             {
                 var selectedGroups =
                     from r in DC.EduTendencies
                     join at in tendencyid
                     on r.TendencyID equals at
                     select r;

                 foreach (var ten in selectedGroups)
                 {
                     DC.EduTendencies.Remove(ten as EduTendency);
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

                     db.ExecuteCommand("TRUNCATE TABLE EduTendency");
                 }
             }
         }
    }
}
