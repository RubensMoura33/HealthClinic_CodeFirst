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
    public class ConsultasController : ControllerBase
    {
        private IConsultasRepository? _consultasRepository;

        public ConsultasController()
        {
            _consultasRepository = new ConsultasRepository();
        }

        /// <summary>
        /// Aciona que aciona o metodo Listar
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_consultasRepository!.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            } 
        }
        /// <summary>
        /// Endpoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Post (Consultas consulta)
        {
            try
            {
                _consultasRepository!.Cadastrar(consulta);
                return Ok();
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
            _consultasRepository!.Deletar(id);
            return StatusCode(204);
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
            return Ok(_consultasRepository!.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            } 
        }

        /// <summary>
        /// Endpoint que aciona metodo Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public IActionResult Put(Guid id, Consultas consulta)
        {
            try
            {
            _consultasRepository!.Atualizar(id, consulta);
            return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            } 
        }

    }
}
