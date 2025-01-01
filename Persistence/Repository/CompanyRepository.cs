using Dapper;
using Quotation.Application.Interface.Repository;
using Quotation.Domain.Entity;
using Quotation.Persistence.Database;

namespace Quotation.Persistence.Repository
{
    public class CompanyRepository(IDbUtil db) : ICompanyRepository
    {
        public async Task<Company> Get(Guid uid)
        {
            db.GetConnection().Open();
            var select = new SelectBuilder()
                .Select()
                .AllFields()
                .AddFrom(table: nameof(Company))
                .AddWhere()
                .AddValue(nameof(Company.Uid), uid);
            return await db.GetConnection().QuerySingleAsync<Company>(select.ToString(), select.Parameters) ?? new Company();
        }

        public async Task<int> Save(Company company)
        {
            db.GetConnection().Open();
            var upsert = new UpsertBuilder(nameof(Company), [nameof(company.Uid)])
                .InsertField(nameof(Company.Uid), company.Uid)
                .InsertField(nameof(Company.Name), company.Name)
                .InsertField(nameof(company.LastModified), company.LastModified ?? default)
                .InsertField(nameof(company.Status), company.Status);
            return await db.Save(upsert.ToString(), upsert.Parameters);
        }
    }
}
