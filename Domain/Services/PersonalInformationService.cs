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

    public async Task<PersonalInformation> GetByIdSupplier(string Id)
    {
       return await _personalInformationRepository.GetById(Id);
    }

    public async Task DeleteSupplier(PersonalInformation supplier)
    {
       
        await _personalInformationRepository.Delete(supplier);
    }
    public async Task UpdateSupplier(string Id, PersonalInformation supplier)
    {
        var idSearched = await _personalInformationRepository.FindAsync(x => x.Id == Id);
        if (idSearched != null)
        {
            throw new Exception();
        }
        await _personalInformationRepository.Update(supplier);
    }
}