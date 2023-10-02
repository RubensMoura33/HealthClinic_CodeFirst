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
    public class MedicoController : ControllerBase
    {
        private IMedicosRepository? _medicosRepository;

        public MedicoController()
        {
            _medicosRepository = new MedicosRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo BucarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}")]

        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_medicosRepository!.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///Endpoint que aciona o metodo Cadastrar 
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Post(Medicos medico)
        {
            try
            {
            _medicosRepository!.Cadastrar(medico);
            return Ok();
            }
            catch (Exception e)
            {

                throw;
            } 

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
                return Ok(_medicosRepository!.Listar());
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
        /// <param name="medico"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public IActionResult Put(Guid id, Medicos medico)
        {
            try
            {
                _medicosRepository!.Atualizar(id, medico);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message );
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
                _medicosRepository!.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
