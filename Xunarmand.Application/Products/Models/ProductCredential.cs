using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Xunarmand.Domain.Enums;

namespace Xunarmand.Application.Products.Models;

public class ProductCredential
{
    public string? ProductName { get; set; }

    /// <summary>
    /// Gets or sets the type of the product.
    /// </summary>
    public ProductType? ProductType { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the URL of the product image.
    /// </summary>
    /// 
    public IFormFile ImageUrl { get; set; }
    public string ImageUrlPath { get; set; }
    
}