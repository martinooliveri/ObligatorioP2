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

        public static Sistema GetInstancia()
        {
            return _instancia ??= new Sistema();
        }

        #region PRECARGA_DE_DATOS
        private void PrecargarDatos()
        {
            PreCargarEmpleados();
            foreach(Peon p in GetPeones())
            {
                PreCargarTareas(p);
            }
            PreCargarAnimales();
            PreCargarVacunas();
            PreCargarPotreros();
        }

        private void PreCargarEmpleados()
        {
            
            
            Peon p1 = new Peon("martinooliveri@gmail.com", "Martino Oliveri", DateTime.Now.AddDays(-10), true);
            Peon p2 = new Peon("usuario1@example.com", "Maria Rodriguez", DateTime.Now.AddDays(-10), false);
            Peon p3 = new Peon("correo2@gmail.com", "Juan Pérez", DateTime.Now.AddDays(-10), true);
            Peon p4 = new Peon("usuario3@example.com", "Luisa Martinez", DateTime.Now.AddDays(-10), false);
            Peon p5 = new Peon("correo4@gmail.com", "Ana García", DateTime.Now.AddDays(-10), true);
            Peon p6 = new Peon("email5@example.com", "Pedro López", DateTime.Now.AddDays(-10), false);
            Peon p7 = new Peon("correo6@gmail.com", "Laura Fernández", DateTime.Now.AddDays(-10), true);
            Peon p8 = new Peon("usuario7@example.com", "Diego Sanchez", DateTime.Now.AddDays(-10), false);
            Peon p9 = new Peon("correo8@gmail.com", "Carolina Gómez", DateTime.Now.AddDays(-10), true);
            Peon p10 = new Peon("email9@example.com", "Roberto Diaz", DateTime.Now.AddDays(-10), false);
            Capataz c1 = new Capataz("federicochaer@example.com", "Federico Chaer", new DateTime(2003, 12, 15), 8);
            Capataz c2 = new Capataz("john@example.com", "John Doe", new DateTime(2014, 4, 24), 5);
            

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

            AltaEmpleado(c1);
            AltaEmpleado(c2);
        }
        private void PreCargarTareas(Peon p)
        {

            //se utiliza el ID del peon para ir corriendo los dias, garantizando tareas distintas
            Tarea t1 = new Tarea("Barrer el piso",DateTime.Now.AddDays(p.Id));
            Tarea t2 = new Tarea("Limpiar ventanas", DateTime.Now.AddDays(p.Id));
            Tarea t3 = new Tarea("Podar arbustos", DateTime.Now.AddDays(p.Id));
            Tarea t4 = new Tarea("Regar plantas", DateTime.Now.AddDays(p.Id));
            Tarea t5 = new Tarea("Pintar paredes", DateTime.Now.AddDays(p.Id));
            Tarea t6 = new Tarea("Reparar techo", DateTime.Now.AddDays(p.Id));
            Tarea t7 = new Tarea("Cortar césped", DateTime.Now.AddDays(p.Id));
            Tarea t8 = new Tarea("Arreglar cercas", DateTime.Now.AddDays(p.Id));
            Tarea t9 = new Tarea("Lavar vehículos", DateTime.Now.AddDays(p.Id));
            Tarea t10 = new Tarea("Alimentar animales", DateTime.Now.AddDays(p.Id));
            Tarea t11 = new Tarea("Mantener canales de riego", DateTime.Now.AddDays(p.Id));
            Tarea t12 = new Tarea("Reparar caminos rurales", DateTime.Now.AddDays(p.Id));
            Tarea t13 = new Tarea("Cosechar cultivos", DateTime.Now.AddDays(p.Id));
            Tarea t14 = new Tarea("Construir infraestructura comunitaria", DateTime.Now.AddDays(p.Id));
            Tarea t15 = new Tarea("Realizar levantamientos topográficos", DateTime.Now.AddDays(p.Id));

            AltaTarea(t1);
            AltaTarea(t2);
            AltaTarea(t3);
            AltaTarea(t4);
            AltaTarea(t5);
            AltaTarea(t6);
            AltaTarea(t7);
            AltaTarea(t8);
            AltaTarea(t9);
            AltaTarea(t10);
            AltaTarea(t11);
            AltaTarea(t12);
            AltaTarea(t13);
            AltaTarea(t14);
            AltaTarea(t15);

            AddTareaToPeon(t1, p);
            AddTareaToPeon(t2, p);
            AddTareaToPeon(t3, p);
            AddTareaToPeon(t4, p);
            AddTareaToPeon(t5, p);
            AddTareaToPeon(t6, p);
            AddTareaToPeon(t7, p);
            AddTareaToPeon(t8, p);
            AddTareaToPeon(t9, p);
            AddTareaToPeon(t10, p);
            AddTareaToPeon(t11, p);
            AddTareaToPeon(t12, p);
            AddTareaToPeon(t13, p);
            AddTareaToPeon(t14, p);
            AddTareaToPeon(t15, p);
        }
        private void PreCargarAnimales()
        {
            Ovino o1 = new Ovino("1A2B3C4D", Sexo.Macho, "Merino", new DateTime(2023, 4, 15), 100.0, 50.0, true, 50.0);
            Ovino o2 = new Ovino("5E6F7G8H", Sexo.Hembra, "Suffolk", new DateTime(2023, 5, 20), 110.0, 55.0, false, 52.0);
            Ovino o3 = new Ovino("9I1J2K3L", Sexo.Macho, "Dorper", new DateTime(2023, 6, 10), 120.0, 52.0, true, 55.0);
            Ovino o4 = new Ovino("4M5N6O7P", Sexo.Hembra, "Cheviot", new DateTime(2023, 7, 5), 105.0, 48.0, false, 48.0);
            Ovino o5 = new Ovino("8Q9R1S2T", Sexo.Macho, "Lincoln", new DateTime(2023, 8, 12), 115.0, 53.0, true, 58.0);
            Ovino o6 = new Ovino("3U4V5W6X", Sexo.Hembra, "Cotswold", new DateTime(2023, 9, 18), 125.0, 57.0, false, 60.0);
            Ovino o7 = new Ovino("7Y8Z9A1B", Sexo.Macho, "Romney", new DateTime(2023, 10, 25), 130.0, 60.0, true, 62.0);
            Ovino o8 = new Ovino("C3D4E5F6", Sexo.Hembra, "Corriedale", new DateTime(2023, 11, 8), 95.0, 45.0, false, 45.0);
            Ovino o9 = new Ovino("G7H8I9J1", Sexo.Macho, "Border Leicester", new DateTime(2023, 12, 14), 105.0, 48.0, true, 48.0);
            Ovino o10 = new Ovino("K2L3M4N5", Sexo.Hembra, "Dorset Horn", new DateTime(2024, 1, 7), 110.0, 50.0, false, 50.0);
            Ovino o11 = new Ovino("O6P7Q8R9", Sexo.Macho, "Hampshire", new DateTime(2024, 2, 22), 120.0, 55.0, true, 55.0);
            Ovino o12 = new Ovino("S1T2U3V4", Sexo.Hembra, "Oxford Down", new DateTime(2024, 3, 11), 125.0, 57.0, false, 57.0);
            Ovino o13 = new Ovino("W5X6Y7Z8", Sexo.Macho, "Shetland", new DateTime(2024, 4, 3), 100.0, 48.0, true, 48.0);
            Ovino o14 = new Ovino("A1B2C3D4", Sexo.Hembra, "Southdown", new DateTime(2024, 5, 29), 115.0, 53.0, false, 53.0);
            Ovino o15 = new Ovino("E5F6G7H8", Sexo.Macho, "Targhee", new DateTime(2024, 6, 20), 105.0, 49.0, true, 49.0);
            Bovino b1 = new Bovino("1A2B3C44", Sexo.Macho, "Angus", new DateTime(2023, 4, 15), 200.0, 40.0, false, Alimentacion.Grano);
            Bovino b2 = new Bovino("5E6F7G84", Sexo.Hembra, "Hereford", new DateTime(2023, 5, 20), 210.0, 45.0, true, Alimentacion.Pastura);
            Bovino b3 = new Bovino("9I1J2K4L", Sexo.Macho, "Limousin", new DateTime(2023, 6, 10), 220.0, 42.0, false, Alimentacion.Grano);
            Bovino b4 = new Bovino("4M5N6O4P", Sexo.Hembra, "Charolais", new DateTime(2023, 7, 5), 205.0, 38.0, true, Alimentacion.Pastura);
            Bovino b5 = new Bovino("8Q9R1S4T", Sexo.Macho, "Simmental", new DateTime(2023, 8, 12), 215.0, 43.0, false, Alimentacion.Grano);
            Bovino b6 = new Bovino("3U4V5W4X", Sexo.Hembra, "Gelbvieh", new DateTime(2023, 9, 18), 230.0, 47.0, true, Alimentacion.Pastura);
            Bovino b7 = new Bovino("7Y8Z9A4B", Sexo.Macho, "Brangus", new DateTime(2023, 10, 25), 225.0, 44.0, false, Alimentacion.Grano);
            Bovino b8 = new Bovino("C3D4E546", Sexo.Hembra, "Santa Gertrudis", new DateTime(2023, 11, 8), 210.0, 40.0, true, Alimentacion.Pastura);
            Bovino b9 = new Bovino("G7H8I441", Sexo.Macho, "Brahman", new DateTime(2023, 12, 14), 240.0, 48.0, false, Alimentacion.Grano);
            Bovino b10 = new Bovino("K2L344N5", Sexo.Hembra, "Angus", new DateTime(2024, 1, 7), 250.0, 50.0, true, Alimentacion.Pastura);
            Bovino b11 = new Bovino("O6P748R9", Sexo.Macho, "Hereford", new DateTime(2024, 2, 22), 260.0, 55.0, false, Alimentacion.Grano);
            Bovino b12 = new Bovino("S1T243V4", Sexo.Hembra, "Limousin", new DateTime(2024, 3, 11), 270.0, 58.0, true, Alimentacion.Pastura);
            Bovino b13 = new Bovino("W5X647Z8", Sexo.Macho, "Charolais", new DateTime(2024, 4, 3), 280.0, 60.0, false, Alimentacion.Grano);
            Bovino b14 = new Bovino("A1B243D4", Sexo.Hembra, "Simmental", new DateTime(2024, 5, 29), 290.0, 65.0, true, Alimentacion.Pastura);
            Bovino b15 = new Bovino("E5F647H8", Sexo.Macho, "Gelbvieh", new DateTime(2024, 6, 20), 300.0, 70.0, false, Alimentacion.Grano);
            AltaAnimal(o1);
            AltaAnimal(o2);
            AltaAnimal(o3);
            AltaAnimal(o4);
            AltaAnimal(o5);
            AltaAnimal(o6);
            AltaAnimal(o7);
            AltaAnimal(o8);
            AltaAnimal(o9);
            AltaAnimal(o10);
            AltaAnimal(o11);
            AltaAnimal(o12);
            AltaAnimal(o13);
            AltaAnimal(o14);
            AltaAnimal(o15);
            AltaAnimal(b1);
            AltaAnimal(b2);
            AltaAnimal(b3);
            AltaAnimal(b4);
            AltaAnimal(b5);
            AltaAnimal(b6);
            AltaAnimal(b7);
            AltaAnimal(b8);
            AltaAnimal(b9);
            AltaAnimal(b10);
            AltaAnimal(b11);
            AltaAnimal(b12);
            AltaAnimal(b13);
            AltaAnimal(b14);
            AltaAnimal(b15);

            Vacuna v1 = new Vacuna("Rabia", "Vacuna contra la rabia en animales", "Virus de la rabia");
            Vacuna v2 = new Vacuna("Moquillo", "Vacuna para prevenir el moquillo en perros", "Virus del moquillo canino");
            Vacuna v3 = new Vacuna("Parvovirus", "Vacuna contra el parvovirus en cachorros", "Parvovirus canino");

            o1.VacunarAnimal(v1);
            o2.VacunarAnimal(v2);
            b1.VacunarAnimal(v3);

            Bovino.PrecioKiloBovinoEnPie = 20;

        }

        private void PreCargarVacunas()
        {
            Vacuna v1 = new Vacuna("Rabia", "Vacuna contra la rabia en animales", "Virus de la rabia");
            Vacuna v2 = new Vacuna("Moquillo", "Vacuna para prevenir el moquillo en perros", "Virus del moquillo canino");
            Vacuna v3 = new Vacuna("Parvovirus", "Vacuna contra el parvovirus en cachorros", "Parvovirus canino");
            Vacuna v4 = new Vacuna("Leptospirosis", "Vacuna contra la leptospirosis en ganado", "Leptospira interrogans");
            Vacuna v5 = new Vacuna("Coronavirus", "Vacuna para proteger contra el coronavirus felino", "Coronavirus felino");
            Vacuna v6 = new Vacuna("Clostridiosis", "Vacuna contra la clostridiosis en ovejas", "Clostridium perfringens");
            Vacuna v7 = new Vacuna("Panleucopenia", "Vacuna para prevenir la panleucopenia en gatos", "Parvovirus felino");
            Vacuna v8 = new Vacuna("Bronquitis", "Vacuna contra la bronquitis infecciosa en aves", "Virus de la bronquitis infecciosa aviar");
            Vacuna v9 = new Vacuna("Gripe Aviar", "Vacuna contra la gripe aviar en aves de corral", "Virus de la gripe aviar H5N1");
            Vacuna v10 = new Vacuna("Pasteurelosis", "Vacuna para prevenir la pasteurelosis en conejos", "Pasteurella multocida");

            AltaVacuna(v1);
            AltaVacuna(v2);
            AltaVacuna(v3);
            AltaVacuna(v4);
            AltaVacuna(v5);
            AltaVacuna(v6);
            AltaVacuna(v7);
            AltaVacuna(v8);
            AltaVacuna(v9);
            AltaVacuna(v10);


        }
        private void PreCargarPotreros()
        {
            Potrero p1 = new Potrero("Pastizal en la entrada norte", 150.5, 2850);
            Potrero p2 = new Potrero("Zona de pastoreo cerca del riachuelo", 120.0, 2000);
            Potrero p3 = new Potrero("Área de pasto detrás del granero", 180.2, 3200);
            Potrero p4 = new Potrero("Pastizales en la ladera este", 135.8, 2500);
            Potrero p5 = new Potrero("Terreno de pastoreo junto al bosque", 165.3, 3000);
            Potrero p6 = new Potrero("Área de pasto al sur del corral", 140.7, 2700);
            Potrero p7 = new Potrero("Pastizal en la cima de la colina", 155.6, 2900);
            Potrero p8 = new Potrero("Zona de pastoreo cerca del arroyo", 128.4, 2300);
            Potrero p9 = new Potrero("Área de pasto en la parte trasera de la propiedad", 170.9, 3100);
            Potrero p10 = new Potrero("Pastizal en la entrada sur", 145.1, 2600);
            AltaPotrero(p1);
            AltaPotrero(p2);
            AltaPotrero(p3);
            AltaPotrero(p4);
            AltaPotrero(p5);
            AltaPotrero(p6);
            AltaPotrero(p7);
            AltaPotrero(p8);
            AltaPotrero(p9);
            AltaPotrero(p10);
            foreach (Animal a in GetAnimales())
            {
                AddAnimalToPotrero(a, p1);
            }


        }

        #endregion

        public void CambiarPrecioKiloLana(double valor)
        {
            Ovino.CambiarValorKiloLana(valor);
        }

        public double GetPrecioKiloLana()
        {
            return Ovino.PrecioKiloLana;
        }

        public void AddTareaToPeon(Tarea t, Peon p)
        {
            try
            {
                t.Validar();
                p.GetTareas().Add(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //agrega un animal al potrero si y solo si el animal esta libre y no excede la capacidad maxima del potrero
        public void AddAnimalToPotrero(Animal a, Potrero p)
        {
            try
            {
                a.Validar();
                if (!AnimalEstaLibre(a))
                {
                    throw new Exception("Animal no esta libre");
                }
                if (p.GetCantidadAnimales() == p.CapacidadMaxima)
                {
                    throw new Exception("Capacidad maxima");
                }
                p.GetAnimales().Add(a);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //fue necesario implementar Equals en la clase Animal para usar Contains() 
        public bool AnimalEstaLibre(Animal a)
        {
            bool estaLibre = true;
            foreach (Potrero p in _potreros)
            {
                if (p.GetAnimales().Contains(a))
                {
                    estaLibre = false;
                    break;
                }
            }
            return estaLibre;
        }
        

        public void AltaAnimal(Animal a)
        {
            try
            {
                a.Validar();
                if (!_animales.Contains(a))
                {
                    _animales.Add(a);
                }
                else
                {
                    throw new Exception("Animal ya existe; no fue guardado");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AltaEmpleado(Empleado e)
        {
            try
            {
                e.Validar();
                if (!_empleados.Contains(e))
                {
                    _empleados.Add(e);
                }
                else
                {
                    throw new Exception("Empleado ya existe; no fue guardado");
                }

            }
            catch (Exception)
            {

                throw;
            }
            _empleados.Add(e);
        }
        public void AltaPotrero(Potrero p)
        {
            try
            {
                p.Validar();
                if (!_potreros.Contains(p))
                {
                    _potreros.Add(p);
                }
                else
                {
                    throw new Exception("Potrero ya existe; no fue guardado");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AltaTarea(Tarea t)
        {
            try
            {
                t.Validar();
                if (!_tareas.Contains(t))
                {
                    _tareas.Add(t);
                }
                else
                {
                    throw new Exception("Tarea ya existe; no fue guardada");
                }

            }
            catch (Exception)
            {

                throw;
            }
            _tareas.Add(t);
        }
        public void AltaVacuna(Vacuna v)
        {
            try
            {
                v.Validar();
                if (!_vacunas.Contains(v))
                {
                    _vacunas.Add(v);
                }
                else
                {
                    throw new Exception("Vacuna ya existe; no fue guardada");
                }
            }
            catch (Exception)
            {
                throw;
            }
            _vacunas.Add(v);
        }

        public List<Animal> GetAnimales()
        {
            return _animales;
        }
        public List<Ovino> GetOvinos() 
        {
            List<Ovino> ovinos = new List<Ovino>();
            foreach (Animal a in GetAnimales())
            {
                if (a is Ovino ovino)
                {
                    ovinos.Add(ovino);
                }
            }
            return ovinos;
        }
        public List<Bovino> GetBovinos() 
        {
            List<Bovino> bovinos = new List<Bovino>();
            foreach(Animal a in GetAnimales())
            {
                if(a is Bovino bovino)
                {
                    bovinos.Add(bovino);
                }
            }
            return bovinos;
        }
        public List<Tarea> GetTareas()
        {
            return _tareas;
        }
        public  List<Potrero> GetPotreros()
        {
            return _potreros;
        }

        public List<Potrero> GetPotrerosDeMayorAreaYCapacidad(double hectareas, int capacidad)
        {
            List<Potrero> potreros = new List<Potrero>();
            foreach (Potrero p in GetPotreros())
            {
                if (p.Hectareas >= hectareas && p.CapacidadMaxima >= capacidad)
                {
                    {
                        potreros.Add(p);
                    }
                }
            }
            return potreros;
        }
        public List<Empleado> GetEmpleados()
        {
            return _empleados;
        }
        public List<Peon> GetPeones()
        {
            List<Peon> peones = new List<Peon>();
            foreach (Empleado e in GetEmpleados())
            {
                if (e is Peon peon)
                {
                    peones.Add(peon);
                }
            }
            return peones;
        }
        public List<Capataz> GetCapataces()
        {
            List<Capataz> capataces = new List<Capataz>();
            foreach(Empleado e in GetEmpleados()) 
            {
                if(e is Capataz capataz)
                {
                    capataces.Add(capataz);
                }
            }
            return capataces;
        }
        public List<Vacuna> GetVacunas()
        {
            return _vacunas;
        }
        //Es necesario implementar la interfaz IComparable para usar Sort()
        public List<Peon> GetPeonesOrdenadosPorNombre()
        {
            List<Peon> peones = GetPeones();
            peones.Sort();
            return peones;
        }
    }
}

