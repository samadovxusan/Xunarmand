using Xunarmand.Domain.Common.Entities;

namespace Xunarmand.Domain.Entities
{
    /// <summary>
    /// Represents an order entity in the system, inheriting auditable properties from the AuditableEntity base class.
    /// </summary>
    public class Order : AuditableEntity
    {
        /// <summary>
        /// The total price of the order.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The quantity of products in the order.
        /// </summary>
        public int ProductAmount { get; set; }

        /// <summary>
        /// The ID of the user who placed the order.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the user who placed the order.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// The date and time when the order was placed.
        /// </summary>
        public DateTimeOffset OrderDate { get; set; }

        /// <summary>
        /// Collection of products associated with the order.
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
    }
}