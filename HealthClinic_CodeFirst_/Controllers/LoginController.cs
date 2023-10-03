using HealthClinic_CodeFirst_.Domains;
using HealthClinic_CodeFirst_.Interfaces;
using HealthClinic_CodeFirst_.Repositories;
using HealthClinic_CodeFirst_.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HealthClinic_CodeFirst_.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //dominio/api/nomeController
    //ex: http://localhost:5000/api/clinica
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Classe controladora que herda da controller base
    //Onde será criado os Endpoints (rotas)
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository? _usuarioRepository;

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                Usuario login = _usuarioRepository!.BuscarPorEmailSenha(usuario.Email!, usuario.Senha!);

                if (login == null)
                {
                    return StatusCode(401, "Email ou senha invalidos");
                }

                //Logica token

                var claims = new[]
               {
                new Claim(JwtRegisteredClaimNames.Email, login.Email!),
                new Claim(JwtRegisteredClaimNames.Name, login.Nome!),
                new Claim(JwtRegisteredClaimNames.Jti, login.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role,login.TiposUsuario!.TituloTipoUsuario!)};
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-clinic-api-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "HealthClinic_CodeFirst_",
                    audience: "HealthClinic_CodeFirst_",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
