using Domain.Entities;
using Xunarmand.Application.Users.Models;

namespace Xunarmand.Application.Auth.Services;

public interface IAuthService
{
    ValueTask<Boolean> Register (UserModel register);
    ValueTask<LoginDto> Login (Login login);
}