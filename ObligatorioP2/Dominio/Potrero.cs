using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Potrero
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
    }
}
