using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Domaine.Entities
{
   public class Session
    {
        public int Id { get; set; }
        [Key, ForeignKey("User")]
        public int userId { get; set; }

        public virtual User User { get; set; }
    }
}
