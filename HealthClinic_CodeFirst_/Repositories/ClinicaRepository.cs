using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext? _healthcontext;

        public ClinicaRepository()
        {
            _healthcontext = new HealthContext();
        }
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

        public void Deletar(Guid id)
        {
            Clinica clinicaBuscada = _healthcontext!.Clinica.Find(id)!;
            _healthcontext.Clinica.Remove(clinicaBuscada);
            _healthcontext.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return _healthcontext!.Clinica.ToList();
        }
    }
}
