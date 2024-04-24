using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vacuna: IValidable
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

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
            ValidarPatogeno();
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre de la vacuna no puede ser vacio");
            }
        }

        public void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("Descripcion de la vacuna no puede ser vacio");
            }
        }

        public void ValidarPatogeno()
        {
            if (string.IsNullOrEmpty(PatogenoPrevenido))
            {
                throw new Exception("Patogeno prevenido de la vacuna no puede ser vacio");
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Vacuna vacuna &&
                   Id == vacuna.Id &&
                   Nombre == vacuna.Nombre &&
                   PatogenoPrevenido == vacuna.PatogenoPrevenido;
        }
    }
}
