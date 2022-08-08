using AspNetAutofac.API.Models;

namespace AspNetAutofac.API.Services;

public interface IProductService
{
    Task<Product?> GetProductById(int productId);
    Task<List<Product>> GetAllProductsAsync();
    Task<bool> AddProduct(Product product);
    Task<bool> UpdateProduct(int id, Product product);
}