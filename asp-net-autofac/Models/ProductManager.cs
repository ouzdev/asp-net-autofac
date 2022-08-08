namespace AspNetAutofac.API.Models;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public Task<Product?> GetProductById(int productId)
    {
        return _productDal.GetProductById(productId);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productDal.GetAllProductsAsync();
    }
}