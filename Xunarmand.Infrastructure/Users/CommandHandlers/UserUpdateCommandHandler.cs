using AutoMapper;
using Xunarmand.Application.Users.Commands;
using Xunarmand.Application.Users.Models;
using Xunarmand.Application.Users.Services;
using Xunarmand.Domain.Common.Commands;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Infrastructure.Users.CommandHandlers;

public class UserUpdateCommandHandler(IUserService service, IMapper mapper)
    : ICommandHandler<UserUpdateCommand, UserDto>
{
    public async Task<UserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<User>(request.UserDto);

        var updateUser = await service.UpdateAsync(entity, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(updateUser);
    }
}