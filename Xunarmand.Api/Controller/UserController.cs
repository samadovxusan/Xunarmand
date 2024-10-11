using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xunarmand.Application.Users.Commands;
using Xunarmand.Application.Users.Queries;

namespace Xunarmand.Api.Controller;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IMediator mediator): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserGetQuery userGetQuery,CancellationToken cancellationToken)
    {
        var result = await mediator.Send(userGetQuery,cancellationToken);
        return Ok(result);
    }
    [HttpGet("{clientId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid clientId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UserGetByIdQuery(){Id = clientId}, cancellationToken);
        return result is not null ? Ok(result) : NoContent();
    }

    [HttpGet("by-email/{emailAddress}")]
    public async ValueTask<IActionResult> CheckClientByEmail([FromRoute] string emailAddress, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CheckUserByEmailAddressQuery() { EmailAddress = emailAddress }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }
    
    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] UserUpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{clientId:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid clientId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UserDeleteByIdCommand() {UserId = clientId}, cancellationToken);
        return result ? Ok() : BadRequest();
    }
 
}