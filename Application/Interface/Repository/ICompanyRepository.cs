using Quotation.Domain.Entity;

namespace Quotation.Application.Interface.Repository
{
    public interface ICompanyRepository
    {
        Task<Company> Get(Guid uid);
        Task<int> Save(Company company);
    }
}
