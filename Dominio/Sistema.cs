using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        public List<Animal> _animales { get; } = new List<Animal>();
        public List<Empleado> _empleados { get; } = new List<Empleado>();
        public List<Tarea> _tareas { get; } = new List<Tarea>();
        public List<Potrero> _potreros { get; } = new List<Potrero>();
        public List<Vacuna> _vacunas { get; } = new List<Vacuna>();

        private static Sistema _instancia; //atributo privado por singleton pattern

        private Sistema() //contructor privado por singleton pattern
        {
            PrecargarDatos();
        }

        public static Sistema Instancia() //singleton pattern para impedir crear otra instancia del Sistema
        {
            //if(_instancia == null)
            //{
            //    return _instancia = new Sistema();
            //}
            return _instancia ??= new Sistema(); //que elegante
        }

        private void PrecargarDatos()
        {

        }

    }
}
