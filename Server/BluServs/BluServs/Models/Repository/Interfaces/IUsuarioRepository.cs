using BluServs.Controllers.Objects;

namespace BluServs.Models.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Listar();
        Task<Usuario> Login(LoginRequest loginRequest);
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Salvar(Usuario usuario);
        Task<bool> Excluir(int id);
    }
}
