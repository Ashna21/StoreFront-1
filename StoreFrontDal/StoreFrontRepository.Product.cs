using StoreFrontDal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFrontDal
{
    public partial class StoreFrontRepository
    {
		public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<ProductContract> SearchProducts(string searchString)
        {
            return _context.Products.Where(x => x.ProductName.Contains(searchString) || x.Description.Contains(searchString))
                .Select(x => new ProductContract {
                    Id = x.ProductID,
                    Name = x.ProductName, 
                    Price = x.Price ?? 999999,
                    ImageFile = x.ImageFile
                }).ToList();
        }
    }
}
