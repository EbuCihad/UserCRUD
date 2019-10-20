using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSKB.Entities;

namespace TSKB.DataAccessLayer
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Departman> Departmens { get; set; }
        public DbSet<Ekip> Ekips { get; set; }
        public DbSet<Kisi> Kisis { get; set; }
        public DbSet<Sube> Subes { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new Intiliazer());

        }

    }
}
