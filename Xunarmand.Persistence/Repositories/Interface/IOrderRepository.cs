using System.Linq.Expressions;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Persistence.Repositories.Interface;

/// <summary>
/// Represents a repository for managing orders.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Retrieves a collection of orders based on the provided predicate and query options.
    /// </summary>
    /// <param name="predicate">An optional expression to filter orders.</param>
    /// <param name="queryOptions">Options for query customization.</param>
    /// <returns>An IQueryable collection of orders.</returns>
    IQueryable<Order> Get(Expression<Func<Order, bool>>? predicate = default, QueryOptions queryOptions = default);

    /// <summary>
    /// Retrieves an order by its unique identifier asynchronously.
    /// </summary>
    /// <param name="userId">The unique identifier of the order.</param>
    /// <param name="queryOptions">Options for query customization.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing the order if found; otherwise, null.</returns>
    ValueTask<Order?> GetByIdAsync(Guid userId, QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new order asynchronously.
    /// </summary>
    /// <param name="order">The order to be created.</param>
    /// <param name="commandOptions">Options for command customization.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing the created order.</returns>
    ValueTask<Order> CreateAsync(Order order, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing order asynchronously.
    /// </summary>
    /// <param name="order">The order to be updated.</param>
    /// <param name="commandOptions">Options for command customization.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing the updated order.</returns>
    ValueTask<Order> UpdateAsync(Order order, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an order by its unique identifier asynchronously.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order to delete.</param>
    /// <param name="commandOptions">Options for command customization.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, indicating the result of the deletion.</returns>
    ValueTask<Order?> DeleteByIdAsync(Guid orderId, CommandOptions commandOptions,
        CancellationToken cancellationToken = default);
}
