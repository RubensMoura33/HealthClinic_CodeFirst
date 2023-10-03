using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ComentariosConsultaRepository
    /// Definir os métodos que serão implementados pelo ComentariosConsultaRepository
    /// </summary>
    public interface IComentariosConsultaRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<ComentariosConsulta> Listar();

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        ComentariosConsulta BuscarPorId(Guid id);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="comentario">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id , ComentariosConsulta comentario);

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="comentario">Objeto que será cadastrado</param>
        void Cadastar(ComentariosConsulta comentario);

    }
}
