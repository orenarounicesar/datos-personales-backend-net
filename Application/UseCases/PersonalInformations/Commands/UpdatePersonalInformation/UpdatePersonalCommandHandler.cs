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
            personalSearched.Update(request.Document, request.FirstName, request.SecondName, request.LastName, request.SecondLastName);
            await personalInformationService.UpdatePersonalInformation(personalSearched);
            var response = new Response<string>(personalSearched.Id);
            return response;
        }
    }
}
