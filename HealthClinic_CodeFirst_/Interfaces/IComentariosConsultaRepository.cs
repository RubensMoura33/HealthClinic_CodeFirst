using HealthClinic_CodeFirst_.Domains;

namespace HealthClinic_CodeFirst_.Interfaces
{
    public interface IComentariosConsultaRepository
    {
        List<ComentariosConsulta> Listar();

        ComentariosConsulta BuscarPorId(Guid id);

        void Deletar(Guid id);

        void Atualizar(Guid id , ComentariosConsulta comentario);

        void Cadastar(ComentariosConsulta comentario);

    }
}
