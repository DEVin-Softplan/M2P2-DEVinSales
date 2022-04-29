using DevInSales.Freight.Data.Context;
using DevInSales.Freight.Data.Interfaces;
using DevInSales.Freight.Data.Models;

namespace DevInSales.Freight.Data.Repositories
{
    public class StatePriceRepository : Repository<StatePriceModel>, IStatePriceRepository
    {
        public StatePriceRepository(FreightContext context) : base(context)
        {
        }
    }
}
