using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class StatusConsultaRepository : IStatusConsultaRepository
    {
        private readonly HealthContext? _healthContext;

        public StatusConsultaRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, StatusConsulta statusConsulta)
        {
            StatusConsulta statusBuscado = _healthContext!.StatusConsulta.Find(id)!;
            if (statusBuscado != null) 
            {
                statusBuscado.IdStatusConsulta = statusConsulta.IdStatusConsulta;
                statusBuscado.Situacao = statusConsulta.Situacao;
            }
            _healthContext.StatusConsulta.Update(statusBuscado!);
            _healthContext.SaveChanges();

        }

        public StatusConsulta BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(StatusConsulta statusConsulta)
        {
            try
            {
                _healthContext!.StatusConsulta.Add(statusConsulta);
                _healthContext?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            StatusConsulta statusBuscado = _healthContext!.StatusConsulta!.Find(id)!;
            _healthContext.StatusConsulta.Remove(statusBuscado);
            _healthContext?.SaveChanges();

        }

        public List<StatusConsulta> Listar()
        {
            return _healthContext!.StatusConsulta.ToList();
        }
    }
}
