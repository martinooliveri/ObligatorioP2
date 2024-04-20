using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Capataz : Empleado
    {
        public int NumeroSupervisados { get; set; }

        public Capataz()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Capataz(int numeroSupervisados)
        {
            Id = UltimoId;
            UltimoId++;
            NumeroSupervisados = numeroSupervisados;
        }
    }
}
