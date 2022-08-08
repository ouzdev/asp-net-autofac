namespace AspNetAutofac.API.Models;

public interface IProductDal
{
    Task<Product?> GetProductById(int productId);
    Task<List<Product>> GetAllProductsAsync();

}