using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSKB.Entities
{
    public class EntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public DateTime CreatOn { get; set; }

        public EntityBase()
        {
            CreatOn = DateTime.Now;
        }
    }
}
