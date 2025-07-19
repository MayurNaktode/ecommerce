using DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace DataAccessLayer.RepositoryContract
{
    /// <summary>
    /// Represents a repository for amanging products table data
    /// Returens all the products from the table
    /// </summary>
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsByCondition(Expression<Func<Product, bool>> conditionexpression);
        Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);
        Task<Product?> AddProduct(Product obj);
        Task<Product?> UpdateProduct(Product obj);
        Task<bool> DeleteProduct(Guid productId);
    }
}
