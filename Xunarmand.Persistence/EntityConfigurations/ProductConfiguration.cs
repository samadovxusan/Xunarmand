using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(product => product.ProductName).HasMaxLength(64).IsRequired();
        builder.Property(product => product.Description).HasMaxLength(256);
        builder.Property(product => product.ImageUrl).HasMaxLength(256);
        builder.Property(product => product.Price).HasColumnType("decimal(18,2)").IsRequired();
    }
}