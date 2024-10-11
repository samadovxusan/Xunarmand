using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(user => user.Name).HasMaxLength(64);
        builder.Property(user => user.EmailAddress).HasMaxLength(128).IsRequired();
        builder.Property(user => user.PasswordHash).HasMaxLength(128).IsRequired();
        builder.Property(user => user.PhoneNumber).HasMaxLength(15);
    }
}