using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using HealthClinic_CodeFirst_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_CodeFirst_.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //dominio/api/nomeController
    //ex: http://localhost:5000/api/statusconsulta
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Classe controladora que herda da controller base
    //Onde será criado os Endpoints (rotas)
    public class StatusConsultaController : ControllerBase
    {
        /// <summary>
        /// Objeto _statusConsultaRepository que irá receber todos os métodos definidos na interface IStatusConsultaRepository
        /// </summary>
        private IStatusConsultaRepository? _statusConsultaRepository;

        /// <summary>
        /// Instancia o objeto _statusConsultaRepository para que haja referência aos métodos no repositório
        /// </summary>
        public StatusConsultaController()
        {
            _statusConsultaRepository = new StatusConsultaRepository();
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
                return Ok(_statusConsultaRepository!.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="statusConsulta"></param>
        /// <returns></returns>
        /// 
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

        /// <summary>
        /// Endpoint que aciona o metodo Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusConsulta"></param>
        /// <returns></returns>
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
                _statusConsultaRepository!.Deletar(id);
                return Ok("Deletado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// ENdpoint que aciona o metodo BuscarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
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
