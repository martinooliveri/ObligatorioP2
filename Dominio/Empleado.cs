using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Empleado: IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Email { get; set; } = "HOLA123@GMAIL.COM";
        public string Contrasenia { get; set; } = "HOLA123";
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; } = true;

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

        public abstract void Validar();

        public override bool Equals(object? obj)
        {
            return obj is Empleado empleado &&
                   Id == empleado.Id &&
                   Nombre == empleado.Nombre;
        }
    }
}
