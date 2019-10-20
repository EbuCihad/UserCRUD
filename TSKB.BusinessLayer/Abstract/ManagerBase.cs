using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TSKB.DataAccessLayer;

namespace TSKB.BusinessLayer
{
    public abstract class ManagerBase<T> where T:class
    {
        private Repository<T> repo = new Repository<T>();

        public virtual int Delete(T obj)
        {
            return repo.Delete(obj);
        }

        public virtual T Find(Expression<Func<T, bool>> where)
        {
            return repo.Find(where);
        }

        public virtual int Insert(T obj)
        {
            return repo.Insert(obj);
        }

        public virtual List<T> List()
        {
            return repo.List();
        }

        public virtual List<T> List(Expression<Func<T, bool>> where)
        {
            return repo.List(where);
        }

        

        public virtual int Save()
        {
            return repo.Save();
        }

        public virtual int Update()
        {
            return repo.Save();
        }

    }
}
