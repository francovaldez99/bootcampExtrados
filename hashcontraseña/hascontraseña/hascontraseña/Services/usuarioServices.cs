using DAOs;
using DAOs.Entidades;

namespace hascontraseña.Services
{
    public class usuarioServices
    {
        private usuarioDAO db=new usuarioDAO();
        public Usuario registerService(Usuario newUser)
        {

            try
            {

                return db.register(newUser);
            }
            catch (Exception ex) {
                throw new Exception("Error en la lógica del servicio: " + ex.Message, ex);
            }
        }

        public bool loginService(Usuario user)
        {
            var userDB = db.FindUser(user);
            return BCrypt.Net.BCrypt.Verify(user.contraseña, userDB.contraseña);
        }
    }
}
