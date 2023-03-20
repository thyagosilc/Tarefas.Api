using AutoMapper;
using Tarefas.Api.ViewModels;
using Tarefas.Business.Models;

namespace Tarefas.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
        }
    }
}
