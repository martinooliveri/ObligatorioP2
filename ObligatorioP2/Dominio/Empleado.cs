using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Email { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Empleado() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Empleado(string email, string nombre, DateTime fechaIngreso)
        {
            Id = UltimoId;
            UltimoId++;
            Email = email;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
        }
    }
}
