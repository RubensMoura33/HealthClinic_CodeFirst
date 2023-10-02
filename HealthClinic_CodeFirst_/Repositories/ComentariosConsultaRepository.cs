using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class ComentariosConsultaRepository : IComentariosConsultaRepository
 
    {
        private readonly HealthContext? _healthContext;

        public ComentariosConsultaRepository()
        {
            _healthContext = new HealthContext();
        }
   
        public void Atualizar(Guid id, ComentariosConsulta comentario)
        {
            ComentariosConsulta comentarioBuscado = _healthContext!.ComentariosConsultas.Find(id)!;
            if (comentarioBuscado != null)
            {
                comentarioBuscado.Descricao = comentario.Descricao;
                comentarioBuscado.IdConsulta = comentario.IdConsulta;
            }

            _healthContext.ComentariosConsultas.Update(comentarioBuscado!);
            _healthContext.SaveChanges();
        }

        public ComentariosConsulta BuscarPorId(Guid id)
        {
            
            /*return _healthContext!.ComentariosConsultas.Find(id);*/
            return _healthContext!.ComentariosConsultas.FirstOrDefault(h => h.IdComentarioConsulta == id)!;
        }

        public void Cadastar(ComentariosConsulta comentario)
        {
            _healthContext!.ComentariosConsultas.Add(comentario);
            _healthContext!.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentariosConsulta comentarioBuscado = _healthContext!.ComentariosConsultas.Find(id)!;
            _healthContext!.ComentariosConsultas.Remove(comentarioBuscado);
            _healthContext!.SaveChanges();
        }

        public List<ComentariosConsulta> Listar()
        {
            return _healthContext!.ComentariosConsultas.ToList();
        }
    }
}
