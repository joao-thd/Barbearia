using BluServs.Infra.Data;
using BluServs.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace BluServs.Models.Repository
{
    public class AgendamentoRepository
    {
        private readonly AppDbContext _appDbContext;

        public AgendamentoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

     
        public async Task<List<Agendamento>> Listar()
        {
            return await _appDbContext.Agendamentos
                .Include(a => a.Usuario)
                .Include(a => a.Servico)
                .ToListAsync();
        }

      
        public async Task<Agendamento> BuscarPorID(int id)
        {
            var agendamento = await _appDbContext.Agendamentos
                .Include(a => a.Usuario)
                .Include(a => a.Servico)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (agendamento == null)
            {
                throw new Exception("Agendamento não encontrado.");
            }

            return agendamento;
        }

 
        public async Task<Agendamento> Salvar(Agendamento agendamento)
        {
            try
            {
                if (agendamento.Id > 0)
                {
                    var agendamentoEditar = await _appDbContext.Agendamentos.FirstOrDefaultAsync(a => a.Id == agendamento.Id);

                    if (agendamentoEditar == null)
                    {
                        throw new Exception("Agendamento não encontrado para edição.");
                    }

                    agendamentoEditar.DataHora = agendamento.DataHora;
                    agendamentoEditar.UsuarioId = agendamento.UsuarioId;
                    agendamentoEditar.ServicoId = agendamento.ServicoId;
                }
                else
                {
                    _appDbContext.Agendamentos.Add(agendamento);
                }

                await _appDbContext.SaveChangesAsync();
                return agendamento;
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
                var agendamentoExcluir = await _appDbContext.Agendamentos.FirstOrDefaultAsync(a => a.Id == id);

                if (agendamentoExcluir == null)
                {
                    throw new Exception("Agendamento não encontrado para exclusão.");
                }

                _appDbContext.Agendamentos.Remove(agendamentoExcluir);
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
