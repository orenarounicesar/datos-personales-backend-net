using Domain.Entities;
using Domain.Exceptions;

namespace Application.UseCases.PersonalInformations.Commands.DeletePersonalInformation
{
    public record DeletePersonalInformationCommand(string Id) : IRequest<Response<Unit>>;
}
