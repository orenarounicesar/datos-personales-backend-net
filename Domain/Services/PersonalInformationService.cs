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

    public async Task DeletePersonalInformation(PersonalInformation personalInformation)
    {
        await _personalInformationRepository.Delete(personalInformation);
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
        string personalInformationId,
        string documentType,
        string document,
        string firstName,
        string secondName,
        string lastName,
        string secondLastName
    )
    {
        var personalInformationSearched = await _personalInformationRepository.GetById(personalInformationId);
        personalInformationSearched.Update(documentType, document, firstName, secondName, lastName, secondLastName);
        await _personalInformationRepository.Update(personalInformationSearched);
    }
}