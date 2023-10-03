using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using HealthClinic_CodeFirst_.Utils;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio Usuario
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        /// 
        private readonly HealthContext? _healthContext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="usuario[">Objeto atualizado(novas informações)</param>
        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = _healthContext!.Usuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;

                usuarioBuscado.Senha = usuario.Senha;

                usuarioBuscado.Nome = usuario.Nome;

                usuarioBuscado.IdTipoUsuario = usuario.IdTipoUsuario;
            }

            _healthContext.Usuario.Update(usuarioBuscado!);

            _healthContext.SaveChanges();
        }

        /// <summary>
        /// Buscar um usuario atraves do email e senha
        /// </summary>
        /// <param name="email">Email do usuario a ser buscado</param>
        /// <param name="senha">Senha do usuario a ser buscado</param>
        /// <returns>Objeto Buscado</returns>
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

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
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

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="usuario">Objeto que será cadastrado</param>
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

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        public void Deletar(Guid id)
        {
            Usuario usuarioBuscado = _healthContext!.Usuario.Find(id)!;

            _healthContext.Usuario.Remove(usuarioBuscado);

            _healthContext.SaveChanges();
        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<Usuario> Listar()
        {
            return _healthContext!.Usuario.ToList();
        }
    }
}
