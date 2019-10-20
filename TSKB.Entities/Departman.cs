using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSKB.Entities
{
    [Table("Departman")]
    public class Departman:EntityBase
    {
        [Required]
        public string isim { get; set; }


        public virtual List<Kisi> Kisis { get; set; }
        public virtual Sube Sube { get; set; }
        public virtual List<Ekip> Ekips { get; set; }

        public Departman()
        {
            Kisis = new List<Kisi>();
            Ekips = new List<Ekip>();
        }

    }
}
