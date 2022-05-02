using DevInSales.Context;
using DevInSales.Interfaces;
using DevInSales.Models;

namespace DevInSales.Repositories
{
    public class StatePriceRepository : Repository<StatePrice>, IStatePriceRepository
    {
        public StatePriceRepository(SqlContext context) : base(context)
        {
        }
    }
}
