using DAOs.Entidades;
using Dapper;
using MySqlConnector;

namespace DAOs
{
    public class UsuarioDAO
    {
        private string connectionString = "Server=127.0.0.1;Database=tokenusuario;UId=root;Password=adminvaldez;";
        async public Task<Usuario> newUser(Usuario user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var newUser = await connection.QueryAsync("INSERT INTO Usuario(usuario,clave) Values(@usuario,@clave);", new { usuario = user.usuario, clave = user.clave });
                var getNewUser = await connection.QuerySingleOrDefaultAsync<Usuario>("Select * from Usuario Where usuario=@usuario;", new { usuario = user.usuario });

                return getNewUser;
            }
        }
        public async Task<Usuario> getUserFromDB(Usuario usuario)
        {
            if (usuario == null) { throw new Exception("no hay usuario"); }
            using (var connection = new MySqlConnection(connectionString))
            {
                Usuario getUser = await connection.QuerySingleOrDefaultAsync<Usuario>("Select * from Usuario Where usuario=@usuario;", new { usuario = usuario.usuario });

                return getUser;
            }

        }
    }
}
