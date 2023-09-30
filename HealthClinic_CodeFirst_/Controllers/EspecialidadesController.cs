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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadesRepository? _especialidadesRepository;

        public EspecialidadesController()
        {
            _especialidadesRepository = new EspecialidadesRepository();
        }

        [HttpPut]
        public IActionResult Put(Guid id, Especialidades especialidade)
        {
            try
            {
                _especialidadesRepository!.Atualizar(id, especialidade);
                return Ok("Especialidade atualizada com sucesso");
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
                return Ok(_especialidadesRepository!.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw;
            } 
        }

        [HttpPost]
        public IActionResult Post(Especialidades especialidade)
        {
            try
            {
                _especialidadesRepository!.Cadastrar(especialidade);
                return Ok("Cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _especialidadesRepository!.Deletar(id);
            return StatusCode(204);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadesRepository!.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
