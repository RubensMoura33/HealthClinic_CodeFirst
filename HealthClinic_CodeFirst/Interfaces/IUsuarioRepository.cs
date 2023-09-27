using HealthClinic_CodeFirst.Domains;

namespace HealthClinic_CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorEmailSenha(string email, string senha);

        void Cadastrar (Usuario usuario);

        Usuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Usuario usuario);

        void Deletar(Guid id);
    }
}
