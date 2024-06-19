using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Animal> _animales { get; } = new List<Animal>();
        private List<Empleado> _empleados { get; } = new List<Empleado>();
        private List<Tarea> _tareas { get; } = new List<Tarea>();
        private List<Potrero> _potreros { get; } = new List<Potrero>();
        private List<Vacuna> _vacunas { get; } = new List<Vacuna>();

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
            
            Capataz c0 = new Capataz("martinooliveri@gmail.com", "HOLA1234@#m", "Martino Oliveri", DateTime.Now.AddYears(-10), 10);

            Peon p1 = new Peon("martinooliveri2@gmail.com", "HOLA1234@#m", "Martino Oliveri", DateTime.Now.AddDays(-10), true);
            Peon p2 = new Peon("usuario1@example.com", "HOLA1234@#m", "Maria Rodriguez", DateTime.Now.AddDays(-10), false);
            Peon p3 = new Peon("correo2@gmail.com", "HOLA1234@#m", "Juan Pérez", DateTime.Now.AddDays(-10), true);
            Peon p4 = new Peon("usuario3@example.com", "HOLA1234@#m", "Luisa Martinez", DateTime.Now.AddDays(-10), false);
            Peon p5 = new Peon("correo4@gmail.com", "HOLA1234@#m", "Ana García", DateTime.Now.AddDays(-10), true);
            Peon p6 = new Peon("email5@example.com", "HOLA1234@#m", "Pedro López", DateTime.Now.AddDays(-10), false);
            Peon p7 = new Peon("correo6@gmail.com", "HOLA1234@#m", "Laura Fernández", DateTime.Now.AddDays(-10), true);
            Peon p8 = new Peon("usuario7@example.com", "HOLA1234@#m", "Diego Sanchez", DateTime.Now.AddDays(-10), false);
            Peon p9 = new Peon("correo8@gmail.com", "HOLA1234@#m", "Carolina Gómez", DateTime.Now.AddDays(-10), true);
            Peon p10 = new Peon("email9@example.com", "HOLA1234@#m", "Roberto Diaz", DateTime.Now.AddDays(-10), false);
            Capataz c1 = new Capataz("federicochaer@example.com", "HOLA1234@#m", "Federico Chaer", new DateTime(2003, 12, 15), 8);
            Capataz c2 = new Capataz("john@example.com", "HOLA1234@#m", "John Doe", new DateTime(2014, 4, 24), 5);
            

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
            
            AltaEmpleado(c0);
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

        //Cortesia de ChatGPT para automatizar la generacion de ID de caravana
        public static string GenerateRandomString(int length)
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            var stringBuilder = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }
            return stringBuilder.ToString();
        }
        private void PreCargarAnimales()
        {
            PreCargarOvinos();
            PreCargarBovinos();

           


            Ovino.PrecioKiloLana = 3.5;
            Ovino.PrecioKiloOvinoEnPie = 2.0;
            Bovino.PrecioKiloBovinoEnPie = 1.7; 

        }
        public void PreCargarOvinos()
        {
            for (int i = 0; i < 150; i++)
            {
                string idCaravana = GenerateRandomString(8);
                Sexo sexo = (i % 2 == 0) ? Sexo.Macho : Sexo.Hembra;
                string raza = "Merino";
                DateTime fechaNacimento = new DateTime(2020, 01, 01);
                double costoAdquisicion = 100;
                double costoAlimentacion = 100;
                double peso = 100;
                bool esHibrido = i % 2 == 0;
                double pesoEstimadoLana = 100;
                Ovino ovino = new Ovino(idCaravana, sexo, raza, fechaNacimento, costoAdquisicion, costoAlimentacion, peso, esHibrido, pesoEstimadoLana);
                AltaAnimal(ovino);
                PreCargarVacunaciones(ovino);
            }
        }

        public void PreCargarBovinos()
        {
            for (int i = 0; i < 15; i++)
            {
                string idCaravana = GenerateRandomString(8);
                Sexo sexo = (i % 2 == 0) ? Sexo.Macho : Sexo.Hembra;
                string raza = "Merino";
                DateTime fechaNacimento = new DateTime(2020, 01, 01);
                double costoAdquisicion = 100;
                double costoAlimentacion = 100;
                double peso = 100;
                bool esHibrido = i % 2 == 0;
                Alimentacion alimentacion = (i % 2 == 0) ? Alimentacion.Grano : Alimentacion.Pastura;
                Bovino bovino = new Bovino(idCaravana, sexo, raza, fechaNacimento, costoAdquisicion, costoAlimentacion, peso, esHibrido, alimentacion);
                AltaAnimal(bovino);
                PreCargarVacunaciones(bovino);
            }
        }

        

        private void PreCargarVacunaciones(Animal a)
        {
            foreach(Vacuna v in _vacunas)
            {
                a.VacunarAnimal(v);
            }
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
            Potrero p2 = new Potrero("Zona de pastoreo cerca del riachuelo", 120.0, 2850);
            Potrero p3 = new Potrero("Área de pasto detrás del granero", 180.2, 2850);
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

        public List<Animal> GetAnimalesLibres()
        {
            List<Animal> resultado = new List<Animal>();
            foreach (Animal a in _animales)
            {
                if(AnimalEstaLibre(a))
                {
                    resultado.Add(a);
                }
            }
            return resultado;
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
                    throw new Exception("Error de registro");
                }
            }
            catch (Exception)
            {
                throw;
            }
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

        public Potrero? GetPotreroPorId(int id)
        {
            foreach (Potrero p in _potreros)
            {
                if (p.Id == id)
                { return p; }
            }
            return null;
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

        public Peon? GetPeon(int id)
        {
            foreach(Peon p in GetPeones())
            {
                if (p.Id == id)
                { return p; }
            }
            return null;
        }

        //se escribe Animal? porque puede devolver null
        public Animal? GetAnimalPorId(int? id) 
        {
            if(id == null) return null;
            foreach(Animal a in _animales)
            {
                if(a.Id == id)
                { return a; }
            }
            return null;
        }
        public Animal? GetAnimalPorNumeroCaravana(string numeroCaravana)
        {

            foreach (Animal a in _animales)
            {
                if (a.NumeroCaravana == numeroCaravana)
                { return a; }
            }
            return null;
        }
        public List<Animal> GetAnimalesPorTipoYPeso(string tipoAnimal, double pesoAnimal)
        {
            List<Animal> animales = new List<Animal>();
            if ((tipoAnimal != "Bovino" && tipoAnimal != "Ovino") || pesoAnimal <= 0) return animales;
            foreach (Animal a in _animales)
            {
                if (a.GetTipo() == tipoAnimal && a.PesoActual > pesoAnimal)
                { animales.Add(a); }
            }
            return animales;
        }

        public Vacuna? GetVacuna(int id)
        {
            foreach (Vacuna v in _vacunas)
            {
                if (v.Id == id)
                { return v; }
            }
            return null;
        }

        public Empleado? GetEmpleadoPorEmail(string email)
        {
            foreach(Empleado e in _empleados)
            {
                if(String.Equals(e.Email, email))
                { return e; }
            }
            return null;
        }

        public Empleado? GetEmpleadoPorId(int id)
        {
            foreach (Empleado e in _empleados)
            {
                if (e.Id == id)
                { return e; }
            }
            return null;
        }

        public bool LoginValido(Empleado e, string email, string contrasenia)
        {
            return e.EmailCorrecto(email) && e.ContraseniaCorrecta(contrasenia); 
        }

       

        public void ValidarEmail(string email)
        {
            bool esValido = true;
            foreach(Empleado e in _empleados)
            {
                if(e.Email == email)
                {
                    esValido = false;
                    break;
                }
            }
            if(!esValido) throw new Exception("Direccion de correo ingresada ya esta asociado a una cuenta");
            return;
        }

        public List<Potrero> GetPotrerosOrdenadosPorCapacidadYCantidad()
        {
            List<Potrero> resultado = GetPotreros();
            resultado.Sort();
            return resultado;
        }
    }
}

