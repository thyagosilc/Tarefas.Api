using Tarefas.Business.Interfaces;
using Tarefas.Business.Models;
using Tarefas.Business.Models.Validation;
using Tarefas.Business.RabitMQ;

namespace Tarefas.Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IRabitMQConsumer _rabitMQConsumer;

        public TarefaService(ITarefaRepository tarefaRepository, INotificador notificador, IRabitMQConsumer rabitMQConsumer) : base(notificador)
        {
            _tarefaRepository = tarefaRepository;
            _rabitMQConsumer = rabitMQConsumer;
        }

        public async Task<bool> Adicionar()
        {
            var tarefa = await _rabitMQConsumer.GetMessageAdicionarTarefa();

            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return false;

            await _tarefaRepository.Adicionar(tarefa);

            return true;
        }

        public async Task<bool> Atualizar()
        {
            var tarefa = await _rabitMQConsumer.GetMessageAtualizarTarefa();

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
