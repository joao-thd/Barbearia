using BluServs.Models;
using BluServs.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BluServs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Listar()
        {
            var usuarios = await _usuarioRepository.Listar();
            return Ok(usuarios);
        }

        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarPorID(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Criar([FromBody] Usuario usuario)
        {
            try
            {
                var novoUsuario = await _usuarioRepository.Salvar(usuario);
                return CreatedAtAction(nameof(BuscarPorId), new { id = novoUsuario.Id }, novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar(int id, [FromBody] Usuario usuario)
        {
            try
            {
                usuario.Id = id; 
                var usuarioAtualizado = await _usuarioRepository.Salvar(usuario);
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            try
            {
                await _usuarioRepository.Excluir(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario loginData)
        {
            var usuarios = await _usuarioRepository.Listar();
            var usuario = usuarios.FirstOrDefault(u => u.Email == loginData.Email && u.Senha == loginData.Senha);

            if (usuario == null)
            {
                return Unauthorized(new { mensagem = "Email ou senha inválidos." });
            }

            return Ok(usuario);
        }

    }
}
