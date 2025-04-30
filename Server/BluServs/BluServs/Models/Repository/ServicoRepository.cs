using BluServs.Models.Repository.Interfaces;  
using BluServs.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BluServs.Models.Repository
{
    public class ServicoRepository : IServicoRepository  
    {
        private readonly AppDbContext _appDbContext;

        public ServicoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Servico>> Listar()
        {
            return await _appDbContext.Servicos.ToListAsync();
        }

        public async Task<Servico> BuscarPorId(int id)
        {
            var servico = await _appDbContext.Servicos
                .Include(s => s.Agendamentos)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servico == null)
            {
                throw new Exception("Serviço não encontrado.");
            }

            return servico;
        }

        public async Task<Servico> Salvar(Servico servico)
        {
            try
            {
                if (servico.Id > 0)
                {
                    var servicoEditar = await _appDbContext.Servicos
                        .FirstOrDefaultAsync(s => s.Id == servico.Id);

                    if (servicoEditar == null)
                    {
                        throw new Exception("Serviço não encontrado para edição.");
                    }

                    servicoEditar.Nome = servico.Nome;
                    servicoEditar.Preco = servico.Preco;
                    servicoEditar.Duracao = servico.Duracao;
                }
                else
                {
                    _appDbContext.Servicos.Add(servico);
                }

                await _appDbContext.SaveChangesAsync();
                return servico;
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
                var servicoExcluir = await _appDbContext.Servicos
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (servicoExcluir == null)
                {
                    throw new Exception("Serviço não encontrado para exclusão.");
                }

                _appDbContext.Servicos.Remove(servicoExcluir);
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
