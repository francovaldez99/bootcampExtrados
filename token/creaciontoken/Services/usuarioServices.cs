


using DAOs;
using DAOs.Entidades;

namespace creaciontoken.Services
{
    public class usuarioServices
    {
        UsuarioDAO db = new UsuarioDAO();

        public Task<Usuario> registerService(Usuario usuario)
        {   
            //hashear password 
            string hashedpass = BCrypt.Net.BCrypt.HashPassword(usuario.clave);
            usuario.clave = hashedpass;
            return db.newUser(usuario);
        }
        public async Task<bool> comparePasswordService(Usuario usuario)
        {
            var getUser =await db.getUserFromDB(usuario);
            bool passIsvalid= BCrypt.Net.BCrypt.Verify(usuario.clave,getUser.clave);

            return passIsvalid;

        }
    }
}
