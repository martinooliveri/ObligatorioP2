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
        private List<Peon> _peones { get; } = new List<Peon>();

        public Capataz()
        {
        }
        
            public Capataz(string email, string nombre, DateTime fechaIngreso, int numeroSupervisados) : base(email, nombre, fechaIngreso)
        {
            NumeroSupervisados = numeroSupervisados;
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El mail tiene que existir");
            }
            if(string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("La contraseña debe existir");
            }
            if(string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre debe existir");
            }

            throw new NotImplementedException();
        }

        public void AsignarTareas(Peon p, Tarea t)
        {
        }
    }
}
