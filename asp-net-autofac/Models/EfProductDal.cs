using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace AspNetAutofac.API.Models;

public class EfProductDal : IProductDal
{
    private readonly AppDbContext _appDbContext;

    public EfProductDal(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Product?> GetProductById(int productId)
    {
        return await _appDbContext.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _appDbContext.Products.ToListAsync();
    }

    public async Task<bool> AddProduct(Product product)
    {
        EntityEntry<Product>? result = await _appDbContext.Products.AddAsync(product);
        result.State = EntityState.Added;
        return true;
    }

    public async Task<bool> UpdateProduct(int id, Product product)
    {
        var updateProduct = await _appDbContext.Products.FindAsync(id);
        updateProduct.Id = product.Id;
        updateProduct.Name = product.Name;
        EntityEntry<Product>? result = _appDbContext.Products.Update(updateProduct);
        result.State = EntityState.Modified;
        return true;
    }

    public Task<int> SaveChangesAsync()
    {
      return  _appDbContext.SaveChangesAsync();
    }
}
