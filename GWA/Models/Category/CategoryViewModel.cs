using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GWA.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public virtual ICollection<GWA.Domaine.Entities.Product> CategoryProducts { get; set; }
    }
}