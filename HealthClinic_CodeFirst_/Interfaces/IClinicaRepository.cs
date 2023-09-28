using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IClinicaRepository
    {
        List<Clinica> Listar();

        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        void Atualizar(Guid id, Clinica clinica);
    }
}
