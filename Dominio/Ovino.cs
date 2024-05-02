using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

        
        public override double CalcularGananciaEstimada()
        {
            return PesoEstimadoLana * PrecioKiloLana + PesoActual * PrecioKiloOvinoEnPie;
        }

        public static void CambiarValorKiloLana(double valor)
        {
            Ovino.PrecioKiloLana = valor;
        }

        public static void CambiarValorKiloOvinoEnPie(double valor)
        {
            Ovino.PrecioKiloOvinoEnPie = valor;
        }

        public override void Validar()
        {
            if(PesoEstimadoLana <= 0)
            {
                throw new Exception("El peso de lana no es valido");
            }
        }
    }
}
