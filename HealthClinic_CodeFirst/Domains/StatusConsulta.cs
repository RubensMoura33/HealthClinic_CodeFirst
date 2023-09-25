using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst.Domains
{
    [Table(nameof (StatusConsulta))]
    public class StatusConsulta
    {
        [Key]

        public Guid IdStatusConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage ="A situacao da consulta e obrigatoria")]
        public bool Situacao { get; set; }
    }
}
