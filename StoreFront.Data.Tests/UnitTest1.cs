using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreFrontDal;
using System.Linq;

namespace StoreFront.Data.Tests
{
    [TestClass]
    public class ProductTests
    {

        [TestMethod]
        public void ProductSearch()
        {
            var x = new StoreFrontRepository();

            var results = x.SearchProducts("cat");

            Assert.AreEqual(1, results.Count, "There is more than one cat");
        }

        [TestMethod]
        public void AddToCart()
        {
            //Arrange
            var context = new StoreFrontRepository();
            var startingCart = context.GetACart();
            var startingCount = startingCart.Products.Count;

            //Act
            var product = context.SearchProducts("cat").First();
            context.AddItemToCart(product, startingCart);

            //Assert
            var endingCart = context.GetACart();
            Assert.Equals(startingCount + 1, endingCart.Products.Count);
        } 
    }
}
