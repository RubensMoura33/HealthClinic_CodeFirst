using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IStatusConsultaRepository
    {
        List<StatusConsulta> Listar();

        void Cadastrar(StatusConsulta statusConsulta);

        StatusConsulta BuscarPorId(Guid id);

        void Atualizar(Guid id, StatusConsulta statusConsulta);

        void Deletar(Guid id);
    }
}
