using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IEspecialidadesRepository
    {
        List<Especialidades> Listar();
        void Cadastrar(Especialidades especialidades);

        Especialidades BuscarPorId(Guid id);

        void Atualizar(Guid id, Especialidades especialidades);

        void Deletar(Guid id);
    }
}
