using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthClinic_CodeFirst_.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Pacientes
    /// </summary>
    /// 
    [Table(nameof(Pacientes))]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(Telefone), IsUnique = true)]
    public class Pacientes
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do paciente e obrigatorio")]
        public string? Nome { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de nascimento obrigatoria!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataDeNascimento { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "Data de nascimento obrigatoria")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR (100)")]
        [Required(ErrorMessage = "Numero de telefone obrigatorio")]
        public string? Telefone { get; set; }

        [Column(TypeName = "CHAR (8)")]
        [Required(ErrorMessage = "CEP obrigatorio")]
        public string? CEP { get; set; }

        //referencia a tabela Usuario = FOREIGN KEY (FK)

        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]

        public Usuario? Usuario { get; set; }

    }
}
