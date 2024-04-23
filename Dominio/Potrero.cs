using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Potrero : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Descripcion { get; set; }
        public double Hectareas { get; set; }
        public int CapacidadMaxima { get; set; }
        private List<Animal> _animales { get; } = new List<Animal>();

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

        public void AgregarAnimal(Animal a)
        {
            try
            {
                a.Validar();
                if (!_animales.Contains(a))
                {
                    _animales.Add(a);
                }
                else
                {
                    throw new Exception("Animal ya existe; no fue guardado");
                }

            }
            catch (Exception e)
            {
                throw;
            }
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
    }
}
