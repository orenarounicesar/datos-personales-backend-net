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

 
}