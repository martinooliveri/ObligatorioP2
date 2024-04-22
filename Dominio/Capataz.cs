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
        }
        public Capataz(int numeroSupervisados)
        {
            NumeroSupervisados = numeroSupervisados;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
