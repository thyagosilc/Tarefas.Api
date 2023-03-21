using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Tarefas.Business.Models;

namespace Tarefas.Api.ViewModels
{
    public class TarefaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DataType(DataType.DateTime)]
        public string Data { get; set; }
        public int Status { get; set; }
    }
}
