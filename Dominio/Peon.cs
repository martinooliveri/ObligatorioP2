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

        public Peon() { }

        public Peon(string email, string nombre, DateTime fechaIngreso, bool esResidente) : base(email, nombre, fechaIngreso)
        {
            EsResidente = esResidente;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
