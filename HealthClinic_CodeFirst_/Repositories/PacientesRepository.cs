using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class PacientesRepository : IPacientesRepository
    {
        private readonly HealthContext? _healthContext;

        public PacientesRepository()
        {
            _healthContext = new HealthContext();   
        }
        public void Atualizar(Guid id, Pacientes paciente)
        {
            Pacientes pacienteBuscado = _healthContext!.Pacientes.Find(id)!;
            if (pacienteBuscado != null)
            {
                pacienteBuscado.Nome = paciente.Nome;
                pacienteBuscado.DataDeNascimento = paciente.DataDeNascimento;
                pacienteBuscado.CPF = paciente.CPF;
                pacienteBuscado.Telefone = paciente.Telefone;
                pacienteBuscado.CEP = paciente.CEP;
                pacienteBuscado.IdUsuario = paciente.IdUsuario;
            }
            _healthContext.Pacientes.Update(pacienteBuscado!);
            _healthContext.SaveChanges();
        }

        public Pacientes BuscarPorId(Guid id)
        {
            try
            {
                Pacientes pacienteBuscado = _healthContext!.Pacientes.Select(h => new Pacientes
                {
                    IdPaciente = h.IdPaciente,
                    Nome = h.Nome,
                    DataDeNascimento = h.DataDeNascimento,
                    CPF = h.CPF,
                    Telefone = h.Telefone,
                    CEP = h.CEP,
                    IdUsuario = h.IdUsuario,

                    Usuario = new Usuario 
                    {
                    IdUsuario = h.Usuario!.IdUsuario,
                    Nome=h.Usuario.Nome
                    
                    }
                }).FirstOrDefault(h => h.IdPaciente == id)!;

                if(pacienteBuscado != null)
                {
                    return pacienteBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Pacientes paciente)
        {
            _healthContext!.Pacientes.Add(paciente);
            _healthContext?.SaveChanges();
        }

        public void Deletar(Guid id)
        {
           Pacientes pacienteBuscado = _healthContext!.Pacientes.Find(id)!;

            _healthContext.Pacientes.Remove(pacienteBuscado);

            _healthContext.SaveChanges();
        }

        public List<Pacientes> Listar()
        {
            return _healthContext!.Pacientes.ToList();
        }
    }
}
