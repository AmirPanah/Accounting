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
  public  class VPNsRepository
    {
        private Connection conn;


        public VPNsRepository()
        {
            conn = new Connection();
        }

        
        public VVPN FindByid(int id)
        {
            VVPN result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VVPNs
                          where r.VPNID == id
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VPN FindvpnByid(int id)
        {
            VPN result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VPNs
                          where r.VPNID == id
                          select r).FirstOrDefault();
            }

            return result;
        }
        public VVPN FindByUsername(string username)
        {
            VVPN result = null;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in DC.VVPNs
                          where r.Username == username
                          select r).FirstOrDefault();
            }

            return result;
        }
        public DataTable GetAllvpns()
        {
            List<VPN> result = new List<VPN>();

            using (PersonsDBEntities DC = conn.GetContext())
            {
                IEnumerable<VPN> pl =
                    from r in DC.VPNs
                    orderby r.VPNID
                    select r;

                result = pl.ToList();
            }

            return PersonTools.ToDataTable(result);
        }

        public DataTable Getexeldata()
        {
            List<VVPN> result = new List<VVPN>();

            using (PersonsDBEntities ent = conn.GetContext())
            {
                System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                    WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

                if (connectionStrings.Count > 0)
                {
                    DataContext db = new DataContext(connectionStrings["ConnectionString"].ConnectionString);

                    result = db.ExecuteQuery<VVPN>(
                        string.Format(
                            "SELECT * from VVPNs"
                        )
                    ).ToList();
                }
            }
            return PersonTools.ToDataTable(result);
        }

        //public DataTable GetEmailContactList(int EmailContactid)
        //{
        //    List<VPN> result = new List<VPN>();

        //    using (PersonsDBEntities pb = conn.GetContext())
        //    {
        //        IEnumerable<VPN> pl =
        //            from r in pb.VPNS
        //            where
        //            r.VPNID == EmailContactid

        //            select r;

        //        result = pl.ToList();
        //    }

        //    return PersonTools.ToDataTable(result);
        //}

        public DataTable Searchusername(string searchTitle)
        {
            List<VVPN> result = new List<VVPN>();

            using (PersonsDBEntities pb = conn.GetContext())
            {
                IEnumerable<VVPN> pl =
                    from r in pb.VVPNs
                    where
                        r.Username.Contains(searchTitle)


                    select r;

                result = pl.ToList();
            }

            return PersonTools.ToDataTable(result);
        }

       
        public DataTable Searchid(int searchText)
        {
            List<VVPN> result = new List<VVPN>();

            using (PersonsDBEntities pb = conn.GetContext())
            {
                IEnumerable<VVPN> pl =
                    from r in pb.VVPNs
                    where
                        r.VPNID == searchText


                    select r;

                result = pl.ToList();
            }

            return PersonTools.ToDataTable(result);
        }
        public DataTable SearchUserTypeid(int searchText)
        {
            List<VVPN> result = new List<VVPN>();

            using (PersonsDBEntities pb = conn.GetContext())
            {
                IEnumerable<VVPN> pl =
                    from r in pb.VVPNs
                    where
                        r.UserTypeID == searchText


                    select r;

                result = pl.ToList();
            }

            return PersonTools.ToDataTable(result);
        }

        public DataTable SearchUserid(int searchText)
        {
            List<VVPN> result = new List<VVPN>();

            using (PersonsDBEntities pb = conn.GetContext())
            {
                IEnumerable<VVPN> pl =
                    from r in pb.VVPNs
                    where
                        r.UserID == searchText


                    select r;

                result = pl.ToList();
            }

            return PersonTools.ToDataTable(result);
        }

        

    
        public void Savevpn(VPN vpn)
        {
            using (PersonsDBEntities DC = conn.GetContext())
            {

                if (vpn.VPNID > 0)
                {
                    //==== UPDATE ====
                    DC.VPNs.Attach(vpn);
                    DC.Entry(vpn).State = EntityState.Modified;

                }
                else
                {
                    //==== INSERT ====
                    DC.VPNs.Add(vpn);

                }

                DC.SaveChanges();
            }
        }

        public int VPNCount()
        {
            int result = 0;

            using (PersonsDBEntities DC = conn.GetContext())
            {
                result =
                    (from r in DC.VPNs
                     select r).Count();
            }

            return result;
        }


        public void DeleteVPN(int VPNid)
        {
            using (PersonsDBEntities DC = conn.GetContext())
            {
                var selectedGroup =
                    from r in DC.VPNs
                    where r.VPNID == VPNid

                    select r;

                if (selectedGroup != null)
                {
                    DC.VPNs.Remove(selectedGroup as VPN);
                    DC.SaveChanges();
                }
            }
        }
        public void DeleteVPN(List<int> vpn)
        {

            using (PersonsDBEntities DC = conn.GetContext())
            {
                var selectedGroups =
                    from r in DC.VPNs
                    join at in vpn
                    on r.VPNID equals at
                    select r;

                foreach (var vpnn in selectedGroups)
                {
                    DC.VPNs.Remove(vpnn as VPN);
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

                    db.ExecuteCommand("TRUNCATE TABLE VPNs");
                }
            }
        }
    
    }
}
