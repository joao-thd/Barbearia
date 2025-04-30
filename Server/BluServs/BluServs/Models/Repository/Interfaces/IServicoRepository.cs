namespace BluServs.Models.Repository.Interfaces
{
    public interface IServicoRepository
    {
        Task<List<Servico>> Listar();
        Task<Servico> BuscarPorId(int id);
        Task<Servico> Salvar(Servico servico);
        Task<bool> Excluir(int id);
    }
}
