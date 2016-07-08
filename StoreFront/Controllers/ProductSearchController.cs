using StoreFront.Models;
using StoreFrontDal;
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

            var repository = new StoreFrontRepository();

            var products = repository.SearchProducts(model.SearchText);

            model.Results = products.Select(x => new SearchResultViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImageFile = x.ImageFile
            }).ToList();

            return View("~/Views/ProductSearch/Index.cshtml", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            //database stuff happens
            var cart = new {
                TotalPrice = 1000m,
                Quantity = 5,
                TransactionMessage = "Success",
            };

            return Json(cart);
        }
    }
}