using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TSKB.DataAccessLayer.Abstract;

namespace TSKB.DataAccessLayer
{
    public class Repository<T>:RepositoryBase,IRepository<T> where T:class
    {
        

        private DbSet<T> _object;

        public Repository()
        {
            _object = context.Set<T>();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _object.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            _object.Add(obj);
            return Save();
        }

        public int Update()
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _object.Remove(obj);
            return Save();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
