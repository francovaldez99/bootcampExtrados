using DAOs.Entidades;
using Dapper;
using MySqlConnector;
namespace DAOs
{
    public class usuarioDAO
    {
        private string connectionString = "Server=127.0.0.1;Database=tareahash;UId=root;Password=adminvaldez;";


        public Usuario register(Usuario newuser) {

            
            using(var connection = new MySqlConnection(connectionString))
            {
                try
                {

                    string query = "Insert into Usuario(usuario,contraseña) VALUES(@usuario,@contraseña)";
                    Console.Write(newuser.contraseña);
                    var consulta = connection.Query<Usuario>(query, new { usuario = newuser.usuario, contraseña = newuser.contraseña });

                    var consulta2 = connection.QuerySingleOrDefault<Usuario>("Select * from Usuario where usuario=@usuario", new { usuario = newuser.usuario });

                    return consulta2;
                }
               
              
                catch (MySqlException ex)
                {

                    throw new Exception("Error al conectar con la base de datos.", ex);
                }
                catch (Exception ex)
                {
                
                    throw new Exception("Error inesperado en el DAO.", ex);
                }
            }
        }

        public Usuario FindUser(Usuario user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "Select * from Usuario where usuario=@usuario";
                var consulta = connection.QuerySingleOrDefault<Usuario>(query, new { usuario = user.usuario });

                return consulta;
            }
        }


    }
}
