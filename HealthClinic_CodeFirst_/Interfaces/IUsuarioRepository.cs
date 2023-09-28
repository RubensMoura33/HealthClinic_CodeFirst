using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IUsuarioRepository
    {

        List<Usuario> Listar();
        Usuario BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Usuario usuario);

        void Deletar(Guid id);
    }
}
