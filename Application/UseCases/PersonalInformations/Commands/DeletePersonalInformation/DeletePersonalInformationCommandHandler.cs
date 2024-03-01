using Domain.Exceptions;
using Domain.Services;

namespace Application.UseCases.PersonalInformations.Commands.DeletePersonalInformation
{
    public class DeletePersonalInformationCommandHandler : IRequestHandler<DeletePersonalInformationCommand, Response<Unit>>
    {
        private readonly PersonalInformationService _service;

        public DeletePersonalInformationCommandHandler(PersonalInformationService service)
        {
            _service = service;
        }

        public async Task<Response<Unit>> Handle(DeletePersonalInformationCommand request, CancellationToken cancellationToken)
        {
            var personalSearched = await _service.GetByIdSupplier(request.Id);
            if (personalSearched != null)
            {
                throw new Exception();
            }
            await _service.DeleteSupplier(personalSearched);
            var response = new Response<Unit>();
            return response;

        }
    }
}
