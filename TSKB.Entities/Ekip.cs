using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSKB.Entities
{
    [Table("Ekip")]
    public class Ekip:EntityBase
    {
        [Required]
        public string isim { get; set; }


        public virtual Sube Sube { get; set; }
        public virtual Departman Departman { get; set; }
        public virtual List<Kisi> Kisis { get; set; }

        public Ekip()
        {
            Kisis = new List<Kisi>();
        }

    }
}
