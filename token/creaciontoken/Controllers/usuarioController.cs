using creaciontoken.Services;
using DAOs.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace creaciontoken.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class usuarioController : ControllerBase
    {
        usuarioServices servicio = new usuarioServices();
       
        [HttpPost("new")] public async Task<Usuario> register(Usuario user) { 
        
            return await servicio.registerService(user);
        }

        [HttpPost("login")] public async Task<IActionResult> login(Usuario user)
        {
            bool passIsvalid =await servicio.comparePasswordService(user);
            if (!passIsvalid) {
                return StatusCode(401, new {mensaje="password no valido" });
            }
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_secret_supeeeerrr_secrettt_123456789"));
            var credentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> { 
            new Claim(ClaimTypes.GivenName,user.usuario),
            };
            var Sectoken = new JwtSecurityToken("http://localhost:5131",
                "http://localhost:5131",
                claims:claims,
                expires:DateTime.Now.AddMinutes(20),
                signingCredentials:credentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken); 
            return Ok(token);
        }

        [HttpGet("ruta-protegida")]
        [Authorize] public string ProtectedRoute()
        {
            var user = User.FindFirst(ClaimTypes.GivenName)?.Value;


            return user;
        }


    }
}
