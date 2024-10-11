using System.Security.Claims;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Application.Auth.Services;

public interface IIdentityTokenGeneratorService
{
    Task<string> GenerateToken(User user);
    Task<string> GenerateToken(IEnumerable<Claim> additionalClaims);
    
}