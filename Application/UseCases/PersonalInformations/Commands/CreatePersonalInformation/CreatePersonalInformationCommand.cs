using Domain.Entities;

namespace Application.UseCases.PersonalInformations.Commands.CreatePersonalInformation
{
    public record CreatePersonalInformationCommand(string tipoDocumento, string documento, string nombre1,
        string nombre2, string apellido1, string apellido2, DateTime fechaNacimiento, string sexo) : IRequest<PersonalInformation>;
}
