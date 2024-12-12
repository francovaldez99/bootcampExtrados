using BCrypt.Net;
using DAOs.Entidades;
using hascontraseña.Services;
using Microsoft.AspNetCore.Mvc;

namespace hascontraseña.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class usuarioController : ControllerBase
    {
        private usuarioServices serviciouser = new usuarioServices();


        [HttpPost("register")] public IActionResult registerController(Usuario newUser) {


            try
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(newUser.contraseña);

                newUser.contraseña = hash;

                var servicio = serviciouser.registerService(newUser);

              return Ok(servicio);

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);

           return  StatusCode(500, new { mensaje = "Ocurrió un error al procesar la solicitud.", detalle = ex.Message });

            }
        }
        [HttpPost("login")] public bool loginController(Usuario user)
        {
            return     serviciouser.loginService(user);
        }



    }
}
