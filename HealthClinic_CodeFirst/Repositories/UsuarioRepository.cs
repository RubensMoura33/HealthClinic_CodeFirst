using HealthClinic_CodeFirst.Contexts;
using HealthClinic_CodeFirst.Domains;
using HealthClinic_CodeFirst.Interfaces;
using HealthClinic_CodeFirst.Utils;

namespace HealthClinic_CodeFirst.Repositories
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
                { bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);
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
                Usuario usuarioBuscado = _healthContext!.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoUsuario = u.IdTipoUsuario,


                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario = u.TiposUsuario!.IdTipoUsuario,
                        TituloTipoUsuario = u.TiposUsuario!.TituloTipoUsuario
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

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
    }
}
