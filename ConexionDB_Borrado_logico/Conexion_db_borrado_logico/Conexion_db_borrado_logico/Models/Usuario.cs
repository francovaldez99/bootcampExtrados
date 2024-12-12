using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_db_borrado_logico.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public bool Activo { get; set; }   
    }
}
