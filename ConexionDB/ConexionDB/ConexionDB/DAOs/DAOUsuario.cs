using ConexionDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
namespace ConexionDB.DAOs
{
    public class DAOUsuario
    {
        public Usuario GetUser(int id)
        {
            string query = "Select * FROM Usuario Where id=@id;";
            string connectionString = "Server=127.0.0.1;Database=tareax;UId=root;Password=adminvaldez;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                var user = connection.QueryFirstOrDefault<Usuario>(query, new{id = id});
                return user;
            }
        }
        public IEnumerable<Usuario> GetUsers()
        {
            string query = "SELECT * FROM Usuario";
            string connectionString = "Server=127.0.0.1;Database=tareax;UId=root;Password=adminvaldez;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                var users = connection.Query<Usuario>(query);
                return users;
            }
        }




        
        
    }
}
