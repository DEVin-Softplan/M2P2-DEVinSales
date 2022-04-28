using DevInSales.Freight.Data.Models;
using System.Linq.Expressions;

namespace DevInSales.Freight.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        void Registrar(TEntity entity);
        TEntity ObterPorId(int id);
        void Atualizar(TEntity entity, string[] noUpdate = null);
        void Remover(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int Commit();
    }
}
