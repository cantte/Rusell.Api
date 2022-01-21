using Rusell.BankDrafts.Companies.Domain;

namespace Rusell.BankDrafts.Companies.Application.Create;

public class CompanyCreator
{
    private readonly ICompaniesRepository _repository;

    public CompanyCreator(ICompaniesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CompanyId id, CompanyName name)
    {
        var company = new Company(id, name);
        await _repository.Save(company);
    }
}
