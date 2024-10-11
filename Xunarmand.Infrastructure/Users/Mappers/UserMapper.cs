using AutoMapper;
using Xunarmand.Application.Users.Models;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Infrastructure.Users.Mappers;

public class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserModel>().ReverseMap();
    }
}