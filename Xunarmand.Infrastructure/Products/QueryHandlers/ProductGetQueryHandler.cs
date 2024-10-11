using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunarmand.Application.Products.Models;
using Xunarmand.Application.Products.Queries;
using Xunarmand.Application.Products.Service;
using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Infrastructure.Products.QueryHandlers;

public class ProductGetQueryHandler(IProductService service, IMapper mapper)
    : IQueryHandler<ProductGetQuery, ICollection<ProductDto>>
{
    public async Task<ICollection<ProductDto>> Handle(ProductGetQuery request, CancellationToken cancellationToken)
    {
        var matchedUsers = await service
            .Get(request.Filter, new QueryOptions(QueryTrackingMode.AsNoTracking))
            .ToListAsync(cancellationToken);
        return mapper.Map<ICollection<ProductDto>>(matchedUsers);
    }
}