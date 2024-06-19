using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Animal : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string NumeroCaravana { get; set; }
        public Sexo Sexo { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double CostoAdquisicion { get; set; }
        public double CostoAlimentacion { get; set; }
        public double PesoActual { get; set; }
        public bool EsHibrido { get; set; }
        private List<Vacunacion> _vacunaciones { get; } = new List<Vacunacion>();
        public List<Vacunacion> GetVacunaciones()
        { 
            return _vacunaciones; 
        }
        
        public Animal() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Animal(string numeroCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double peso, bool esHibrido)
        {
            Id = UltimoId;
            UltimoId++;
            NumeroCaravana = numeroCaravana;
            Sexo = sexo;
            Raza = raza;
            FechaNacimiento = fechaNacimiento;
            CostoAdquisicion = costoAdquisicion;
            CostoAlimentacion = costoAlimentacion;
            PesoActual = peso;
            EsHibrido = esHibrido;
        }

        public double CalcularPrecioVenta()
        {
            return CalcularGananciaEstimada() - CalcularCostoCrianza();
        }
        public double CalcularCostoCrianza()
        {
            return CostoAdquisicion + CostoAlimentacion + GetVacunaciones().Count * 200;
        }
        public abstract double CalcularGananciaEstimada();
        public virtual void Validar() 
        {
            try
            {
                ValidarNumeroCaravana();
                ValidarRaza();
                ValidarCostoAdquisicion();
                ValidarPesoActual();
                ValidarSexo();
                ValidarFechaNacimiento();
                ValidarCostoAlimentacion(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarCostoAlimentacion()
        {
            if(CostoAlimentacion <= 0)
            {
                throw new Exception("Costo de Alimentacion no es valido");
            }
        }

        private void ValidarNumeroCaravana()
        {
            if(NumeroCaravana == null || NumeroCaravana.Length != 8)
            {
                throw new Exception("Numero de caravana no es valido");
            }
        }
        private void ValidarSexo()
        {
            if (Sexo != Sexo.Macho && Sexo != Sexo.Hembra)
            {
                throw new Exception("Sexo del animal no es valido");
            }
        }
        private void ValidarRaza()
        {
            if (Raza == null || string.IsNullOrWhiteSpace(Raza))
            {
                throw new Exception("Raza ingresada no es valida");
            }
        }
        private void ValidarFechaNacimiento()
        {
            if ((FechaNacimiento == DateTime.MinValue || FechaNacimiento.Year < 1980 || FechaNacimiento.Month > 12 || FechaNacimiento.Month < 0 || FechaNacimiento.Day > 31 || FechaNacimiento.Day < 1) || FechaNacimiento > DateTime.Today)
            {
                throw new Exception("Fecha ingresada no es valida");
            }
        }
        private void ValidarCostoAdquisicion()
        {
            if(CostoAdquisicion <= 0)
            {
                throw new Exception("Costo de adquisicion ingresado no es valido");
            }
        }
        private void ValidarPesoActual()
        {
            if(PesoActual <= 0)
            {
                throw new Exception("Peso ingresado no es valido");
            }
        }

        public void VacunarAnimal(Vacuna vacuna)
        {
            try
            {
                vacuna.Validar();
                Vacunacion vacunacion = new Vacunacion(vacuna);
                _vacunaciones.Add(vacunacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Animal animal &&
                   NumeroCaravana == animal.NumeroCaravana;
        }

        public override string ToString()
        {
            string sexo = Sexo == Sexo.Macho ? "Macho" : "Hembra";
            string resultado = $"{NumeroCaravana}\t{Raza}{"  "}\t{PesoActual}\t{sexo}";
            return resultado;
        }

        public abstract string GetTipo();
    }
}
