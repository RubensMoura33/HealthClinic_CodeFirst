using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR (100)")]
        [Required(ErrorMessage = "O email do usuario e obrigatorio")]

        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "A senha do usuario e obrigatoria")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter entre 6 a 60 caracteres")]

        public string? Senha { get; set; }

        //referencia a tabela TiposUsuario = FOREIGN KEY (FK)

        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]

        public TiposUsuario? TiposUsuario { get; set; }
    }
}
