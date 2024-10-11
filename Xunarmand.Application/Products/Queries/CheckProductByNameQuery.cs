using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Application.Products.Queries;

public class CheckProductByNameQuery : IQuery<string>
{
    public string ProductName { get; set; }
}