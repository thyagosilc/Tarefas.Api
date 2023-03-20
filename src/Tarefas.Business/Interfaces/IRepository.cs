using System.Linq.Expressions;
using Tarefas.Business.Models;

namespace Tarefas.Business.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Adicionar(TEntity entidade);
        Task Atualizar(TEntity entidade);
        Task Remover(Guid id);
        Task<int> SaveChanges();
    }
}
