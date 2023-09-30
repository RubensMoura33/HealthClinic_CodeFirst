using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        private readonly HealthContext? _healthContext;

        public EspecialidadesRepository()
        { 
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Especialidades especialidades)
        {
            Especialidades especialidadeBuscada = _healthContext!.Especialidades.Find(id)!;
            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.IdEspecialidade = especialidades.IdEspecialidade;
                especialidadeBuscada.NomeEspecialidade = especialidades.NomeEspecialidade;

            }
            _healthContext.Especialidades.Update(especialidadeBuscada!);
            _healthContext.SaveChanges();

        }

        public Especialidades BuscarPorId(Guid id)
        {
            try
            {
            Especialidades especialidadeBuscada = _healthContext!.Especialidades.Select(h => new Especialidades
            {
                IdEspecialidade = h.IdEspecialidade,
                NomeEspecialidade = h.NomeEspecialidade
            }
            ).FirstOrDefault(h => h.IdEspecialidade == id)!;
            if (especialidadeBuscada != null)
            {
                return (especialidadeBuscada);
            }

            return null!;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Cadastrar(Especialidades especialidades)
        {
            _healthContext!.Especialidades.Add(especialidades);
            _healthContext?.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidades especialidadeBuscada = _healthContext!.Especialidades.Find(id)!;
            _healthContext.Especialidades.Remove(especialidadeBuscada);
            _healthContext?.SaveChanges();
        }

        public List<Especialidades> Listar()
        {
            return(_healthContext!.Especialidades.ToList());
        }
    }
}
