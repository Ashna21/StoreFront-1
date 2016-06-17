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

        public List<Product> SearchProducts(string searchString)
        {
            return _context.Products.Where(x => x.ProductName.Contains(searchString) || x.Description.Contains(searchString)).ToList();
        }
    }
}
