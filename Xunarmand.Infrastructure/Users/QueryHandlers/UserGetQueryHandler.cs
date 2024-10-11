using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunarmand.Application.Users.Models;
using Xunarmand.Application.Users.Queries;
using Xunarmand.Application.Users.Services;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Infrastructure.Users.QueryHandlers;

public class UserGetQueryHandler(IUserService service, IMapper mapper):IQueryHandler<UserGetQuery,ICollection<UserDto>>
{
    public async Task<ICollection<UserDto>> Handle(UserGetQuery request, CancellationToken cancellationToken)
    {
        var matchedUsers = await service
                               .Get(request.Filter, new QueryOptions() { TrackingMode = QueryTrackingMode.AsNoTracking })
                               .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<UserDto>>(matchedUsers);
    }
}