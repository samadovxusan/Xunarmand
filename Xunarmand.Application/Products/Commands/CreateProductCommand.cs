using Xunarmand.Application.Products.Models;
using Xunarmand.Domain.Common.Commands;

namespace Xunarmand.Application.Products.Commands;

public record CreateProductCommand : ICommand<ProductDto>
{
    public ProductCredential CreateProduct { get; set; }
}