using AutoMapper;
using Xunarmand.Application.Products.Commands;
using Xunarmand.Application.Products.Service;
using Xunarmand.Domain.Common.Commands;

namespace Xunarmand.Infrastructure.Products.CommandHandlers;

public class DeleteProductByIdCommandHandler(IProductService service, IMapper mapper)
    : ICommandHandler<DeleteProductByIdCommand, bool>
{
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        await service.DeleteByIdAsync(request.ProductId, cancellationToken: cancellationToken);

        return true;
    }
}