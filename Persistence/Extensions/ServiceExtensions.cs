using Microsoft.Extensions.DependencyInjection;
using Quotation.Application.Interface.Repository;
using Quotation.Persistence.Database;
using Quotation.Persistence.Repository;

namespace Quotation.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services)
        {
            services.AddScoped<IDbUtil, DbUtil>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
