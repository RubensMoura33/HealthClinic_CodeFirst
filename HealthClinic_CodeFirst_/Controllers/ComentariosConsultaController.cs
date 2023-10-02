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
    public class ComentariosConsultaController : ControllerBase
    {
        private IComentariosConsultaRepository? _comentariosConsultaRepository;

        public ComentariosConsultaController()
        {
            _comentariosConsultaRepository = new ComentariosConsultaRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo Listar
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentariosConsultaRepository!.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="comentario"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Post (ComentariosConsulta comentario)
        {
            try
            {
            _comentariosConsultaRepository!.Cadastar(comentario);
            return StatusCode (201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
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
            _comentariosConsultaRepository!.Deletar(id);
            return Ok("Deletado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            } 
        }

        /// <summary>
        /// Endpoint que aciona o metodo Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comentario"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public IActionResult Put (Guid id, ComentariosConsulta comentario)
        {
            try
            {
            _comentariosConsultaRepository!.Atualizar(id, comentario);
            return Ok("Atualizado com sucessso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo BuscarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            try
            {
                return Ok (_comentariosConsultaRepository!.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            } 
        }
    }
}
