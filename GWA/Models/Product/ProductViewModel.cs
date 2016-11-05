using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}