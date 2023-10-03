using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio Medicos 
    /// </summary>
    public class MedicosRepository:IMedicosRepository
    {
        /// <summary>
        /// Cria um novo objeto _healthContext do tipo HealthContext
        /// </summary>
        /// 
        private readonly HealthContext? _healthContext;

        /// <summary>
        /// Instancia o objeto _healthcontext para que haja referência aos dados do banco
        /// </summary>
        public MedicosRepository()
        {
            _healthContext = new HealthContext();   
        }

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="medico[">Objeto atualizado(novas informações)</param>
        public void Atualizar(Guid id, Medicos medico)
        {
            Medicos medicoBuscado = _healthContext!.Medicos.Find(id)!;
            if (medicoBuscado != null)
            {
                medicoBuscado.IdMedico = medico.IdMedico;

                medicoBuscado.Nome = medico.Nome;

                medicoBuscado.CRM = medico.CRM;

                medicoBuscado.CPF = medico.CPF;

                medicoBuscado.IdClinica = medico.IdClinica;

                medicoBuscado.IdUsuario = medico.IdUsuario;

                medicoBuscado.IdEspecialidade = medico.IdEspecialidade;
            }
        }

        /// <summary>
        /// Buscar um objeto atraves do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        public Medicos BuscarPorId(Guid id)
        {
            try
            { Medicos medicoBuscado = _healthContext!.Medicos.Select(h => new Medicos
            {
                IdMedico = h.IdMedico,
                Nome = h.Nome,
                CRM = h.CRM,
                CPF = h.CPF,
                IdClinica = h.IdClinica,
                IdEspecialidade = h.IdEspecialidade,
                IdUsuario = h.IdUsuario,

                Clinica = new Clinica
                {
                    IdClinica = h.Clinica!.IdClinica,
                    NomeFantasia = h.Clinica.NomeFantasia,
                    Endereco = h.Clinica.Endereco,
                    HorarioAbertura = h.Clinica.HorarioAbertura,
                    HorarioFechamento = h.Clinica.HorarioFechamento,
                    RazaoSocial = h.Clinica.RazaoSocial,
                    CNPJ = h.Clinica.CNPJ
                },

                Usuario = new Usuario
                {
                    IdUsuario = h.Usuario!.IdUsuario,
                    Nome = h.Usuario.Nome,
                    Email = h.Usuario.Email,
                    Senha = h.Usuario.Senha,
                },

                Especialidades =  new Especialidades
                {
                    IdEspecialidade = h.Especialidades!.IdEspecialidade,
                    NomeEspecialidade = h.Especialidades.NomeEspecialidade
                }

            }).FirstOrDefault(h => h.IdMedico == id)!;
            
            if (medicoBuscado != null)
            {
                return medicoBuscado;
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
        /// <param name="medico">Objeto que será cadastrado</param>
        public void Cadastrar(Medicos medico)
        {
            try
            {
            _healthContext!.Medicos.Add(medico);
            _healthContext!.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            } 
        }

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        public void Deletar(Guid id)
        {
            Medicos medicoBuscado = _healthContext!.Medicos.Find(id)!;
            _healthContext.Medicos.Remove(medicoBuscado);
            _healthContext!.SaveChanges();
        }

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        public List<Medicos> Listar()
        {
            return _healthContext!.Medicos.ToList();
        }
    }
}
