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
       // [Key]
       // public int Id { get; set; }
       
       [Key]
        public int IdSession { get; set; }
        public virtual User User { get; set; }
    }
}
