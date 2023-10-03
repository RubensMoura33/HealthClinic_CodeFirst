using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TiposUsuarioRepository
    /// Definir os métodos que serão implementados pelo TiposUsuarioRepository
    /// </summary>
    public interface ITiposUsuarioRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="tipoUsuario">Objeto que será cadastrado</param>
        void Cadastrar(TiposUsuario tipoUsuario);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="tipoUsuario[">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id, TiposUsuario tipoUsuario);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        TiposUsuario BuscarPorId(Guid id);
    }
}
