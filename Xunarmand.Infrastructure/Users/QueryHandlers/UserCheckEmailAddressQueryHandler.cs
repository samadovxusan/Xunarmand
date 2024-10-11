using Microsoft.EntityFrameworkCore;
using Xunarmand.Application.Users.Queries;
using Xunarmand.Application.Users.Services;
using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Infrastructure.Users.QueryHandlers;

public class UserCheckEmailAddressQueryHandler(IUserService service)
    : IQueryHandler<CheckUserByEmailAddressQuery, string?>
{
    public async Task<string?> Handle(CheckUserByEmailAddressQuery request, CancellationToken cancellationToken)
    {
        var userFirstName = await service
            .Get(
                client => client.EmailAddress == request.EmailAddress,
                new QueryOptions(QueryTrackingMode.AsNoTracking)
            )
            .Select(client => client.Name)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return userFirstName;
    }
}