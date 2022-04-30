
using DevInSales.Context;
using DevInSales.Interfaces;
using DevInSales.Repositories;

namespace DevInSales.Config
{
    public static class InjectorDependecyConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {

            services.AddScoped<IShippingCompanyRepository, ShippingCompanyRepository>();
            services.AddScoped<IStatePriceRepository, StatePriceRepository>();
            services.AddScoped<SqlContext>();
        }
    }
}
