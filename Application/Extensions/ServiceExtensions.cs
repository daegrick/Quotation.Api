using Microsoft.Extensions.DependencyInjection;
using Quotation.Application.Interface.Service;
using Quotation.Application.Service;

namespace Quotation.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}
