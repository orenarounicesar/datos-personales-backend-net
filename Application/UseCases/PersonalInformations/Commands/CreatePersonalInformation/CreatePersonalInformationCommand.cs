using Domain.Entities;
using Domain.Exceptions;

namespace Application.UseCases.PersonalInformations.Commands.CreatePersonalInformation
{
    public record CreatePersonalInformationCommand(string tipoDocumento, string documento, string nombre1,
        string nombre2, string apellido1, string apellido2, DateTime fechaNacimiento, string sexo) : IRequest<Response<PersonalInformation>>;
}
