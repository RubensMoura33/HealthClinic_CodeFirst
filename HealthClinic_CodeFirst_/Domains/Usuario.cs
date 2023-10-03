using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_CodeFirst_.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Usuario
    /// </summary>
    /// 
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR (100)")]
        [Required(ErrorMessage = "Nome do usuario obrigatorio")]
        public string? Nome { get; set; }

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
