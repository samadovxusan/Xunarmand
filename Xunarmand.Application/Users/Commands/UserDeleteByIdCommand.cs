using Xunarmand.Domain.Common.Commands;

namespace Xunarmand.Application.Users.Commands;

public record UserDeleteByIdCommand:ICommand<bool>
{
    public Guid UserId { get; set; }
}