using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthClinic_CodeFirst_.Domains
{
    [Table(nameof(StatusConsulta))]
    public class StatusConsulta
    {
        [Key]

        public Guid IdStatusConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situacao da consulta e obrigatoria")]
        public bool Situacao { get; set; }
    }
}
