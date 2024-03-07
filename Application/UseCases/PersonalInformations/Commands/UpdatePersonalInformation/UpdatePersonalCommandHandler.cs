using Domain.Exceptions;

namespace Application.UseCases.PersonalInformations.Commands.UpdatePersonalInformation
{
    public class UpdatePersonalCommandHandler : IRequestHandler<UpdatePersonalCommand, Response<string>>
    {

        public Task<Response<string>> Handle(UpdatePersonalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
