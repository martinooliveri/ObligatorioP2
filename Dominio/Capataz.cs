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

        public Capataz(){}
        
        public Capataz(string email, string contrasenia, string nombre, DateTime fechaIngreso, int numeroSupervisados) : base(nombre, email, contrasenia, fechaIngreso)
        {
            NumeroSupervisados = numeroSupervisados;
        }

        public override void Validar()
        {
            try
            {
                base.Validar();
                ValidarNumeroSupervisados();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarNumeroSupervisados()
        {
            if (NumeroSupervisados < 0)
            {
                throw new Exception("Numero de supervisados no es valido");
            }
        }

        public override string GetTipo()
        {
            return "Capataz";
        }
    }
}
