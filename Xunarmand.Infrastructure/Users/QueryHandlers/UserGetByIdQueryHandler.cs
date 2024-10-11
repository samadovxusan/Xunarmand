using AutoMapper;
using Xunarmand.Application.Users.Models;
using Xunarmand.Application.Users.Queries;
using Xunarmand.Application.Users.Services;
using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Infrastructure.Users.QueryHandlers;

public class UserGetByIdQueryHandler(IUserService service,IMapper mapper):IQueryHandler<UserGetByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await service.GetByIdAsync(
            request.Id, new QueryOptions(QueryTrackingMode.AsNoTracking), cancellationToken
        );
        return mapper.Map<UserDto>(foundUser);
    }
}