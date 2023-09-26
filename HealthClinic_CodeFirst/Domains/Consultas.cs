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

        [Column(TypeName = "SMALLDATETIME")]
        [Required(ErrorMessage = "Horario da consulta obrigatoria")]
        public DateTime HorarioConsulta { get; set; }

        //referencia a tabela Medico = FOREIGN (FK)

        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]

        public Medicos? Medicos { get; set; }

        //referencia a tabela Pacientes = FOREIGN (FK)

        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]

        public Pacientes? Pacientes { get; set; }

        //referencia a tabela StatusConsulta = FOREIGN (FK)

        public Guid IdStatusConsulta { get; set; }

        [ForeignKey(nameof(IdStatusConsulta))]

        public StatusConsulta? StatusConsulta { get; set; }
     
    }
}
