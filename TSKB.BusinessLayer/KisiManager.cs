using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSKB.DataAccessLayer;
using TSKB.Entities;

namespace TSKB.BusinessLayer
{
    public class KisiManager
    {
        private Repository<Kisi> repositoryKisi = new Repository<Kisi>();
        private Repository<Sube> repositorySube = new Repository<Sube>();
        private Repository<Departman> repositoryDepartman = new Repository<Departman>();
        private Repository<Ekip> repositoryEkip = new Repository<Ekip>();

        public List<Kisi> GetKisis()
        {
            return repositoryKisi.List();
        }

        public void AddKisi(Kisi model, int subedrop, int departmandrop, int ekipdrop)
        {
            Sube sube =repositorySube.Find(x => x.Id == subedrop);
            Departman departman = repositoryDepartman.Find(x => x.Id == departmandrop);
            Ekip ekip = repositoryEkip.Find(x => x.Id == ekipdrop);
            Kisi kisi = new Kisi()
            {
                isim = model.isim,
                soyisim = model.soyisim,
                maas = model.maas,
                dogumTarihi = model.dogumTarihi,
                Statu = model.Statu,
                Sube = sube,
                Departman = departman,
                Ekip = ekip
            };
            sube.Kisis.Add(kisi);
            departman.Kisis.Add(kisi);
            ekip.Kisis.Add(kisi);
            repositoryKisi.Insert(kisi);
        }


        public void UpdateKisi(Kisi model, int subedrop, int departmandrop, int ekipdrop)
        {
            Sube sube = repositorySube.Find(x => x.Id == subedrop);
            Departman departman = repositoryDepartman.Find(x => x.Id == departmandrop);
            Ekip ekip = repositoryEkip.Find(x => x.Id == ekipdrop);
            Kisi kisi = repositoryKisi.Find(x => x.Id == model.Id);
            kisi.isim = model.isim;
            kisi.soyisim = model.soyisim;
            kisi.Statu = model.Statu;
            kisi.Sube = sube;
            kisi.dogumTarihi = model.dogumTarihi;
            kisi.Departman = departman;
            kisi.Ekip = ekip;
            kisi.maas = model.maas;
            repositoryKisi.Update();
        }

        public void DeleteKisi(int? Id)
        {
            Kisi kisi = repositoryKisi.Find(x => x.Id == Id);
            List<Sube> subes = repositorySube.List();
            List<Departman> departmen = repositoryDepartman.List();
            List<Ekip> ekip = repositoryEkip.List();
            foreach (Sube s in subes)
            {
                Kisi sil = s.Kisis.Find(x => x.Id == Id);
                if (sil != null)
                {
                    s.Kisis.Remove(sil);                    
                }
            }
            foreach (Departman s in departmen)
            {
                Kisi sil = s.Kisis.Find(x => x.Id == Id);
                if (sil != null)
                {
                    s.Kisis.Remove(sil);
                }
            }
            foreach (Ekip s in ekip)
            {
                Kisi sil = s.Kisis.Find(x => x.Id == Id);
                if (sil != null)
                {
                    s.Kisis.Remove(sil);
                }
            }
            repositoryKisi.Delete(kisi);

        }
        
    }
}
