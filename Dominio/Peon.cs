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
        public Tarea Tarea { get; set; }
        private List<Tarea> _tareas { get; } = new List<Tarea>();


        public Peon() { }

        public Peon(string email, string nombre, DateTime fechaIngreso, bool esResidente) : base(email, nombre, fechaIngreso)
        {
            EsResidente = esResidente;
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El mail tiene que existir");
            }
            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("La contraseña debe existir");
            }
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre debe existir");
            }
            throw new NotImplementedException();
        }
        public void CerrarTarea(Tarea t)
        {
            Tarea.FueCompletada = true;
            Tarea.FechaDeCierre = DateTime.Now;
        }
    }
}
