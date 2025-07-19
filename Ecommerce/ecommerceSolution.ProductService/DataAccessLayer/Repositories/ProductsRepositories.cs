using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    internal class ProductsRepositories : IProductRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public ProductsRepositories(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product?> AddProduct(Product obj)
        {
            _dbContext.Products.Add(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
           Product? existProduct =  await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == productId);
           
            if(existProduct ==null)
            {
                return false;
            }

            _dbContext.Products.Remove(existProduct);    
            var affectedRows =   await _dbContext.SaveChangesAsync();

            if(affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<Product?> GetProductByCondition(Expression<Func<Product,bool>> conditionExpression)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(conditionExpression);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
           return await _dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionexpression)
        {
            return await _dbContext.Products.Where(conditionexpression).ToListAsync();
        }

        public async Task<Product?> UpdateProduct(Product obj)
        {
            Product? existingProduct = await _dbContext.Products
                .FirstOrDefaultAsync(x => x.ProductID == obj.ProductID);

            if(existingProduct == null)
            {
                return null;
            }

            existingProduct.ProductName = obj.ProductName;
            existingProduct.UnitPrice = obj.UnitPrice;
            existingProduct.QuantityInStock = obj.QuantityInStock;
            existingProduct.Category = obj.Category;

            await _dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}
