using HealthClinic_CodeFirst_.Contexts;
using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;

namespace HealthClinic_CodeFirst_.Repositories
{
    public class MedicosRepository:IMedicosRepository
    {
        private readonly HealthContext? _healthContext;

        public MedicosRepository()
        {
            _healthContext = new HealthContext();   
        }
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

        public void Deletar(Guid id)
        {
            Medicos medicoBuscado = _healthContext!.Medicos.Find(id)!;
            _healthContext.Medicos.Remove(medicoBuscado);
            _healthContext!.SaveChanges();
        }

        public List<Medicos> Listar()
        {
            return _healthContext!.Medicos.ToList();
        }
    }
}
