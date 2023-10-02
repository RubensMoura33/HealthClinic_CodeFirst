using HealthClinic_CodeFirst_.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HealthClinic_CodeFirst_.Contexts
{
    public class HealthContext : DbContext

    {
        public DbSet<TiposUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<StatusConsulta> StatusConsulta { get; set; }

        public DbSet<Pacientes> Pacientes { get; set; }

        public DbSet<Medicos> Medicos { get; set; }

        public DbSet<Especialidades> Especialidades { get; set; }

        public DbSet<Consultas> Consultas { get; set; }

        public DbSet<ComentariosConsulta> ComentariosConsultas { get; set; }

        public DbSet<Clinica> Clinica { get; set; }

        //Define as opcoes de construcao do banco (StringConexao)

        /// <summary>
        /// String de conexao
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE11-S13; DataBase= HealthClinic_CodeFirst; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=R4ULM1LGR4U\\SQLEXPRESSS; DataBase= HealthClinic_CodeFirst; User Id = sa; Pwd = Binho$2022; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }*/

    }
}
