// See https://aka.ms/new-console-template for more information
using Conexion_db_borrado_logico.DAOs;
using Conexion_db_borrado_logico.Models;

Console.WriteLine("Empezando con DAOs!");

DAOUsuario db = new DAOUsuario();
Usuario usuarioFranco = new Usuario()
{   Id = 1,
    Nombre = "Franco",
    Edad = 25,
    Activo = true
};
db.NuevoUsuario(usuarioFranco);

Usuario usuarioFulano = new Usuario()
{
    Id = 2,
    Nombre = "Fulano",
    Edad = 22,
    Activo = true
};
db.NuevoUsuario(usuarioFulano);

//db.ObtenerUsuarioId(1);

usuarioFranco.Nombre = "Franco Martin";
usuarioFranco.Edad = 26;

db.ActualizarUsuario(usuarioFranco.Id, usuarioFranco);
 db.ObtenerUsuarioId(1);
db.EliminarUsuario(1);

var usuarios = db.ObtenerTodoslosUsuarios();
Console.Write("Todos los usuarios");
foreach (var usuario in usuarios)
{
    Console.WriteLine(usuario.Nombre);
    Console.WriteLine(usuario.Id);


}