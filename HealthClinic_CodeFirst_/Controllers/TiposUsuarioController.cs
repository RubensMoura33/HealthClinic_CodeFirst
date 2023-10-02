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

        /// <summary>
        /// Endpoint que aciona o metodo Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo Listar
        /// </summary>
        /// <returns>Lista de TiposUsuario</returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo BuscarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto Buscado</returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
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
