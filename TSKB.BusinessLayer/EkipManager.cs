using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSKB.DataAccessLayer;
using TSKB.Entities;

namespace TSKB.BusinessLayer
{
    public class EkipManager
    {
        private Repository<Ekip> repository = new Repository<Ekip>();
        private Repository<Sube> repositorySube = new Repository<Sube>();
        private Repository<Departman> repositoryDepartman = new Repository<Departman>();
        private Repository<Kisi> repositoryKisi = new Repository<Kisi>();

        public List<Ekip> GetEkips()
        {
            return repository.List();
        }


        public void AddEkip(Ekip model, int subedrop, int departmandrop)
        {
            Sube sube = repositorySube.Find(x => x.Id == subedrop);
            Departman departman = repositoryDepartman.Find(x => x.Id == departmandrop);
            Ekip ekip = new Ekip()
            {
                isim = model.isim,
                Departman = departman,
                Sube = sube
            };
            sube.Ekips.Add(ekip);
            departman.Ekips.Add(ekip);
            repository.Insert(ekip);
        }

        public void UpdateEkip(Ekip model, int subedrop, int departmandrop)
        {
            Sube sube = repositorySube.Find(x => x.Id == subedrop);
            Departman departman = repositoryDepartman.Find(x => x.Id == departmandrop);
           
            Ekip ekip = repository.Find(x => x.Id == model.Id);
            ekip.isim = model.isim;
            ekip.Sube = sube;
            ekip.Departman = departman;
            repository.Update();
        }
        

        public int DeleteEkip(int? Id)
        {
            Ekip ekip = repository.Find(x => x.Id == Id);
            List<Sube> subes = repositorySube.List();
            List<Departman> departmen = repositoryDepartman.List();
            
            if(ekip.Kisis.Count()!=0)
            {
                return 0;
            }
            foreach (Sube s in subes)
            {
                Ekip sil = s.Ekips.Find(x => x.Id == Id);
                if (sil != null)
                {
                    s.Ekips.Remove(sil);
                }
            }
            foreach (Departman s in departmen)
            {
                Ekip sil = s.Ekips.Find(x => x.Id == Id);
                if (sil != null)
                {
                    s.Ekips.Remove(sil);
                }
            }
            
            repository.Delete(ekip);
            return 1;
        }
    }
}
