using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunarmand.Application.Auth.Services;
using Xunarmand.Application.Users.Models;
using Xunarmand.Domain.Entities;
using Xunarmand.Persistence.DataContext;

namespace Xunarmand.Infrastructure.Auth.Services;

public class AuthService(AppDbContext dbContext, IMapper mapper, IConfiguration configuration): IAuthService
{
    public async  ValueTask<bool> Register(UserModel register)
    {
        try
        {
            var user = mapper.Map<User>(register);
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync(); 
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async ValueTask<LoginDto> Login(Login login)
    {
        var token = new LoginDto();
        var newUser = await dbContext.Users.FirstOrDefaultAsync(x => x.PasswordHash == login.Password && x.EmailAddress == login.Email);
        if(newUser == null)
        {
            token.Succes = false;
            return token;
        }
        var jwtToken = new IdentityTokenGeneratorService(configuration);
        token.Token = await jwtToken.GenerateToken(newUser); 
        return token;
    }
}