using DevInSales.Freight.Data.Context;
using DevInSales.Freight.Data.Interfaces;
using DevInSales.Freight.Data.Repositories;

namespace DevInSales.Config
{
    public static class InjectorDependecyConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {

            services.AddScoped<IShippingCompanyRepository, ShippingCompanyRepository>();
            services.AddScoped<FreightContext>();
        }
    }
}
