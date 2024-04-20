using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Bovino : Animal
    {
        public Alimentacion Alimentacion { get; set; }
        public static double PrecioKiloBovinoEnPie { get; set; } = 1;
        
        public Bovino() 
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Bovino(Alimentacion alimentacion)
        {
            Id = UltimoId;
            UltimoId++;
            Alimentacion = alimentacion;
        }



    }
}
