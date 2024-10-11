using System.Linq.Expressions;
using FluentValidation;
using Xunarmand.Application.Users.Models;
using Xunarmand.Application.Users.Services;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;
using Xunarmand.Domain.Enums;
using Xunarmand.Persistence.Extensions;
using Xunarmand.Persistence.Repositories.Interface;

namespace Xunarmand.Infrastructure.Users.Services;

public class UserService(IUserRepository userRepository, IValidator<User> validator) : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, QueryOptions queryOptions = default)
        => userRepository.Get(predicate, queryOptions);

    public IQueryable<User> Get(UserFilter clientFilter, QueryOptions queryOptions = default)
        => userRepository.Get(queryOptions: queryOptions).ApplyPagination(clientFilter);

    public ValueTask<User?> GetByIdAsync(Guid clientId, QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default)
        => userRepository.GetByIdAsync(clientId, queryOptions, cancellationToken);

    public ValueTask<User> CreateAsync(User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator
            .Validate(user,
                options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return userRepository.CreateAsync(user, new CommandOptions(skipSaveChanges: false), cancellationToken);
    }


    public async ValueTask<User> UpdateAsync(User user, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var foundClient = await GetByIdAsync(user.Id, cancellationToken: cancellationToken) ??
                          throw new InvalidOperationException();

        foundClient.Name = user.Name;
        foundClient.EmailAddress = user.EmailAddress;
        foundClient.PasswordHash = user.PasswordHash;
        foundClient.PhoneNumber = user.PhoneNumber;

        return await userRepository.UpdateAsync(foundClient, commandOptions, cancellationToken);
    }

    public ValueTask<User?> DeleteByIdAsync(Guid clientId, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
        => userRepository.DeleteByIdAsync(clientId, commandOptions, cancellationToken);
}