using Conexion_db_borrado_logico.Models;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_db_borrado_logico.DAOs
{
    internal class DAOUsuario
    {
           public string connectionString = "Server=127.0.0.1;Database=tareax;UId=root;Password=adminvaldez;";
        public int NuevoUsuario(Usuario user)
        {
            string query = "INSERT INTO Usuario (Nombre, Edad,Activo) VALUES (@Nombre, @Edad,@Activo)";
            using (var connection = new MySqlConnection(connectionString)) {

               
                var NuevoUsuario = connection.Execute(query,user);
                Console.Write("Usuario Creado");
            return NuevoUsuario;
                
            }
        }
        public Usuario ObtenerUsuarioId(int Id)
        {
            string query = "Select * FROM Usuario WHere Id=@Id";
            using(var connection = new MySqlConnection(connectionString))
            {
                var consulta = connection.QueryFirstOrDefault<Usuario>(query,new{Id=Id });
                if (consulta==null) { Console.WriteLine("No hay nada");
                    return new Usuario();
                } else
                {
                    Console.WriteLine($"Consulta de Usuario de Id={Id} , Nombre={consulta.Nombre}");
                return consulta;
                }
        }
            }
        public int ActualizarUsuario(int id, Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Nombre = @Nombre, Edad = @Edad ,Activo=@Activo WHERE Id = @Id";
                var consulta = connection.Execute(query,new {Nombre=usuario.Nombre,Edad=usuario.Edad,Activo=usuario.Activo,Id=id });
                return consulta;
            }
        }

        public IEnumerable<Usuario> ObtenerTodoslosUsuarios()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "Select * From Usuario WHere Activo!=False";
                var consulta = connection.Query<Usuario>(query);
                return consulta;
            }
        }
        public int EliminarUsuario(int Id)
        {
            using (var connection=new MySqlConnection(connectionString))
            {
                string query = "Update Usuario SET Activo=False  Where Id=@Id";

                var consulta = connection.Execute(query, new { Id = Id });
                return consulta;
            }

        }
    }
}
