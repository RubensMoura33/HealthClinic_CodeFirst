using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio Pacientes
    /// </summary>
    public class PacientesRepository : IPacientesRepository
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        /// 
        private readonly HealthContext? _healthContext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public PacientesRepository()
        {
            _healthContext = new HealthContext();   
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="paciente[">Objeto atualizado(novas informações)</param>
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

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        public Pacientes BuscarPorId(Guid id)
        {
            try
            {
                Pacientes pacienteBuscado = _healthContext!.Pacientes.Select(h => new Pacientes
                {
                    IdUsuario = h.IdUsuario,
                    IdPaciente = h.IdPaciente,
                    Nome = h.Nome,
                    DataDeNascimento = h.DataDeNascimento,
                    CPF = h.CPF,
                    Telefone = h.Telefone,
                    CEP = h.CEP,

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

        /// <summary>
        /// Cadastrar um novo objeto
        /// </summary>
        /// <param name="paciente">Objeto que será cadastrado</param>
        public void Cadastrar(Pacientes paciente)
        {
            _healthContext!.Pacientes.Add(paciente);
            _healthContext?.SaveChanges();
        }

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        public void Deletar(Guid id)
        {
           Pacientes pacienteBuscado = _healthContext!.Pacientes.Find(id)!;

            _healthContext.Pacientes.Remove(pacienteBuscado);

            _healthContext.SaveChanges();
        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<Pacientes> Listar()
        {
            return _healthContext!.Pacientes.ToList();
        }
    }
}
