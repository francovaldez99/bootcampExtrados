using DAOs;
using DAOs.Entidades;

namespace WebApplication1.Services
{
    public class UsuarioServices
    {
        UsuarioDAO db = UsuarioDAO.Instance;
      

        public Usuario findByIdService( string id)
        {
            var consultadb = db.findById(id);
            return  consultadb;
        }
        public bool nuevoUsuario(Usuario user)
        {
            if (user.edad<14) {
                return false;
            }
            if (!user.email.Contains("@gmail.com"))
            {
                return false;
            }
            else
            {


            db.NewUser(user);
            return true;
            }
        }

        public IEnumerable<Usuario> getAllUsuariosServices()
        {
            var allUsers = db.getusers();
            IEnumerable<Usuario> lista=new List<Usuario>();
            if (allUsers.Count()>0)
            {
                return allUsers;
            }else
            {
                return lista;
            }
            
        }

        public Usuario updateUserService(string nombre,string id)
        {
            Console.WriteLine($"services {nombre}+{id}");
            var consultaUpdate = db.updateUserDB(nombre,id);
            return consultaUpdate;
        }
    }
}
