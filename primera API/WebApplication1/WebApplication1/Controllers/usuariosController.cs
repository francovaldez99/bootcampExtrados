using DAOs.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class usuariosController : ControllerBase
    {
        private UsuarioServices serviciouser { get; set; } = new UsuarioServices();

        

        [HttpGet("find/{id}")] public Usuario getUser(string id)
        {
            var consultaservice = serviciouser.findByIdService(id);
            return consultaservice;
        }

        [HttpPost] public bool NewUserController(Usuario user)
        {
            if (user.edad > 0)
            {
                
                return serviciouser.nuevoUsuario(user);

            } else
            {
                return false;
            }
        }

        [HttpGet("get-all")] public IEnumerable<Usuario> GetAllUsers()
        {   
            var consultaServices = serviciouser.getAllUsuariosServices();

            return consultaServices;
        }

        [HttpPut("update")] public Usuario UpdateUser(Usuario user)
        {
            Console.WriteLine($"{user.nombre}+{user.id}");
            var consultaservices = serviciouser.updateUserService(user.nombre,user.id);
            return consultaservices;
        }
    }
}
