
using BluServs.Infra.Models;
namespace BluServs.Models.Repository.Interfaces

{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>> Listar();
        Task<Agendamento> BuscarPorId(int id);
        Task<Agendamento> Salvar(Agendamento agendamento);
        Task<bool> Excluir(int id);
        Task<List<Agendamento>> ListarPorUsuarioId(int usuarioId);
        Task<List<Agendamento>> ListarPorServicoId(int servicoId);
    }
}
