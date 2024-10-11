using Xunarmand.Application.Users.Models;
using Xunarmand.Domain.Common.Queries;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Application.Users.Queries;

public class UserGetQuery : IQuery<ICollection<UserDto>>
{
    public UserFilter Filter { get; set; }
}