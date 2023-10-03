using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio Clinica
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        /// 
        private readonly HealthContext? _healthcontext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public ClinicaRepository()
        {
            _healthcontext = new HealthContext();
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="clinica">Objeto atualizado(novas informações)</param>
        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaBuscada = _healthcontext!.Clinica.Find(id)!;

            if(clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.Endereco = clinica.Endereco; 
                clinicaBuscada.HorarioAbertura = clinica.HorarioAbertura;
                clinicaBuscada.HorarioFechamento = clinica.HorarioFechamento;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                clinicaBuscada.CNPJ = clinica.CNPJ;
            }
            _healthcontext.Clinica.Update(clinicaBuscada!);
            _healthcontext.SaveChanges();
        }

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="clinica">Objeto que será cadastrado</param>
        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _healthcontext!.Clinica.Add(clinica);
                _healthcontext.SaveChanges();
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
            Clinica clinicaBuscada = _healthcontext!.Clinica.Find(id)!;
            _healthcontext.Clinica.Remove(clinicaBuscada);
            _healthcontext.SaveChanges();
        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<Clinica> Listar()
        {
            return _healthcontext!.Clinica.ToList();
        }
    }
}
