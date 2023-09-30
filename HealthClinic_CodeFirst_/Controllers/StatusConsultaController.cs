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
    public class StatusConsultaController : ControllerBase
    {
        private IStatusConsultaRepository? _statusConsultaRepository;

        public StatusConsultaController() 
        {
            _statusConsultaRepository = new StatusConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_statusConsultaRepository!.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
         public IActionResult Post(StatusConsulta statusConsulta)
        {
            try
            {
                _statusConsultaRepository!.Cadastrar(statusConsulta);
                return Ok("Cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, StatusConsulta statusConsulta)
        {
            try
            {
                _statusConsultaRepository!.Atualizar(id, statusConsulta);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
         public IActionResult Delete(Guid id) 
        {
            try
            {
                _statusConsultaRepository!.Deletar(id);
                return Ok("Deletado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            } 
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_statusConsultaRepository!.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
