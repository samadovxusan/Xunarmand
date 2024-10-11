using System.Linq.Expressions;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;
using Xunarmand.Persistence.DataContext;
using Xunarmand.Persistence.Repositories.Interface;

namespace Xunarmand.Persistence.Repositories;

public class UserRepository(AppDbContext appContext)
    : EntityRepositoryBase<User, AppDbContext>(appContext), IUserRepository
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, QueryOptions queryOptions = default)
    {
        return base.Get(predicate, queryOptions);
    }

    public ValueTask<User?> GetByIdAsync(Guid clientId, QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(clientId, queryOptions, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, commandOptions, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, commandOptions, cancellationToken);
    }

    public ValueTask<User?> DeleteByIdAsync(Guid clientId, CommandOptions commandOptions,
        CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(clientId, commandOptions, cancellationToken);
    }
}