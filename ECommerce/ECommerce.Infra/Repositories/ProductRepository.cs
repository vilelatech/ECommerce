using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        return await _context.ProductBrands.ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await _context.ProductTypes.ToListAsync();
    }
}