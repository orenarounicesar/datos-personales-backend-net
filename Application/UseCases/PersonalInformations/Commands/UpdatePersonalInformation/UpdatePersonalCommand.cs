using Domain.Exceptions;

namespace Application.UseCases.PersonalInformations.Commands.UpdatePersonalInformation
{
    public record UpdatePersonalCommand(string Id, string Document, string FirstName, string SecondName, string LastName, string SecondLastName, DateTime BirthDate,
        string Sex) : IRequest<Response<string>>;
}
