using System.Linq.Expressions;

namespace AspNetAutofac.API.Models;

public class EfProductDal : IProductDal
{
    List<Product> products = new List<Product>
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
        },
        new Product()
        {
            Id = 5,
            Name = "Product 5"
        },
        new Product()
        {
            Id = 6,
            Name = "Product 6"
        }
    };


    public async Task<Product?> GetProductById(int productId)
    {
        return await Task.FromResult(products.FirstOrDefault(p => p.Id == productId));
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await Task.FromResult(products);
    }

}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}