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
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository? _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

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
                new Claim(ClaimTypes.Role,login.TiposUsuario!.TituloTipoUsuario!)
 };
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
