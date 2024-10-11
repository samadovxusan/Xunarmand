using Xunarmand.Application.Users.Commands;
using Xunarmand.Application.Users.Services;
using Xunarmand.Domain.Common.Commands;

namespace Xunarmand.Infrastructure.Users.CommandHandlers;

public class UserDeleteByIdCommandHandler(IUserService service):ICommandHandler<UserDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(UserDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        await service.DeleteByIdAsync(request.UserId, cancellationToken: cancellationToken);
        return true;
    }
}