using System.Linq.Expressions;
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

    public async Task CreatePersonalInformation(PersonalInformation personalInformation)
    {
        await _personalInformationRepository.Add(personalInformation);
    }

    public async Task DeletePersonalInformation(string Id)
    {
        await _personalInformationRepository.Delete(Id);
    }

    public async Task<PersonalInformation> GetPersonalInformationById(string personalInformationId)
    {
        return await _personalInformationRepository.GetById(personalInformationId);
    }

    public async Task<IEnumerable<PersonalInformation>> Find(Expression<Func<PersonalInformation, bool>> filter)
    {
        return await _personalInformationRepository.FindAsync(filter);
    }

    public async Task UpdatePersonalInformation
    (
        PersonalInformation personal
    )
    {

        await _personalInformationRepository.Update(personal);
    }
}