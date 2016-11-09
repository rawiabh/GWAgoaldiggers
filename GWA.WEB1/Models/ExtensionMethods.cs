using GWA.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GWA.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<string> Noms)
        {
            return
                Noms.OrderBy(genre => Noms)
                      .Select(genre =>
                          new SelectListItem
                          {

                              Text = genre,
                              Value = genre
                          });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
         this IEnumerable<Category> categories)
        {
            return
                categories.OrderBy(c => c.Name)
                      .Select(c =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = c.Name,
                              Value = c.Id.ToString()
                              
                          });
        }
    }
}