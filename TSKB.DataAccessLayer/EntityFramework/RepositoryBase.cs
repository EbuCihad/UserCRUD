using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSKB.DataAccessLayer
{
    public class RepositoryBase
    {

        protected static DatabaseContext context;
        private static object _lockSync = new object();
        protected RepositoryBase()
        {
            CreatContext();
        }
        public static void CreatContext()
        {
            if(context==null)
            {
                lock(_lockSync)
                {
                    if(context==null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }
        }
    }
}
