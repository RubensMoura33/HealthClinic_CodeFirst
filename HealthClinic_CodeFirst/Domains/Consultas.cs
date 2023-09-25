using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst.Domains
{
    [Table(nameof(Consultas))]
    public class Consultas
    {
        [Key]

        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data da consulta obrigatoria")]
        public DateTime DataConsulta { get; set;}

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario da consulta obrigatoria")]
        public DateTime HorarioConsulta { get; set; }

        //referencia a 


    }
}
