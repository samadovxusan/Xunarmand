using System.Linq.Expressions;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;
using Xunarmand.Persistence.DataContext;
using Xunarmand.Persistence.Repositories.Interface;

namespace Xunarmand.Persistence.Repositories;

public class ProductRepository(AppDbContext appDbContext)
    : EntityRepositoryBase<Product, AppDbContext>(appDbContext), IProductRepository
{
    public IQueryable<Product> Get(Expression<Func<Product, bool>>? predicate = default,
        QueryOptions queryOptions = default) 
        => base.Get(predicate, queryOptions);
    
    public ValueTask<Product?> GetByIdAsync(Guid clientId, QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(clientId, queryOptions, cancellationToken);


    public ValueTask<Product> CreateAsync(Product product, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)

    {
        return base.CreateAsync(product, commandOptions, cancellationToken);
    }

    public ValueTask<Product> UpdateAsync(Product product, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(product, commandOptions, cancellationToken);
    }

    public ValueTask<Product?> DeleteByIdAsync(Guid clientId, CommandOptions commandOptions,
                                               CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(clientId, commandOptions, cancellationToken);
}