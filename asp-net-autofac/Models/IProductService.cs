namespace AspNetAutofac.API.Models;

public interface IProductService
{
    Task<Product?> GetProductById(int productId);
    Task<List<Product>> GetAllProductsAsync();
}