using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst.Domains
{
    [Table(nameof(Especialidades))]
    public class Especialidades
    {
        [Key]

        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome da especialidade obrigatoria")]
        public string? NomeEspecialidade { get; set; }
    }
}
