using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório MedicosRepository
    /// Definir os métodos que serão implementados pelo MedicosRepository
    /// </summary>
    public interface IMedicosRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<Medicos> Listar();

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="medico">Objeto que será cadastrado</param>
        void Cadastrar(Medicos medico);

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        Medicos BuscarPorId(Guid id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="medico[">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id, Medicos medico);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);
    }
}
