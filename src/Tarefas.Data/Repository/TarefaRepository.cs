using Microsoft.EntityFrameworkCore;
using Tarefas.Business.Interfaces;
using Tarefas.Business.Models;
using Tarefas.Data.Context;

namespace Tarefas.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(DbContextApp db) : base(db)
        {
        }

        public async Task<Tarefa> ObterTarefaPorId(Guid id)
        {
            var result = await Db.Tarefas.AsNoTracking() .FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }
    }
}
