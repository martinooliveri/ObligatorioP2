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
    
        
        public Animal() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Animal(string numeroCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, double costoAdquisicion, double peso, bool esHibrido)
        {
            Id = UltimoId;
            UltimoId++;
            NumeroCaravana = numeroCaravana;
            Sexo = sexo;
            Raza = raza;
            FechaNacimiento = fechaNacimiento;
            CostoAdquisicion = costoAdquisicion;
            PesoActual = peso;
            EsHibrido = esHibrido;
        }

        public abstract double CalcularPrecioVenta();

        public virtual void Validar() 
        {
            ValidarNumeroCaravana();
            ValidarSexo();
            ValidarRaza();
            ValidarFechaNacimiento();
            ValidarCostoAdquisicion();
            ValidarPesoActual();
        }

        private void ValidarNumeroCaravana()
        {
            throw new NotImplementedException();
        }
        private void ValidarSexo()
        {
            throw new NotImplementedException();
        }
        private void ValidarRaza()
        {
            throw new NotImplementedException();
        }
        private void ValidarFechaNacimiento()
        {
            throw new NotImplementedException();
        }
        private void ValidarCostoAdquisicion()
        {
            throw new NotImplementedException();
        }
        private void ValidarPesoActual()
        {
            throw new NotImplementedException();
        }

        public void VacunarAnimal(Vacuna vacuna)
        {
            vacuna.Validar();
            Vacunacion vacunacion = new Vacunacion(vacuna);
            _vacunaciones.Add(vacunacion);
        }

        public override bool Equals(object? obj)
        {
            return obj is Animal animal &&
                   NumeroCaravana == animal.NumeroCaravana;
        }
    }
}
