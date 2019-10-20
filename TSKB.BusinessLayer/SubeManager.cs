using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSKB.DataAccessLayer;
using TSKB.Entities;

namespace TSKB.BusinessLayer
{
    public class SubeManager
    {
        private Repository<Sube> repository = new Repository<Sube>();
        private Repository<Kisi> repositoryKisi = new Repository<Kisi>();
        private Repository<Ekip> repositoryEkip = new Repository<Ekip>();
        private Repository<Departman> repositoryDepartman = new Repository<Departman>();

        public List<Sube> GetSubes()
        {
            return repository.List();
        }

        public void AddSube(Sube model)
        {
            repository.Insert(model);
        }

        public void UpdateSube(Sube model)
        {
            Sube sube = repository.Find(x => x.Id == model.Id);
            sube.isim = model.isim;
            
            repository.Update();
        }


        public int DeleteSube(int? Id)
        {
            Sube sube = repository.Find(x => x.Id == Id);
           
            if (sube.Departmens.Count()!=0||sube.Ekips.Count()!=0||sube.Kisis.Count()!=0)
            {
                return 0;
            }
            else
            {
                repository.Delete(sube);
                return 1;
            }
    
        }




    }
}
