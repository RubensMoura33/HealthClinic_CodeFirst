using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio Especialidades
    /// </summary>
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        /// 
        private readonly HealthContext? _healthContext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public EspecialidadesRepository()
        { 
            _healthContext = new HealthContext();
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="especialidades[">Objeto atualizado(novas informações)</param>
        public void Atualizar(Guid id, Especialidades especialidades)
        {
            Especialidades especialidadeBuscada = _healthContext!.Especialidades.Find(id)!;
            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.IdEspecialidade = especialidades.IdEspecialidade;
                especialidadeBuscada.NomeEspecialidade = especialidades.NomeEspecialidade;

            }
            _healthContext.Especialidades.Update(especialidadeBuscada!);
            _healthContext.SaveChanges();
        }

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        public Especialidades BuscarPorId(Guid id)
        {
            try
            {
            Especialidades especialidadeBuscada = _healthContext!.Especialidades.Select(h => new Especialidades
            {
                IdEspecialidade = h.IdEspecialidade,
                NomeEspecialidade = h.NomeEspecialidade
            }
            ).FirstOrDefault(h => h.IdEspecialidade == id)!;
            if (especialidadeBuscada != null)
            {
                return (especialidadeBuscada);
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
        /// <param name="especialidades">Objeto que será cadastrado</param>
        public void Cadastrar(Especialidades especialidades)
        {
            _healthContext!.Especialidades.Add(especialidades);
            _healthContext?.SaveChanges();
        }

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        public void Deletar(Guid id)
        {
            Especialidades especialidadeBuscada = _healthContext!.Especialidades.Find(id)!;
            _healthContext.Especialidades.Remove(especialidadeBuscada);
            _healthContext?.SaveChanges();
        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<Especialidades> Listar()
        {
            return(_healthContext!.Especialidades.ToList());
        }
    }
}
