using Application.UseCases.PersonalInformations.Commands.CreatePersonalInformation;
using Application.UseCases.PersonalInformations.Commands.DeletePersonalInformation;
using Application.UseCases.PersonalInformations.Commands.UpdatePersonalInformation;
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

    [HttpPost]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreatePersonalInformationCommand command) => Ok(await _mediator.Send(command));



    [HttpDelete("{id}")]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Response<string>>> Delete(string id)
    {
        return await _mediator.Send(new DeletePersonalInformationCommand(id));
    }

    //metodo put
    [HttpPut("{id}")]
  
    public async Task<IActionResult> Update(UpdatePersonalCommand command, string id)
    {
        

        return Ok(await _mediator.Send(command));
    }



}