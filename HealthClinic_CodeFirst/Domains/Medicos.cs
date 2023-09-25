using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst.Domains
{
    [Table(nameof(Medicos))]
    [Index(nameof(CRM), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    public class Medicos
    {
        [Key]

        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do medico é obrigatorio")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(12)")]
        [Required(ErrorMessage = "O CRM do medico é obrigatorio")]
        public string? CRM { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "CPF do medico é obrigatorio")]
        public string? CPF { get; set; }


        //referencia a tabela Usuario = FOREIGN KEY (FK)

        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]

        public Usuario? Usuario { get; set; }


        //referencia a tabela Especialidades = FOREIGN KEY (FK)

        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]

        public Especialidades? Especialidades { get; set; }

        //referencia a tabela Clinica = FOREIGN KEY (FK)

        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]

        public Clinica? Clinica { get; set; }
    }
}
