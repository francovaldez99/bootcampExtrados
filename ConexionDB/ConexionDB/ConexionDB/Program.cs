// See https://aka.ms/new-console-template for more information
using ConexionDB.DAOs;
using System.Data;
using System.Security.Cryptography.X509Certificates;
Console.WriteLine("Iniciando");
DAOUsuario db = new DAOUsuario();
var usuario1 = db.GetUser(1);
Console.WriteLine(usuario1.Nombre);
var allUsers=db.GetUsers();
foreach (var itemuser in allUsers)
{
    Console.WriteLine(itemuser.Nombre);
    
}