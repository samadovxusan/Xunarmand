using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Xunarmand.Domain.Entities;
using Xunarmand.Domain.Enums;
using Xunarmand.Persistence.DataContext;

namespace Xunarmand.Api.Data;

public static class  SeedDataExtensions
{
    /// <summary>
    /// Initializes the seed data asynchronously.
    /// </summary>
    public static async ValueTask InitializeSeedAsync(this IServiceProvider serviceProvider)
    {
        var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();

        if (!await appDbContext.Users.AnyAsync())
             await appDbContext.SeedUsersAsync();
    }

    private static async ValueTask SeedUsersAsync(this AppDbContext dbContext)
        {
            var clients = new List<User>
            {
                  new()
                {
                    Id = Guid.Parse("54e16518-d140-4453-80c9-1a117dbe75fd"),
                    Name = "Abduqodir",
                    PhoneNumber = "33 011 71 11",
                    EmailAddress = "Abduqodir@gmail.com",
                    PasswordHash = "983037334", // qwerty123
                    Role = Role.Admin
                },
                     new()
                {
                    Id = Guid.Parse("34e16518-d140-4453-80c9-1a117dbe75fd"),
                    Name = "Tolqin",
                    PhoneNumber = "33 011 71 11",
                    EmailAddress = "Abduqodir@gmail.com",
                    PasswordHash = "983037334", // qwerty123
                    Role = Role.Admin
                },
                     new()
                {
                    Id = Guid.Parse("54e16318-d140-4453-80c9-1a117dbe75fd"),
                    Name = "Husan",
                    PhoneNumber = "99 843 90 13",
                    EmailAddress = "Samadovxusan@gmail.com",
                    PasswordHash = "husan9013", // qwerty123
                    Role = Role.Admin
                },
                new()
                {
                    Id = Guid.Parse("54e16318-d140-4453-80c9-1a117dbe75fd"),
                    Name = "John",
                    PhoneNumber = "123456789012",
                    EmailAddress = "example@gmail.com",
                    PasswordHash = "$2a$12$pHdneNbJGp4SnN1ovHrNqevf6I.k3Gy.7OMJoWWB0RByv0foi4fgy", // qwerty123
                    Role = Role.Admin
                },
                new()
                {
                    Id = Guid.Parse("5edbb0fe-7263-4f75-bad8-c9f3d422dd1d"),
                    Name = "Bob",
                    PhoneNumber = "123456789012",
                    EmailAddress = "tastBobRichard@gmail.com",
                    PasswordHash = "$2a$12$LxSqe5AE7AtglesHHK5NROFdJQdA1r1XKqhzg4q/tMTZjVEH0PNSK", //asdf1234
                    Role = Role.User
                },
                new()
                {
                    Id = Guid.Parse("6357D344-CB69-4FAA-81C5-AC0FC59AE0F9"),
                    Name = "Funk",
                    PhoneNumber = "123456789012",
                    EmailAddress = "sarah.funk@gmail.com",
                    PasswordHash = "$2a$12$LxSqe5AE7AtglesHHK5NROFdJQdA1r1XKqhzg4q/tMTZjVEH0PNSK", //asdf1234
                    Role = Role.Manager
                }
            };

            await dbContext.Users.AddRangeAsync(clients);
            await dbContext.SaveChangesAsync();
        }
    
}