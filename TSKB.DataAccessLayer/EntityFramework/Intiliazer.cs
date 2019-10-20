using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TSKB.Entities;

namespace TSKB.DataAccessLayer
{
    public class Intiliazer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            

            for(int i=0;i<10;i++)
            {
                Sube sube = new Sube()
                {
                    isim = FakeData.NameData.GetCompanyName(),
                };
                context.Subes.Add(sube);
               
                for(int k=0;k<5;k++)
                {
                    Departman departman = new Departman()
                    {
                        isim=FakeData.NameData.GetCompanyName(),
                        Sube=sube,
                        
                    };
                   
                    context.Departmens.Add(departman);
                    for(int j=0;j<5;j++)
                    {
                        Ekip ekip = new Ekip()
                        {
                            isim = FakeData.NameData.GetCompanyName(),
                            Departman = departman,
                            Sube=sube
                        };
                        context.Ekips.Add(ekip);
                    }
                }
            }
            context.SaveChanges();
            Repository<Departman> departmans = new Repository<Departman>();
            Repository<Ekip> ekips = new Repository<Ekip>();
            Repository<Sube> subes = new Repository<Sube>();
            Kisi calisan = new Kisi()
            {
                isim = "Cihad",
                soyisim = "İnan",
                Statu = Statu.mudur,
                dogumTarihi = new DateTime(1994, 9, 2),
                maas = 4000,
                Departman=departmans.Find(x=>x.Id==1),
                Ekip=ekips.Find(x => x.Id == 1),
                Sube=subes.Find(x => x.Id == 1)

            };
            context.Kisis.Add(calisan);
            Kisi calisan2 = new Kisi()
            {
                isim = "ebu",
                soyisim = "İnan",
                Statu = Statu.uzman,
                dogumTarihi = new DateTime(1994, 2, 4),
                maas = 4600,
                Departman = departmans.Find(x => x.Id == 2),
                Ekip = ekips.Find(x => x.Id == 2),
                Sube = subes.Find(x => x.Id == 2)

            };
            context.Kisis.Add(calisan2);
            context.SaveChanges();
           
        }
    }
}
