using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IConsultasRepository
    {
        List<Consultas> Listar();
        void Cadastrar(Consultas consulta);

        Consultas BuscarPorId(Guid id);

        void Atualizar(Guid id, Consultas consulta);

        void Deletar(Guid id);
    }
}
