using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PersonalInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonalInformationController(IMediator mediator) => _mediator = mediator;





    [HttpDelete("{id}")]
    [Authorize]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(string id) => Ok(await _mediator.Send(new DeletePersonalInformationCommand(id)));


}