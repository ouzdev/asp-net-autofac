namespace AspNetAutofac.API.Models;

public interface IProductDal
{
    Task<Product?> GetProductById(int productId);
    Task<List<Product>> GetAllProductsAsync();
    Task<bool> AddProduct(Product product);
    Task<bool> UpdateProduct(int id, Product product);
    Task<int> SaveChangesAsync();

}