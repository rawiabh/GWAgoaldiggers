using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Domaine.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String  UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AcountCreationDate { get; set; }
        public String Email { get; set; }
        public String ConfirmPassword { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }



        public virtual Session Session { get; set; }
        public virtual ICollection<Product> UserProducts { get; set; }


    }
}
