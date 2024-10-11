using Xunarmand.Domain.Common.Commands;

namespace Xunarmand.Application.Products.Commands;

public record DeleteProductByIdCommand : ICommand<bool>
{
    public Guid ProductId { get; set; }
}