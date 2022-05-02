using DevInSales.Models;
using System.Linq.Expressions;

namespace DevInSales.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        void Registrar(TEntity entity);
        void RegistrarLista(IList<TEntity> entitys);
        TEntity ObterPorId(int id);
        void Atualizar(TEntity entity, string[] noUpdate = null);
        void Remover(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int Commit();
    }
}
