using System.Linq.Expressions;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Persistence.Repositories.Interface;

/// <summary>
/// Interface representing a repository for managing products.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves products based on the specified predicate and query options.
    /// </summary>
    /// <param name="predicate">The predicate to filter products.</param>
    /// <param name="queryOptions">Options for querying products.</param>
    /// <returns>An IQueryable collection of products.</returns>
    IQueryable<Product> Get(Expression<Func<Product, bool>>? predicate = default, QueryOptions queryOptions = default);

    /// <summary>
    /// Retrieves a product by its unique identifier asynchronously.
    /// </summary>
    /// <param name="clientId">The unique identifier of the product.</param>
    /// <param name="queryOptions">Options for querying products.</param>
    /// <param name="cancellationToken">Cancellation token for asynchronous operation.</param>
    /// <returns>A ValueTask representing the asynchronous operation with the retrieved product.</returns>
    ValueTask<Product?> GetByIdAsync(Guid clientId, QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new product asynchronously.
    /// </summary>
    /// <param name="product">The product to create.</param>
    /// <param name="commandOptions">Options for creating the product.</param>
    /// <param name="cancellationToken">Cancellation token for asynchronous operation.</param>
    /// <returns>A ValueTask representing the asynchronous operation with the created product.</returns>
    ValueTask<Product> CreateAsync(Product product, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing product asynchronously.
    /// </summary>
    /// <param name="product">The product to update.</param>
    /// <param name="commandOptions">Options for updating the product.</param>
    /// <param name="cancellationToken">Cancellation token for asynchronous operation.</param>
    /// <returns>A ValueTask representing the asynchronous operation with the updated product.</returns>
    ValueTask<Product> UpdateAsync(Product product, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a product by its unique identifier asynchronously.
    /// </summary>
    /// <param name="clientId">The unique identifier of the product.</param>
    /// <param name="commandOptions">Options for deleting the product.</param>
    /// <param name="cancellationToken">Cancellation token for asynchronous operation.</param>
    /// <returns>A ValueTask representing the asynchronous operation.</returns>
    ValueTask<Product?> DeleteByIdAsync(Guid clientId, CommandOptions commandOptions,
        CancellationToken cancellationToken = default);
}
