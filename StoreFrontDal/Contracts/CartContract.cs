using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFrontDal.Contracts
{
    public class CartContract
    {
        public List<ProductContract> Products { get; set; }
    }
}
