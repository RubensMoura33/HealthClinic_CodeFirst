using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly HealthContext? _healthContext;

        public TiposUsuarioRepository()

        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            TiposUsuario tipoBuscado = _healthContext!.TipoUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
            }
            _healthContext.TipoUsuario.Update(tipoBuscado!);
            _healthContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario tipoBuscado = _healthContext!.TipoUsuario.Select(h => new TiposUsuario
                {
                    IdTipoUsuario = h.IdTipoUsuario,
                    TituloTipoUsuario = h.TituloTipoUsuario
                }).FirstOrDefault(h => h.IdTipoUsuario == id)!;

                if(tipoBuscado != null)
                {
                    return tipoBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            try
            {
                _healthContext!.TipoUsuario.Add(tipoUsuario);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tipoBuscado = _healthContext!.TipoUsuario.Find(id)!;
            _healthContext.TipoUsuario.Remove(tipoBuscado);
            _healthContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _healthContext!.TipoUsuario.ToList();
            
        }
    }
}
