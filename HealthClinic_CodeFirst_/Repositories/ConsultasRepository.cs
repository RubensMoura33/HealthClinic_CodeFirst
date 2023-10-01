using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class ConsultasRepository : IConsultasRepository
    {
        private readonly HealthContext? _healthContext;

        public ConsultasRepository()
        { 
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Consultas consulta)
        {
            Consultas consultaBuscada = _healthContext!.Consultas.Find(id)!;
            if (consulta != null)
            {
                consultaBuscada.DataConsulta = consulta.DataConsulta;
                consultaBuscada.HorarioConsulta = consulta.HorarioConsulta;
                consultaBuscada.IdMedico = consulta.IdMedico;
                consultaBuscada.IdPaciente = consulta.IdPaciente;
                consultaBuscada.IdStatusConsulta = consulta.IdStatusConsulta;
            }
            _healthContext.Consultas.Update(consultaBuscada);
            _healthContext.SaveChanges();
        }

        public Consultas BuscarPorId(Guid id)
        {
            try
            {
                Consultas consultaBuscada = _healthContext!.Consultas.Select(h => new Consultas
            {
                IdConsulta = h.IdConsulta,
                DataConsulta = h.DataConsulta,
                HorarioConsulta = h.HorarioConsulta,
                IdMedico = h.IdMedico,
                IdPaciente = h.IdPaciente,
                IdStatusConsulta = h.IdStatusConsulta,

                Medicos = new Medicos
                {
                    Nome = h.Medicos!.Nome,
                    CRM = h.Medicos.CRM,
                    CPF = h.Medicos.CPF
                },
                

                Pacientes = new Pacientes
                {
                    Nome = h.Pacientes!.Nome,
                    DataDeNascimento = h.Pacientes.DataDeNascimento,
                    CPF = h.Pacientes.CPF,
                    Telefone = h.Pacientes.Telefone,
                    CEP = h.Pacientes.CEP
                },

                StatusConsulta = new StatusConsulta 
                {
                    Situacao = h.StatusConsulta!.Situacao
                }
            }).FirstOrDefault(h => h.IdConsulta == id)!;

            if (consultaBuscada != null)
                {
                return consultaBuscada;
            }
            return null!;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Cadastrar(Consultas consulta)
        {
            _healthContext!.Consultas.Add(consulta);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consultas consultaBuscada = _healthContext!.Consultas.Find(id)!;
            _healthContext.Consultas.Remove(consultaBuscada);
            _healthContext.SaveChanges();
        }

        public List<Consultas> Listar()
        {
            return (_healthContext!.Consultas.ToList());
        }
    }
}
