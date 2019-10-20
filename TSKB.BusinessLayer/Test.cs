using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TSKB.BusinessLayer
{
    public class Test
    {
        public Test()
        {
            DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
            
            db.Kisis.ToList();
        }
        
    }
}
