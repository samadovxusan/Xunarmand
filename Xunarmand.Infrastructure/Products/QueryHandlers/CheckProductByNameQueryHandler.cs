using System.Globalization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunarmand.Application.Products.Queries;
using Xunarmand.Application.Products.Service;
using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Infrastructure.Products.QueryHandlers;

public class CheckProductByNameQueryHandler(IProductService service, IMapper mapper)
    : IQueryHandler<CheckProductByNameQuery, string>
{
    public async Task<string> Handle(CheckProductByNameQuery request, CancellationToken cancellationToken)
    {
        var userFirstName = await service.Get(client => client.ProductName == request.ProductName,
                new QueryOptions(QueryTrackingMode.AsNoTracking))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return userFirstName!.Price.ToString(CultureInfo.InvariantCulture);
    }
}