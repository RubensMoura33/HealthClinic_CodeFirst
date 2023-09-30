using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IMedicosRepository
    {
        List<Medicos> Listar();
        void Cadastrar(Medicos medico);

        Medicos BuscarPorId(Guid id);

        void Atualizar(Guid id, Medicos medico);

        void Deletar(Guid id);
    }
}
