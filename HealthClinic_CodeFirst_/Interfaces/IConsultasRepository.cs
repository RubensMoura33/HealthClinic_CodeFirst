using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ConsultasRepository
    /// Definir os métodos que serão implementados pelo ConsultasRepository
    /// </summary>
    public interface IConsultasRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<Consultas> Listar();

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="consulta">Objeto que será cadastrado</param>
        void Cadastrar(Consultas consulta);

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        Consultas BuscarPorId(Guid id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="consulta">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id, Consultas consulta);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);
    }
}
