using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Animal : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string NumeroCaravana { get; set; }
        public Sexo Sexo { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double CostoAdquisicion { get; set; }
        public double CostoAlimentacion { get; set; }
        public double PesoActual { get; set; }
        public bool EsHibrido { get; set; }
        private List<Vacunacion> _vacunaciones { get; } = new List<Vacunacion>();
    
        
        public Animal() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Animal(string numeroCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, double costoAdquisicion, double peso, bool esHibrido)
        {
            Id = UltimoId;
            UltimoId++;
            NumeroCaravana = numeroCaravana;
            Sexo = sexo;
            Raza = raza;
            FechaNacimiento = fechaNacimiento;
            CostoAdquisicion = costoAdquisicion;
            PesoActual = peso;
            EsHibrido = esHibrido;
        }

        public abstract double CalcularPrecioVenta();

        public abstract void Validar();
    }
}
