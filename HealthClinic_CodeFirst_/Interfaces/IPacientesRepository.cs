using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório PacientesRepository
    /// Definir os métodos que serão implementados pelo PacientesRepository
    /// </summary>
    public interface IPacientesRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<Pacientes> Listar();

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="paciente">Objeto que será cadastrado</param>
        void Cadastrar(Pacientes paciente);

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        Pacientes BuscarPorId(Guid id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="paciente[">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id, Pacientes paciente);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);
    }
}
