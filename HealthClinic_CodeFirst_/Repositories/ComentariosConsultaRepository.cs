using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio ComentariosConsulta
    /// </summary>
    public class ComentariosConsultaRepository : IComentariosConsultaRepository
 
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        /// 
        private readonly HealthContext? _healthContext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public ComentariosConsultaRepository()
        {
            _healthContext = new HealthContext();
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="comentario">Objeto atualizado(novas informações)</param>
        public void Atualizar(Guid id, ComentariosConsulta comentario)
        {
            ComentariosConsulta comentarioBuscado = _healthContext!.ComentariosConsultas.Find(id)!;
            if (comentarioBuscado != null)
            {
                comentarioBuscado.Descricao = comentario.Descricao;
                comentarioBuscado.IdConsulta = comentario.IdConsulta;
            }

            _healthContext.ComentariosConsultas.Update(comentarioBuscado!);
            _healthContext.SaveChanges();
        }

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        public ComentariosConsulta BuscarPorId(Guid id)
        {
            
            /*return _healthContext!.ComentariosConsultas.Find(id);*/
            return _healthContext!.ComentariosConsultas.FirstOrDefault(h => h.IdComentarioConsulta == id)!;
        }

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="comentario">Objeto que será cadastrado</param>
        public void Cadastar(ComentariosConsulta comentario)
        {
            _healthContext!.ComentariosConsultas.Add(comentario);
            _healthContext!.SaveChanges();
        }

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        public void Deletar(Guid id)
        {
            ComentariosConsulta comentarioBuscado = _healthContext!.ComentariosConsultas.Find(id)!;
            _healthContext!.ComentariosConsultas.Remove(comentarioBuscado);
            _healthContext!.SaveChanges();
        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<ComentariosConsulta> Listar()
        {
            return _healthContext!.ComentariosConsultas.ToList();
        }
    }
}
