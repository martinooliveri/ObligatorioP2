using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Peon : Empleado
    {
        public bool EsResidente { get; set; }
        private List<Tarea> _tareas { get; } = new List<Tarea>();

        public Peon()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Peon(bool esResidente)
        {
            Id = UltimoId;
            UltimoId++;
            EsResidente = esResidente;
        }
    }
}
