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

        }

        public Ovino(string numeroCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, double costoAdquisicion, double peso, bool esHibrido, double pesoEstimadoLana) : base(numeroCaravana, sexo, raza, fechaNacimiento, costoAdquisicion, peso, esHibrido)
        {
            PesoEstimadoLana = pesoEstimadoLana;
        }

        public override double CalcularPrecioVenta()
        {
            throw new NotImplementedException();
        }

        public override void Validar()
        {
            //todo
        }
    }
}
