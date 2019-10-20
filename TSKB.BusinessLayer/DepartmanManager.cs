using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TSKB.DataAccessLayer;
using TSKB.Entities;

namespace TSKB.BusinessLayer
{
    public class DepartmanManager
    {
        private Repository<Departman> repository = new Repository<Departman>();
        private Repository<Sube> repositorySube = new Repository<Sube>();

        public List<Departman> GetDepartmans()
        {
            return repository.List();
        }


        public void AddDepartman(Departman model,int Id)
        {
            Sube sube = repositorySube.Find(x => x.Id == Id);
           
            Departman departman = new Departman()
            {
                isim = model.isim,
                Sube=sube,
                
            };
            sube.Departmens.Add(departman);
            repository.Insert(departman);
        }


        public void UpdateDepartman(Departman model,int dropSube)
        {
            Departman departman = repository.Find(x => x.Id == model.Id);
            Sube sube = repositorySube.Find(x => x.Id == dropSube);
            departman.isim = model.isim;
            departman.Sube = sube;
            repository.Update();
        }

        public int DeleteDepartman(int? Id)
        {
            Departman departman = repository.Find(x => x.Id == Id);
            if(departman.Kisis.Count()!=0||departman.Ekips.Count!=0)
            {
                return 0;
            }
            else
            {
                List<Sube> subes=repositorySube.List();
                foreach(Sube s in subes)
                {
                   Departman sil=s.Departmens.Find(x => x.Id == Id);
                    if(sil!=null)
                    {
                        s.Departmens.Remove(sil);
                        repository.Delete(departman);
                        return 1;
                    }
                }
                return 1;
            }
            

            
        }


    }
}
