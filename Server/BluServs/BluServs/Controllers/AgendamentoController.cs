using BluServs.Infra.Models;
using BluServs.Models.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AgendamentoController : ControllerBase
{
    private readonly AgendamentoRepository _agendamentoRepository;

    public AgendamentoController(AgendamentoRepository agendamentoRepository)
    {
        _agendamentoRepository = agendamentoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Agendamento>>> Get()
    {
        try
        {
            var agendamentos = await _agendamentoRepository.Listar();
            return Ok(agendamentos);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Agendamento>> Post([FromBody] Agendamento agendamento)
    {
        try
        {
            var agendamentoSalvo = await _agendamentoRepository.Salvar(agendamento);
            return CreatedAtAction(nameof(Get), new { id = agendamentoSalvo.Id }, agendamentoSalvo);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        try
        {
            var agendamentoExcluido = await _agendamentoRepository.Excluir(id);
            if (agendamentoExcluido)
            {
                return Ok(new { mensagem = "Agendamento excluído com sucesso." });
            }
            else
            {
                return NotFound(new { mensagem = "Agendamento não encontrado." });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }
}
