using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tarefas.Business.Models;
using Tarefas.Business.Repository;
using Tarefas.Data.Context;

namespace Tarefas.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly DbContextApp Db;
        protected readonly DbSet<TEntity> DbSetContext;

        public Repository(DbContextApp db)
        {
            Db = db;
            DbSetContext = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
           var result = await DbSetContext.AsNoTracking().Where(predicate).ToListAsync();
            return result;
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
           var result = await DbSetContext.FindAsync(id);
            return result;
        }

        public virtual Task<List<TEntity>> ObterTodos()
        {
            return DbSetContext.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entidade)
        {
            DbSetContext.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entidade)
        {
            DbSetContext.Update(entidade);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSetContext.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
