using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// Definir os métodos que serão implementados pelo UsuarioRepository
    /// </summary>
    public interface IUsuarioRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Buscar um usuario atraves do email e senha
        /// </summary>
        /// <param name="email">Email do usuario a ser buscado</param>
        /// <param name="senha">Senha do usuario a ser buscado</param>
        /// <returns>Objeto Buscado</returns>
        Usuario BuscarPorEmailSenha(string email, string senha);

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="usuario">Objeto que será cadastrado</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        Usuario BuscarPorId(Guid id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="usuario[">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id, Usuario usuario);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);
    }
}
