using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using HealthClinic_CodeFirst_.Utils;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext? _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = _healthContext!.Usuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;

                usuarioBuscado.Senha = usuario.Senha;

                usuarioBuscado.Nome = usuario.Nome;
            }

            _healthContext.Usuario.Update(usuarioBuscado!);

            _healthContext.SaveChanges();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext!.Usuario.Select(h => new Usuario

                {
                    IdUsuario = h.IdUsuario,
                    Email = h.Email,
                    Senha = h.Senha,
                    Nome = h.Nome,
                    IdTipoUsuario = h.IdTipoUsuario,

                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario = h.TiposUsuario!.IdTipoUsuario,
                        TituloTipoUsuario = h.TiposUsuario.TituloTipoUsuario,
                    }
                }).FirstOrDefault(h => h.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);
                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext!.Usuario.Select(h => new Usuario
                {
                    IdUsuario = h.IdUsuario,
                    Nome = h.Nome,
                    Email = h.Email,
                    Senha = h.Senha,
                    IdTipoUsuario = h.IdTipoUsuario,


                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario = h.TiposUsuario!.IdTipoUsuario,
                        TituloTipoUsuario = h.TiposUsuario!.TituloTipoUsuario
                    }
                }).FirstOrDefault(h => h.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }

                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _healthContext!.Usuario.Add(usuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioBuscado = _healthContext!.Usuario.Find(id)!;

            _healthContext.Usuario.Remove(usuarioBuscado);

            _healthContext.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _healthContext!.Usuario.ToList();
        }
    }
}
