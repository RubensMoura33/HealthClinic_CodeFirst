using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using HealthClinic_CodeFirst_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_CodeFirst_.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //dominio/api/nomeController
    //ex: http://localhost:5000/api/especialidades
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Classe controladora que herda da controller base
    //Onde será criado os Endpoints (rotas)
    public class EspecialidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _especialidadesRepository que irá receber todos os métodos definidos na interface IEspecialidadesRepository
        /// </summary>
        private IEspecialidadesRepository? _especialidadesRepository;

        /// <summary>
        /// Instancia o objeto _especialidadesRepository para que haja referência aos métodos no repositório
        /// </summary>
        public EspecialidadesController()
        {
            _especialidadesRepository = new EspecialidadesRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _especialidadesRepository!.Deletar(id);
            return StatusCode(204);
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
                return Ok(_especialidadesRepository!.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
