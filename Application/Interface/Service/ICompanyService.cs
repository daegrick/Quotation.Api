using Quotation.Domain.Entity;

namespace Quotation.Application.Interface.Service
{
    public interface ICompanyService
    {
        Task<Company> Get(Guid uid);
        Task<int> Save(Company company);
    }
}
