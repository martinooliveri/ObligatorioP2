using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vacuna
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string PatogenoPrevenido { get; set; }


        public Vacuna()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Vacuna(string nombre, string descripcion, string patogenoPrevenido)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Descripcion = descripcion;
            PatogenoPrevenido = patogenoPrevenido;
        }
    }
}
