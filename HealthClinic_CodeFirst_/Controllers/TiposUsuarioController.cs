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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository? _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpPut]

        public IActionResult Put(Guid id, TiposUsuario tipoUsuario) 
        {
            try
            {
                _tiposUsuarioRepository!.Atualizar(id, tipoUsuario);
                 return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            } 

        }

        [HttpPost]

        public IActionResult Post (TiposUsuario tipoUsuario)
        {
            try
            {
                _tiposUsuarioRepository!.Cadastrar(tipoUsuario);
                return StatusCode(201);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository!.Listar());

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpGet("{id}")]

        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository!.BuscarPorId(id));
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
                _tiposUsuarioRepository!.Deletar(id);
               return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
