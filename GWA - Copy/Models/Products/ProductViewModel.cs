using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GWA.Models.Product
{
    public class ProductViewModel
    {
        
        public int Id { get; set; }
        public String Name { get; set; }
        public bool status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string reference { get; set; }
        public float CurrentPrice { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }


        public int IdUser { get; set; }

        [Display(Name = "Categories")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }

    }
}