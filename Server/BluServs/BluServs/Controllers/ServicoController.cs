using BluServs.Models.Repository.Interfaces;
using BluServs.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ServicoController : ControllerBase
{
    private readonly IServicoRepository _repository;

    public ServicoController(IServicoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetServicos()
    {
        try
        {
            var servicos = _repository.Listar().Result;
            return Ok(servicos);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { mensagem = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Salvar(Servico servico)
    {
        try
        {
            var servicoSalvo = _repository.Salvar(servico).Result;
            return Ok(servicoSalvo);
        }
        catch (Exception ex)
        {
            return ValidationProblem(new ValidationProblemDetails() { Detail = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        try
        {
            var servicoExcluido = _repository.Excluir(id).Result;
            if (servicoExcluido)
            {
                return Ok(new { mensagem = "Serviço excluído com sucesso." });
            }
            else
            {
                return NotFound(new { mensagem = "Serviço não encontrado para exclusão." });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }
}
