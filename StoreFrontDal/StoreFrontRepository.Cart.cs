using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreFrontDal.Contracts;

namespace StoreFrontDal
{
    public partial class StoreFrontRepository
    {
		public CartContract GetACart()
        {
			//do database stuff
			//Take cart from database and turn it into cart contract
            return new CartContract();
        }

		public CartContract AddItemToCart(ProductContract product, CartContract cart)
        {
            //do database stuff

            return cart;
        }
    }
}
