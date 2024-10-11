using Xunarmand.Application.Users.Models;
using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Application.Users.Queries;

/// <summary>
/// Represents a command to retrieve a client by their unique identifier.
/// </summary>
public class UserGetByIdQuery : IQuery<UserDto>
{
    public Guid Id { get; set; }
}