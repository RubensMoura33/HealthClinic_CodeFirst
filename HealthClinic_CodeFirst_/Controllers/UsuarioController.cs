using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using HealthClinic_CodeFirst_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_CodeFirst_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository? _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
               
                return Ok( _usuarioRepository!.BuscarPorId(id));

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id) 
        
        {
            try
            {
                _usuarioRepository?.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]

        public IActionResult Post (Usuario usuario) 
        {
            try
            {
                _usuarioRepository!.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut]
        public IActionResult Put (Guid id, Usuario usuario)

        {
            try
            {
                _usuarioRepository!.Atualizar(id, usuario);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult Get ()
        {
            try
            {
                  return Ok(_usuarioRepository!.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            } 
        }

        [HttpGet("Login")]  
        public IActionResult Get(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository!.BuscarPorEmailSenha(email, senha);
                return Ok(usuarioBuscado);  
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        

       }
}
