using DevInSales.Freight.Data.Context;
using DevInSales.Freight.Data.Interfaces;
using DevInSales.Freight.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevInSales.Freight.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected FreightContext Context;
        protected DbSet<TEntity> DbSet;

        protected Repository(FreightContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Registrar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(TEntity entity, string[] noUpdate = null)
        {
            if (noUpdate != null)
            {
                var entry = Context.Entry(entity);
                foreach (var name in noUpdate)
                {
                    entry.Property(name).IsModified = false;
                }
            }
            DbSet.Update(entity);
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
        public int Commit()
        {
            return Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
