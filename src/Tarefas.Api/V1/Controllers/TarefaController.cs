using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Api.Controllers;
using Tarefas.Api.ViewModels;
using Tarefas.Business.Interfaces;
using Tarefas.Business.Models;

namespace Tarefas.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/tarefas")]
    public class TarefaController : MainController
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        private readonly ITarefaService _tarefaService;

        private readonly ILogger<TarefaController> _logger;

        public TarefaController(
            INotificador notificador,
            IMapper mapper,
            ITarefaRepository tarefaRepository,
            ITarefaService tarefaService,
            ILogger<TarefaController> logger) : base(notificador)
        {

            _mapper = mapper;
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TarefaViewModel>> ObterTodos()
        {
            _logger.LogTrace("Chamando o endpoint ObterTodos");
            _logger.LogTrace("chamando o serviço para listar todos os dados");
            var tarefaViewModel = _mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterTodos());

            _logger.LogTrace("Finalizando chamada do endpoint ObterTodos");
            return tarefaViewModel;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TarefaViewModel>> ObterPorId(Guid id)
        {
            _logger.LogTrace("Chamando o endpoint ObterPorId");
            _logger.LogTrace("chamando o serviço para listar tarefas por id");
            var tarefaViewModel = _mapper.Map<TarefaViewModel>(await _tarefaRepository.ObterPorId(id));
            _logger.LogTrace("Finalizando chamada do endpoint ObterPorId");
            return tarefaViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<TarefaViewModel>> Adicionar(TarefaViewModel tarefaViewModel)
        {
            _logger.LogTrace("Chamando o endpoint Adicionar");
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _logger.LogTrace("chamando o serviço para adicionar uma nova tarefa");
            await _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefaViewModel));

            _logger.LogTrace("Finalizando chamada do endpoint Adicionar");
            return CustomResponse(tarefaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TarefaViewModel>> Atualizar(Guid id, TarefaViewModel fornecedorViewModel)
        {
            _logger.LogTrace("Chamando o endpoint Atualizar");

            if (id != fornecedorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(fornecedorViewModel);
            }

            _logger.LogTrace("chamando o serviço para atualizar a tarefa");
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tarefaService.Atualizar(_mapper.Map<Tarefa>(fornecedorViewModel));

            _logger.LogTrace("Finalizando chamada do endpoint Atualizar");
            return CustomResponse(fornecedorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TarefaViewModel>> Excluir(Guid id)
        {
            _logger.LogTrace("Chamando o endpoint Excluir");
            var tarefaViewModel = await ObterTarefaPorId(id);

            if (tarefaViewModel == null)
                return NotFound();

            _logger.LogTrace("chamando o serviço para excluir a tarefa");
            await _tarefaService.Remover(id);

            _logger.LogTrace("Finalizando chamada do endpoint Excluir");
            return CustomResponse(tarefaViewModel);
        }

        private async Task<TarefaViewModel> ObterTarefaPorId(Guid id)
        {
            return _mapper.Map<TarefaViewModel>(await _tarefaService.ObterTarefaPorId(id));
        }
    }
}
