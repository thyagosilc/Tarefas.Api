using Tarefas.Business.Interfaces;
using Tarefas.Business.Models;
using Tarefas.Business.Models.Validation;

namespace Tarefas.Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository, INotificador notificador) : base(notificador)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<bool> Adicionar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return false;

            await _tarefaRepository.Adicionar(tarefa);
            return true;
        }

        public async Task<bool> Atualizar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return false;

            await _tarefaRepository.Atualizar(tarefa);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _tarefaRepository.Remover(id);
            return true;
        }

       public async Task<Tarefa> ObterTarefaPorId(Guid id)
        {
            return await _tarefaRepository.ObterTarefaPorId(id);
        }

        public void Dispose()
        {
            _tarefaRepository?.Dispose();
        }


    }
}
