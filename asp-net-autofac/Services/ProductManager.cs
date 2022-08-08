using AspNetAutofac.API.Models;

namespace AspNetAutofac.API.Services;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task<Product?> GetProductById(int productId)
    {
        var result = await _productDal.GetProductById(productId);

        return result;

    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productDal.GetAllProductsAsync();
    }

    public async Task<bool> AddProduct(Product product)
    {
        var result = await _productDal.AddProduct(product);
        if (result)
        {
            await _productDal.SaveChangesAsync();
            return result;

        }
        return result;
    }

    public async Task<bool> UpdateProduct(int id, Product product)
    {
        return await _productDal.UpdateProduct(id, product);
    }
}