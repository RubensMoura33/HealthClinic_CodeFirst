using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EspecialidadesRepository
    /// Definir os métodos que serão implementados pelo EspecialidadesRepository
    /// </summary>
    public interface IEspecialidadesRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<Especialidades> Listar();

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="especialidades">Objeto que será cadastrado</param>
        void Cadastrar(Especialidades especialidades);

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        Especialidades BuscarPorId(Guid id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="especialidades[">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id, Especialidades especialidades);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);
    }
}
