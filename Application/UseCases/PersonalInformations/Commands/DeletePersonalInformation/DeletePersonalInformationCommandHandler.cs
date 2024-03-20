using Application.Common.Exceptions;
using Domain.Exceptions;
using Domain.Services;

namespace Application.UseCases.PersonalInformations.Commands.DeletePersonalInformation
{
    public class DeletePersonalInformationCommandHandler : IRequestHandler<DeletePersonalInformationCommand, Response<string>>
    {
        private readonly PersonalInformationService personalInformationService;

        public DeletePersonalInformationCommandHandler(PersonalInformationService personalInformationService)
        {
            this.personalInformationService = personalInformationService;
        }

        public async Task<Response<string>> Handle(DeletePersonalInformationCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var personalSearched = await personalInformationService.GetPersonalInformationById(request.Id);
            _ = personalSearched ?? throw new CustomException("Error al borrar");

            await personalInformationService.DeletePersonalInformation(request.Id);
            var response = new Response<string>("Se elimino correctamente");
            return response;
        }
    }
}
