﻿
using Domain.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.UseCases.PersonalInformations.Commands.CreatePersonalInformation
{
    public class CreatePersonalInformationCommandHandler : IRequestHandler<CreatePersonalInformationCommand, Response<PersonalInformation>>
    {
        private readonly PersonalInformationService _service;

        public CreatePersonalInformationCommandHandler(PersonalInformationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


      public async  Task<Response<PersonalInformation>> Handle(CreatePersonalInformationCommand request, CancellationToken cancellationToken)
        {
            var personalInformation = new PersonalInformation
            (
                request.tipoDocumento,
                request.documento,
                request.nombre1,
                request.nombre2,
                request.apellido1,
                request.apellido2,
                request.fechaNacimiento,
                request.sexo
            );

            //if (supplierSearcherd.Any())
            //{
            //    throw new EntityExistingException($"Este Nit: {request.Nit} Ya esta registrado");
            //}

            await _service.CreatePersonalInformation(personalInformation);

            return new Response<PersonalInformation>(personalInformation);
        }
    }
}
