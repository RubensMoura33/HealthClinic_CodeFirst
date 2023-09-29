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
    public class PacientesController : ControllerBase
    {
        private IPacientesRepository? _pacienteRepository;

        public PacientesController()
        {
            _pacienteRepository = new PacientesRepository();
        }

        [HttpGet]

        public IActionResult Get() 
        {
            try
            {
                return Ok (_pacienteRepository!.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]

        public IActionResult Post (Pacientes paciente)
        {
            try
            {
                 _pacienteRepository!.Cadastrar(paciente);
                            return Ok();
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
                _pacienteRepository!.Deletar(id);
                            return Ok("Deletado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            } 
        }

        [HttpPut]

        public IActionResult Put(Guid id, Pacientes paciente)
        {
            try
            {
                _pacienteRepository!.Atualizar(id, paciente);
                return Ok("Atualizado com sucesso");
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
                return Ok(_pacienteRepository!.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }


    }
}
