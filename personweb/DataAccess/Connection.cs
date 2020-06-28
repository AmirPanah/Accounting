using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Connection
    {
        
        public PersonsDBEntities GetContext()
        {
            PersonsDBEntities DC = new PersonsDBEntities();
            return DC;
        }
    }
}
