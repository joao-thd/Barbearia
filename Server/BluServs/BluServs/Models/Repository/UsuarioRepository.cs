using BluServs.Infra.Data;
using BluServs.Controllers.Objects;
using BluServs.Models;
using Microsoft.EntityFrameworkCore;

namespace BluServs.Models.Repository
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        
        public async Task<List<Usuario>> Listar()
        {
            return await _appDbContext.Usuarios.ToListAsync();
        }

        
        public async Task<Usuario> Login(LoginRequest loginRequest)
        {
            var usuario = await _appDbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Senha == loginRequest.Senha);


            if (usuario == null)
            {
                throw new Exception("Usuário ou senha inválidos.");
            }

            return usuario;
        }

        
        public async Task<Usuario> BuscarPorID(int id)
        {
            var usuario = await _appDbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            return usuario;
        }

 
        public async Task<Usuario> Salvar(Usuario usuario)
        {
            try
            {
                if (usuario.Id > 0)
                {
                    var usuarioEditar = await _appDbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);

                    if (usuarioEditar == null)
                    {
                        throw new Exception("Usuário não encontrado para edição.");
                    }

                    usuarioEditar.Nome = usuario.Nome;
                    usuarioEditar.Email = usuario.Email;
                    usuarioEditar.Senha = usuario.Senha;
                }
                else
                {
                    _appDbContext.Usuarios.Add(usuario);
                }

                await _appDbContext.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                var usuarioExcluir = await _appDbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                if (usuarioExcluir == null)
                {
                    throw new Exception("Usuário não encontrado para exclusão.");
                }

                _appDbContext.Usuarios.Remove(usuarioExcluir);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
