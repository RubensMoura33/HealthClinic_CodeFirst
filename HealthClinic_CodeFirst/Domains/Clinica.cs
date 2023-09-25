using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    [Index(nameof(RazaoSocial), IsUnique = true)]
    public class Clinica
    {
        [Key]

        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome fantasia obrigatorio")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Endereco obrigatorio")]
        public string? Endereco { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario de abertura obrigatorio")]
        public DateTime HorarioAbertura { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario de fechamento obrigatorio")]
        public DateTime HorarioFechamento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Razao social obrigatorio")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatorio")]
        public string? CNPJ { get; set; }
    }
}
