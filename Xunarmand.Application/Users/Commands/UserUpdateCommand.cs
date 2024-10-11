using Xunarmand.Application.Users.Models;
using Xunarmand.Domain.Common.Commands;

namespace Xunarmand.Application.Users.Commands;

public record UserUpdateCommand : ICommand<UserDto>
{
    public UserDto UserDto { get; set; }
}