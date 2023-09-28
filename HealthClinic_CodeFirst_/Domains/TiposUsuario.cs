using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthClinic_CodeFirst_.Domains
{
    [Table(nameof(TiposUsuario))]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR (50)")]
        [Required(ErrorMessage = "Titulo do tipo de usuario e obrigatorio")]

        public string? TituloTipoUsuario { get; set; }
    }
}
