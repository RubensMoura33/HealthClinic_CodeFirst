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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository? _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Endpoit que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="clinica"></param>
        /// <returns></returns>
        /// 
        [HttpPost]

        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository!.Cadastrar(clinica);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoit que aciona o metodo Listar
        /// </summary>
        /// <returns>Lista de clinicas</returns>
        /// 
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_clinicaRepository!.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoit que aciona o metodo Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinica"></param>
        /// <returns></returns>
        /// 
        [HttpPut]

        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                _clinicaRepository!.Atualizar(id, clinica);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoit que aciona o metodo Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository!.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
