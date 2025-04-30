using BluServs.Models;

namespace BluServs.Infra.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
