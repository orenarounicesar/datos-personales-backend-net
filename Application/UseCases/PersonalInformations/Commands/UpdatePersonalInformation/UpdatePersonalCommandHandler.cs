using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Application.UseCases.PersonalInformations.Commands.UpdatePersonalInformation
{
    public class UpdatePersonalCommandHandler : IRequestHandler<UpdatePersonalCommand, Response<string>>
    {
        private readonly PersonalInformationService personalInformationService;

        public UpdatePersonalCommandHandler(PersonalInformationService personalInformationService)
        {
            this.personalInformationService = personalInformationService;
        }

        public async Task<Response<string>> Handle(UpdatePersonalCommand request, CancellationToken cancellationToken)
        {
            var personalSearched = await personalInformationService.GetPersonalInformationById(request.Id);
            _ = personalSearched ?? throw new ArgumentNullException(nameof(personalSearched));
            personalSearched.tipoDocumento = request.tipoDocumento;
            personalSearched.fechaNacimiento = request.fechaNacimiento;
            personalSearched.nombre1 = request.nombre1;
            personalSearched.nombre2 = request.nombre2;
            personalSearched.apellido1 = request.apellido1;
            personalSearched.apellido2 = request.apellido2;
            personalSearched.sexo = request.sexo;
            personalSearched.documento = request.documento;

            await personalInformationService.UpdatePersonalInformation(personalSearched);
            var response = new Response<string>(personalSearched.Id);
            return response;
        }
    }
}
