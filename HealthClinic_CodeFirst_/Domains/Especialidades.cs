using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthClinic_CodeFirst_.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Especialidades
    /// </summary>
    /// 
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
