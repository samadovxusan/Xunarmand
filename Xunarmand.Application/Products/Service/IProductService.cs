using System.Linq.Expressions;
using Xunarmand.Application.Products.Models;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Application.Products.Service;

public interface IProductService
{
    /// <summary>
    /// Retrieves a queryable collection of client entities based on the specified predicate and query options.
    /// </summary>
    /// <param name="predicate">A predicate to filter the clients (optional).</param>
    /// <param name="queryOptions">Options for customizing the query (optional).</param>
    /// <returns>A queryable collection of client entities.</returns>
    IQueryable<Domain.Entities.Product> Get(Expression<Func<Domain.Entities.Product, bool>>? predicate = default,
        QueryOptions queryOptions = default);

    /// <summary>
    /// Retrieves a queryable collection of client entities based on the specified client filter and query options.
    /// </summary>
    /// <param name="productFilter">A filter to apply when retrieving clients.</param>
    /// <param name="queryOptions">Options for customizing the query (optional).</param>
    /// <returns>A queryable collection of client entities.</returns>
    IQueryable<Domain.Entities.Product> Get(ProductFilter productFilter, QueryOptions queryOptions = default);

    /// <summary>
    /// Asynchronously retrieves a client entity by its unique identifier and query options.
    /// </summary>
    /// <param name="userId">The unique identifier of the client.</param>
    /// <param name="queryOptions">Options for customizing the query (optional).</param>
    /// <param name="cancellationToken">A cancellation token to cancel the asynchronous operation (optional).</param>
    /// <returns>A task representing the asynchronous operation, containing the client entity, or null if not found.</returns>
    ValueTask<Domain.Entities.Product?> GetByIdAsync(Guid userId, QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously creates a new client entity with the specified options.
    /// </summary>
    /// <param name="product">The user entity to create.</param>
    /// <param name="commandOptions">Options for customizing the command (optional).</param>
    /// <param name="cancellationToken">A cancellation token to cancel the asynchronous operation (optional).</param>
    /// <returns>A task representing the asynchronous operation, containing the created client entity.</returns>
    ValueTask<Domain.Entities.Product> CreateAsync(Domain.Entities.Product product,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously updates an existing client entity with the specified options.
    /// </summary>
    /// <param name="product">The user entity to update.</param>
    /// <param name="commandOptions">Options for customizing the command (optional).</param>
    /// <param name="cancellationToken">A cancellation token to cancel the asynchronous operation (optional).</param>
    /// <returns>A task representing the asynchronous operation, containing the updated user entity.</returns>
    ValueTask<Domain.Entities.Product> UpdateAsync(Domain.Entities.Product product,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously deletes a client entity by its unique identifier with the specified options.
    /// </summary>
    /// <param name="productId">The unique identifier of the user to delete.</param>
    /// <param name="commandOptions">Options for customizing the command (optional).</param>
    /// <param name="cancellationToken">A cancellation token to cancel the asynchronous operation (optional).</param>
    /// <returns>A task representing the asynchronous operation, containing the deleted client entity, or null if not found.</returns>
    ValueTask<Domain.Entities.Product?> DeleteByIdAsync(Guid productId, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}