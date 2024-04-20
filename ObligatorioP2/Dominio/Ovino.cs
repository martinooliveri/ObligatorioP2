using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ovino : Animal
    {
        public double PesoEstimadoLana { get; set; }
        public static double PrecioKiloLana { get; set; } = 1;
        public static double PrecioKiloOvinoEnPie { get; set; } = 1;

        public Ovino()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Ovino(double pesoEstimadoLana)
        {
            Id = UltimoId;
            UltimoId++;
            PesoEstimadoLana = pesoEstimadoLana;
        }



    }
}
