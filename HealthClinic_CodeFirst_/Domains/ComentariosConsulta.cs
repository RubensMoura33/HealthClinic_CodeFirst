using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthClinic_CodeFirst_.Domains
{
    [Table(nameof(ComentariosConsulta))]
    public class ComentariosConsulta
    {
        [Key]

        public Guid IdComentarioConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(200)")]

        public string? Descricao { get; set; }


        //referencia a tabela Consulta 

        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]

        public Consultas? Consultas { get; set; }
    }
}
