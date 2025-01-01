using Quotation.Application.Interface.Repository;
using Quotation.Application.Interface.Service;
using Quotation.Domain.Entity;

namespace Quotation.Application.Service
{
    public class CompanyService(ICompanyRepository repository) : ICompanyService
    {
        public async Task<Company> Get(Guid uid) => await repository.Get(uid);

        public async Task<int> Save(Company company)
        {
            IsValidSave(company);
            company.LastModified = DateTime.UtcNow;
            return await repository.Save(company);
        }

        private static void IsValidSave(Company company)
        {
            if (company.Uid == Guid.Empty)
                throw new ArgumentException(nameof(company.Uid));
        }
    }
}
