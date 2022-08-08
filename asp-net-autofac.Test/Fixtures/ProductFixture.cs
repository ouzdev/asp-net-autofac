using AspNetAutofac.API.Models;

namespace AspNetAutofac.API.Test.Fixtures
{
    public static class ProductFixture
    {
        public static Product GetTestProduct() => new Product()
        {
            Id = 1,
            Name = "Product 1"
        };
        public static List<Product> GetTestProducts() => new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Product 1"
            },
            new Product()
            {
                Id = 2,
                Name = "Product 2"
            },
            new Product()
            {
                Id = 3,
                Name = "Product 3"
            },
            new Product()
            {
                Id = 4,
                Name = "Product 4"
            }
        };
    }
}
