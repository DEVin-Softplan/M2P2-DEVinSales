using DevInSales.Context;
using DevInSales.Interfaces;
using DevInSales.Models;

namespace DevInSales.Repositories
{
    public class PriceRepository : Repository<StateModel>, IStateRepository
    {
        public PriceRepository(SqlContext context) : base(context)
        {
        }
    }
}
