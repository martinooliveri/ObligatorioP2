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

        public Bovino(string numeroCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, double costoAdquisicion, double peso, bool esHibrido, Alimentacion alimentacion) : base(numeroCaravana, sexo, raza, fechaNacimiento, costoAdquisicion, peso, esHibrido)
        {
            Alimentacion = alimentacion;
        }

        public override double CalcularGananciaEstimada()
        {
            if(Sexo == Sexo.Hembra)
            {
                return PrecioKiloBovinoEnPie * PesoActual
            }
            return PrecioKiloBovinoEnPie * PesoActual
        }

        public override void Validar()
        {
            //todo
        }
    }
}
