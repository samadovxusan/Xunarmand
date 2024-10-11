using System.Linq.Expressions;
using FluentValidation;
using Xunarmand.Application.Products.Models;
using Xunarmand.Application.Products.Service;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;
using Xunarmand.Domain.Enums;
using Xunarmand.Persistence.Extensions;
using Xunarmand.Persistence.Repositories.Interface;

namespace Xunarmand.Infrastructure.Products.Services;

public class ProductService(IProductRepository repository, IValidator<Product> validator) : IProductService
{
    public IQueryable<Product> Get(Expression<Func<Product, bool>>? predicate = default,
        QueryOptions queryOptions = default)
        => repository.Get(predicate, queryOptions);

    public IQueryable<Product> Get(ProductFilter clientFilter, QueryOptions queryOptions = default)
        => repository.Get(queryOptions: queryOptions).ApplyPagination(clientFilter);

    public ValueTask<Product?> GetByIdAsync(Guid userId, QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default)
    {
        return repository.GetByIdAsync(userId, queryOptions, cancellationToken);
    }


    public ValueTask<Product> CreateAsync(Product product, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator
            .Validate(product,
                options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return repository.CreateAsync(product, commandOptions, cancellationToken);
    }

    public async ValueTask<Product> UpdateAsync(Product product, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator
            .ValidateAsync(product,
                options => options.IncludeRuleSets(EntityEvent.OnUpdate.ToString()), cancellationToken);


        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        var foundClient = await GetByIdAsync(product.Id, cancellationToken: cancellationToken) ??
                          throw new InvalidOperationException();


        foundClient.ProductName = product.ProductName;
        foundClient.Description = product.Description;
        foundClient.Price = product.Price;
        foundClient.ImageUrl = product.ImageUrl;

        return await repository.UpdateAsync(foundClient, commandOptions, cancellationToken);
    }

    public ValueTask<Product?> DeleteByIdAsync(Guid productId, CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
        => repository.DeleteByIdAsync(productId, commandOptions, cancellationToken);
}