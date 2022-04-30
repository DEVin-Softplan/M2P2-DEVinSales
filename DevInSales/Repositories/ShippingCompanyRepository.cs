
using DevInSales.Context;
using DevInSales.Interfaces;
using DevInSales.Models;

namespace DevInSales.Repositories
{
    public class ShippingCompanyRepository : Repository<ShippingCompany>, IShippingCompanyRepository
    {
        public ShippingCompanyRepository(SqlContext context) : base(context)
        {
        }
    }
}
