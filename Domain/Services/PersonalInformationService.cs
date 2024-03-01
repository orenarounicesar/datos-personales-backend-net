using Domain.Entities;
using Domain.Ports;

namespace Domain.Services;

public class PersonalInformationService
{
    private readonly IGenericRepository<PersonalInformation> _personalInformationRepository;

    public PersonalInformationService(IGenericRepository<PersonalInformation> personalInformationRepository)
    {
        _personalInformationRepository = personalInformationRepository;
    }

    public async Task CreateSupplier(PersonalInformation supplier)
    {
        await _personalInformationRepository.Add(supplier);
    }

    public async Task DeleteSupplier(PersonalInformation supplier)
    {
        await _personalInformationRepository.Delete(supplier);
    }
}