using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClinicaRepository
    /// Definir os métodos que serão implementados pelo ClinicaRepository
    /// </summary>
    public interface IClinicaRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="clinica">Objeto que será cadastrado</param>

        void Cadastrar(Clinica clinica);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="clinica">Objeto atualizado(novas informações)</param>
        void Atualizar(Guid id, Clinica clinica);
    }
}
