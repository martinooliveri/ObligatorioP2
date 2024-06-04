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

        public Bovino(){}

        public Bovino(string numeroCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, double costoAdquisicion, double peso, bool esHibrido, Alimentacion alimentacion) : base(numeroCaravana, sexo, raza, fechaNacimiento, costoAdquisicion, peso, esHibrido)
        {
            Alimentacion = alimentacion;
        }

        //Si el animal es hembra o su alimentacion es pastura,
        //se le agregan correspondientes recargos locales
        public override double CalcularGananciaEstimada()
        {
            int esHembra = (Sexo == Sexo.Hembra) ? 1 : 0;
            int esDePastura = (Alimentacion == Alimentacion.Pastura) ? 1 : 0;
            double gananciaPorPeso = PrecioKiloBovinoEnPie * PesoActual;
            double recargoHembra = gananciaPorPeso * 0.30 * esHembra;
            double recargoPastura = gananciaPorPeso * 0.10 * esDePastura;

            return gananciaPorPeso + recargoHembra + recargoPastura;
        }

        public override void Validar()
        {
            try
            {
                base.Validar();
                ValidarAlimentacion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarAlimentacion()
        {
            if (Alimentacion != Alimentacion.Pastura && Alimentacion != Alimentacion.Grano)
            {
                throw new Exception("Tipo de alimentacion ingresada no es valida");
            }
        }
    }
}
