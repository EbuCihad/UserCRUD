using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSKB.Entities
{
    [Table("Kisi")]
    public class Kisi:EntityBase
    {
        [Required]
        public string isim { get; set; }
        [Required]
        public string soyisim { get; set; }
        public DateTime dogumTarihi { get; set; }
        [Required]
        public int maas { get; set; }
        [Required]
        public Statu Statu { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual Departman Departman { get; set; }
        public virtual Ekip Ekip { get; set; }
        
    }
    

    public enum Statu
    {
        uzman=1,
        uzmanYardımcisi=2,
        mudur=3,
        yonetici=4,
        yoneticiYardimcisi=5
    }

 
}
