using AutoMapper;
using Lorby.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Xunarmand.Application.Products.Commands;
using Xunarmand.Application.Products.Models;
using Xunarmand.Application.Products.Queries;
using Xunarmand.Application.Products.Service;
using Xunarmand.Application.Users.Commands;
using Xunarmand.Domain.Entities;

namespace Xunarmand.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController(
    IMediator mediator,
    IMapper mapper,
    IWebHostEnvironment webHostEnvironment,
    IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductGetQuery productGetQuery,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(productGetQuery, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{clientId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid clientId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new ProductGetByIdQuery() { ProductId = clientId }, cancellationToken);
        return result is not null ? Ok(result) : NoContent();
    }

    [HttpGet("by-name/{ProductName}")]
    public async Task<ActionResult<string>> CheckClientByName([FromRoute] string productName,
        CancellationToken cancellationToken)
    {
        var result =
            await mediator.Send(new CheckProductByNameQuery() { ProductName = productName }, cancellationToken);

        return result;
    }

    [HttpPost("Product")]
    public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommand productCreateCommand,
        CancellationToken cancellationToken)
    {
     
        var result = await mediator.Send(productCreateCommand, cancellationToken);

        return Ok(result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{productid:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid productid, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteProductByIdCommand() { ProductId = productid }, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}