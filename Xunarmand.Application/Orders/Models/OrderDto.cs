using Xunarmand.Domain.Enums;

namespace Xunarmand.Application.Orders.Models;

public class OrderDto
{
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public ProductStatus Status { get; set; }

    public decimal Price { get; set; }

    public int Amount { get; set; }
}