using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IPacientesRepository
    {
        List<Pacientes> Listar();

        void Cadastrar(Pacientes paciente);

        Pacientes BuscarPorId(Guid id);

        void Atualizar(Guid id, Pacientes paciente);

        void Deletar(Guid id);
    }
}
