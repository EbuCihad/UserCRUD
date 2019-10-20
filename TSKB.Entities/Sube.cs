using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSKB.Entities
{
    [Table("Sube")]
    public class Sube:EntityBase
    {
        [Required]
        public string isim { get; set; }

        public virtual List<Kisi> Kisis { get; set; }
        public virtual List<Departman> Departmens { get; set; }
        public virtual List<Ekip> Ekips { get; set; }

        public Sube()
        {
            Kisis = new List<Kisi>();
            Departmens = new List<Departman>();
            Ekips = new List<Ekip>();
        }
    }
}
