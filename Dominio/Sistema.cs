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
            PreCargarPeones();
            PreCargarAnimales();

        }

        private void PreCargarPeones()
        {
            Random rnd = new Random();

            Peon p1 = new Peon("martinooliveri@gmail.com", "Martino Oliveri", DateTime.Now.AddDays(rnd.Next(1, 100)), true);
            Peon p2 = new Peon("usuario1@example.com", "Maria Rodriguez", DateTime.Now.AddDays(rnd.Next(1, 100)), false);
            Peon p3 = new Peon("correo2@gmail.com", "Juan Pérez", DateTime.Now.AddDays(rnd.Next(1, 100)), true);
            Peon p4 = new Peon("usuario3@example.com", "Luisa Martinez", DateTime.Now.AddDays(rnd.Next(1, 100)), false);
            Peon p5 = new Peon("correo4@gmail.com", "Ana García", DateTime.Now.AddDays(rnd.Next(1, 100)), true);
            Peon p6 = new Peon("email5@example.com", "Pedro López", DateTime.Now.AddDays(rnd.Next(1, 100)), false);
            Peon p7 = new Peon("correo6@gmail.com", "Laura Fernández", DateTime.Now.AddDays(rnd.Next(1, 100)), true);
            Peon p8 = new Peon("usuario7@example.com", "Diego Sanchez", DateTime.Now.AddDays(rnd.Next(1, 100)), false);
            Peon p9 = new Peon("correo8@gmail.com", "Carolina Gómez", DateTime.Now.AddDays(rnd.Next(1, 100)), true);
            Peon p10 = new Peon("email9@example.com", "Roberto Diaz", DateTime.Now.AddDays(rnd.Next(1, 100)), false);

            AltaEmpleado(p1);
            AltaEmpleado(p2);
            AltaEmpleado(p3);
            AltaEmpleado(p4);
            AltaEmpleado(p5);
            AltaEmpleado(p6);
            AltaEmpleado(p7);
            AltaEmpleado(p8);
            AltaEmpleado(p9);
            AltaEmpleado(p10);


        }

        private void PreCargarAnimales()
        {
            Ovino o1 = new Ovino("123ASD", Sexo.Macho, "Raza1", DateTime.Now, 100, 50, true, 50);
            Ovino o2 = new Ovino("123ASD", Sexo.Macho, "Raza1", DateTime.Now, 100, 50, true, 50);
            Ovino o3 = new Ovino("123ASD", Sexo.Macho, "Raza1", DateTime.Now, 100, 50, true, 50);
            Bovino b1 = new Bovino("456WSD", Sexo.Hembra, "Angus", DateTime.Now, 200, 40, false, Alimentacion.Grano);
            Bovino b2 = new Bovino("456WSD", Sexo.Hembra, "Angus", DateTime.Now, 200, 40, false, Alimentacion.Grano);
            Bovino b3 = new Bovino("456WSD", Sexo.Hembra, "Angus", DateTime.Now, 200, 40, false, Alimentacion.Grano);
            AltaAnimal(o1);
            AltaAnimal(o2);
            AltaAnimal(o3);
            AltaAnimal(b1);
            AltaAnimal(b2);
            AltaAnimal(b3);
        }

        public void AltaAnimal(Animal a)
        {
            _animales.Add(a);
        }
        public void AltaEmpleado(Empleado e) 
        {
            _empleados.Add(e);
        }
        public void AltaTarea(Tarea t)
        {
            _tareas.Add(t);
        }
        public void AltaVacuna(Vacuna v)
        {
            _vacunas.Add(v);
        }

         
        public List<Animal> GetAnimales()
        {
            return _animales;
        }
        public List <Tarea> GetTareas() 
        {   
            return _tareas;
        }
        public List<Empleado> GetEmpleados() 
        {
            return _empleados;
        }
        public List<Vacuna> GetVacunas() 
        {
            return _vacunas;
        }

    }
}
