using StoreFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreFront.Controllers
{
    public class ProductSearchController : Controller
    {
        [Authorize]
        // GET: ProductSearch
        public ActionResult Index()
        {
            var x = new SearchViewModel();
            x.Name = HttpContext.User.Identity.Name;

            return View(x);
        }

        [Authorize]
        public ActionResult Search(SearchViewModel model)
        {
            model.Name = HttpContext.User.Identity.Name;

            using (var context = new StoreFrontDal.StoreFrontEntities())
            {
                var products = context.Products.Where(x => x.ProductName.Contains(model.SearchText));
                model.Results = products.Select(x => new SearchResultViewModel
                {
                    Name = x.ProductName,
                    Price = x.Price ?? 9999999,
                    ImageFile = x.ImageFile
                }).ToList();
            }

            return View("~/Views/ProductSearch/Index.cshtml", model);
        }
    }
}