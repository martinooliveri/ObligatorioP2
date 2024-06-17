using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Potrero : IValidable, IComparable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Descripcion { get; set; }
        public double Hectareas { get; set; }
        public int CapacidadMaxima { get; set; }
        private List<Animal> _animales { get; } = new List<Animal>();
        public List<Animal> GetAnimales()
        {
            return _animales;
        }

        public Potrero()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Potrero(string descripcion, double hectareas, int capacidadMaxima)
        {
            Id = UltimoId;
            UltimoId++;
            Descripcion = descripcion;
            Hectareas = hectareas;
            CapacidadMaxima = capacidadMaxima;
        }

        public void Validar()
        {
            ValidarDescripcion();
            ValidarHectareas();
            ValidarCapacidadMaxima();
        }

       

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("Descripcion del potrero no puede ser vacio");
            }
        }
        private void ValidarHectareas()
        {
            if (Hectareas < 1)
            {
                throw new Exception("Cantidad de hectareas no es valida");
            }
        }
        private void ValidarCapacidadMaxima()
        {
            if (CapacidadMaxima < 1)
            {
                throw new Exception("Capacidad maxima no es valida");
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Potrero potrero &&
                   Id == potrero.Id &&
                   Hectareas == potrero.Hectareas &&
                   CapacidadMaxima == potrero.CapacidadMaxima;
        }

        public double CalcularPrecioVenta()
        {
            double precioVenta = 0;
            foreach(Animal a in _animales)
            {
                precioVenta += a.CalcularPrecioVenta();
            }
            return precioVenta;
        }

        public int GetCantidadAnimales()
        {
            return _animales.Count;
        }

        public override string ToString()
        {
            return $"{Id}\t{Descripcion}\t\t{"  "}{CapacidadMaxima}\t{Hectareas}";
        }

        public int CompareTo(Potrero? obj)
        {
            if(CapacidadMaxima.CompareTo(obj.CapacidadMaxima) > 1)
            {
                return 1;
            }
            else if(CapacidadMaxima.CompareTo(obj.CapacidadMaxima) < 1)
            {
                return -1;
            }
            else if(GetCantidadAnimales() < obj.GetCantidadAnimales()) //segundo criterio de ordenamiento
            {
                return 1;
            }
            else if(GetCantidadAnimales() > obj.GetCantidadAnimales())
            {
                return -1;
            }
            else return 0;
        }
    }
}
