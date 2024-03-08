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
            await personalInformationService.DeletePersonalInformation(request.Id);
            var response = new Response<string>("Se elimino correctamente");
            return response;
        }
    }
}
