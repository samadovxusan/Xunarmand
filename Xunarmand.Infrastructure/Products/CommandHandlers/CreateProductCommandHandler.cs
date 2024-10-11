using AutoMapper;
using Xunarmand.Application.Products.Commands;
using Xunarmand.Application.Products.Models;
using Xunarmand.Application.Products.Service;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Infrastructure.Products.CommandHandlers;

public class CreateProductCommandHandler(IProductService service, IMapper mapper)
    : ICommandHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            ProductName = request.CreateProduct.ProductName,
            Description = request.CreateProduct.Description,
            ProductType = request.CreateProduct.ProductType,
            Price = request.CreateProduct.Price,
            ImageUrl = request.CreateProduct.ImageUrlPath,
            CreatedTime = DateTimeOffset.UtcNow,
        };
        
        var newProduct = await service.CreateAsync(product, cancellationToken: cancellationToken);
        return mapper.Map<ProductDto>(newProduct);
    }
}