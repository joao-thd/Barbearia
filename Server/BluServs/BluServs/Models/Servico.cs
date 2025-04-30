using BluServs.Infra.Models;

namespace BluServs.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Duracao { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}

