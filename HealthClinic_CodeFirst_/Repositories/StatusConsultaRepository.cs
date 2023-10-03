using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio StatusConsulta
    /// </summary>
    public class StatusConsultaRepository : IStatusConsultaRepository
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        /// 

        private readonly HealthContext? _healthContext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public StatusConsultaRepository()
        {
            _healthContext = new HealthContext();
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="statusConsulta[">Objeto atualizado(novas informações)</param>
        public void Atualizar(Guid id, StatusConsulta statusConsulta)
        {
            StatusConsulta statusBuscado = _healthContext!.StatusConsulta.Find(id)!;
            if (statusBuscado != null) 
            {
                statusBuscado.IdStatusConsulta = statusConsulta.IdStatusConsulta;
                statusBuscado.Situacao = statusConsulta.Situacao;
            }
            _healthContext.StatusConsulta.Update(statusBuscado!);
            _healthContext.SaveChanges();

        }

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        public StatusConsulta BuscarPorId(Guid id)
        {
            try
            {
                StatusConsulta statusBuscado = _healthContext!.StatusConsulta.Select(h => new StatusConsulta
                {
                    IdStatusConsulta = h.IdStatusConsulta,
                    Situacao = h.Situacao
                }).FirstOrDefault(h => h.IdStatusConsulta == id)!;

                if(statusBuscado != null)
                {
                    return statusBuscado;
                }
                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="statusConsulta">Objeto que será cadastrado</param>
        public void Cadastrar(StatusConsulta statusConsulta)
        {
            try
            {
                _healthContext!.StatusConsulta.Add(statusConsulta);
                _healthContext?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        public void Deletar(Guid id)
        {
            StatusConsulta statusBuscado = _healthContext!.StatusConsulta!.Find(id)!;
            _healthContext.StatusConsulta.Remove(statusBuscado);
            _healthContext?.SaveChanges();

        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<StatusConsulta> Listar()
        {
            return _healthContext!.StatusConsulta.ToList();
        }
    }
}
