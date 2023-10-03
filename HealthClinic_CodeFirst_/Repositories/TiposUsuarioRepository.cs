using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio TiposUsuario
    /// </summary>
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        ///
        private readonly HealthContext? _healthContext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public TiposUsuarioRepository()

        {
            _healthContext = new HealthContext();
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="tipoUsuario[">Objeto atualizado(novas informações)</param>
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            TiposUsuario tipoBuscado = _healthContext!.TipoUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
            }
            _healthContext.TipoUsuario.Update(tipoBuscado!);
            _healthContext.SaveChanges();
        }

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario tipoBuscado = _healthContext!.TipoUsuario.Select(h => new TiposUsuario
                {
                    IdTipoUsuario = h.IdTipoUsuario,
                    TituloTipoUsuario = h.TituloTipoUsuario
                }).FirstOrDefault(h => h.IdTipoUsuario == id)!;

                if(tipoBuscado != null)
                {
                    return tipoBuscado;
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
        /// <param name="tipoUsuario">Objeto que será cadastrado</param>
        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            try
            {
                _healthContext!.TipoUsuario.Add(tipoUsuario);
                _healthContext.SaveChanges();
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
            TiposUsuario tipoBuscado = _healthContext!.TipoUsuario.Find(id)!;
            _healthContext.TipoUsuario.Remove(tipoBuscado);
            _healthContext.SaveChanges();
        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<TiposUsuario> Listar()
        {
            return _healthContext!.TipoUsuario.ToList();
            
        }
    }
}
