
using DAOs.Entidades;
using Dapper;
using MySqlConnector;
using System.Data.Common;
using System.Reflection;


namespace DAOs
{
    public class UsuarioDAO
    {
        public static UsuarioDAO instance = null;
        public string connectionString = "Server=127.0.0.1;Database=tareax;UId=root;Password=adminvaldez;";
        private UsuarioDAO() { }
        public static UsuarioDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsuarioDAO();

                }
                return instance;

            }
        }

        public Usuario NewUser(Usuario user)
        {
                string query = "INSERT INTO Usuario(nombre,email,edad) Values(@nombre, @email, @edad)";
            using (var connection = new MySqlConnection(connectionString))
            {
                Console.WriteLine($"id {user.id}, nombre {user.nombre} , edad {user.edad}");
                Console.Write("estamos en dao nuevo usuario");
                Usuario consulta = connection.QueryFirstOrDefault<Usuario>(query,new {nombre=user.nombre,email=user.email,edad=user.edad });
                if (consulta == null)
                {
                    return new Usuario()
                    {
                        nombre = "USUARIO NO CREADO",
                        edad=99,
                        email="NO CREADO "
                    };
                }
                return consulta;
            }
           
        }

        public IEnumerable<Usuario> getusers()
        {
            string query = "SELECT * FROM Usuario;";
            using (var connection = new MySqlConnection(connectionString))
            {
                var consulta = connection.Query<Usuario>(query);
                return consulta;
            }
        }
        public Usuario updateUserDB(string nombre,string id)
        {
            string query = "UPDATE Usuario SET nombre=@nombre WHERE id=@id;";
            using(var connection = new MySqlConnection(connectionString))
            {
                var consulta = connection.Execute(query, new { nombre = nombre,id=id });
                string selectQuery = "SELECT * FROM Usuario WHERE id = @id";

                return connection.QuerySingleOrDefault<Usuario>(selectQuery, new { id = id });




            }
        }
        public Usuario findById(string id)
        {
            string query = "SELECT * FROM Usuario WHERE id = @id"; ;
            using (var connection = new MySqlConnection(connectionString))
            {
                var consulta = connection.QuerySingleOrDefault<Usuario>(query,new { id = id });
                return consulta;
            }
        }

    }
}
