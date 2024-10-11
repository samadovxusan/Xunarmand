using Xunarmand.Application.Products.Models;
using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Application.Products.Queries;

public class ProductGetQuery : IQuery<ICollection<ProductDto>>
{
    public ProductFilter Filter { get; set; }
}