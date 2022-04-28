using DevInSales.Freight.Data.Context;
using DevInSales.Freight.Data.Interfaces;
using DevInSales.Freight.Data.Models;

namespace DevInSales.Freight.Data.Repositories
{
    public class ShippingCompanyRepository : Repository<ShippingCompanyModel>, IShippingCompanyRepository
    {
        public ShippingCompanyRepository(FreightContext context) : base(context)
        {
        }
    }
}
