﻿using DevInSales.Context;
using DevInSales.Interfaces;
using DevInSales.Models;

namespace DevInSales.Repositories
{
    public class StateRepository : Repository<StateModel>, IStateRepository
    {
        public StateRepository(SqlContext context) : base(context)
        {
        }
    }
}
