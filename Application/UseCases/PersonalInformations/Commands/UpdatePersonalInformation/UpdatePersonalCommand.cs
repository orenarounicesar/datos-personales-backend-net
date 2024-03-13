using Domain.Exceptions;

namespace Application.UseCases.PersonalInformations.Commands.UpdatePersonalInformation
{
    public record UpdatePersonalCommand(string Id, string tipoDocumento, string documento, string nombre1,
        string nombre2, string apellido1, string apellido2, DateTime fechaNacimiento, string sexo) : IRequest<Response<string>>;
}
