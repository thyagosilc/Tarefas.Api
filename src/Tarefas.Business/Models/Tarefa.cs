namespace Tarefas.Business.Models
{
    public class Tarefa : Entity
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }
    }
}
