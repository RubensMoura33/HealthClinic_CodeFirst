using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthClinic_CodeFirst_.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Consultas
    /// </summary>
    /// 
    [Table(nameof(Consultas))]
    public class Consultas
    {
        [Key]

        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data da consulta obrigatoria!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataConsulta { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horario da consulta obrigatorio!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan? HorarioConsulta { get; set; }

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
