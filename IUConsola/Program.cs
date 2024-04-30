using Dominio;

namespace IUConsola
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("***MENU DE LA INSTANCIA***");
            Console.WriteLine("1.-MOSTRAR EL LISTADO DE TODOS LOS ANIMALES");
            Console.WriteLine("2.-MOSTRAR LOS POTREROS ");
            Console.WriteLine("3.-ASIGNAR PRECIO DE OVINOS POR KG");
            Console.WriteLine("4.-DAR DE ALTA UN BOVINO");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine();
            } 
            if (option == "2")
            {
                List<Potrero> _potreros = Sistema._potreros;

                // mostrar el display de la lista de potreros con un Console.WriteLine()
                Console.WriteLine("Lista de Potreros:");
                foreach (var potrero in _potreros)
                {
                    Console.WriteLine("ID: {potrero.Id}, Descripcion: {potrero.Descripcion}, Capacidad: {potrero.CapacidadMaxima}, Hectareas: {potrero.Hectareas");
                }
                

            }
            if(option == "3")
            {
                Console.WriteLine();
            }
            if( option == "4")
            {
                Console.WriteLine("Escriba un numero de caravana.");
                string numeroCaravana = Console.ReadLine();
                Console.WriteLine("Escriba un sexo entre MACHO/HEMBRA.");
                Sexo sexo;
                if (!Enum.TryParse(Console.ReadLine(), true, out sexo))
                {
                    Console.WriteLine("Sexo inválido. Por favor, escriba MACHO o HEMBRA.");
                };
                Console.WriteLine("Escriba una raza de bovino.");
                string raza = Console.ReadLine();
                Console.WriteLine("Escriba la fecha de nacimiento.");
                DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());  
                Console.WriteLine("Escriba el costo de adquisicion.");
                double costoAdq = double.Parse(Console.ReadLine());
                Console.WriteLine("Escriba el peso del animal.");
                double peso = double.Parse(Console.ReadLine());
                Console.WriteLine("Escriba si es hibrido o no S/N.");
                bool hibrido = false;
                if(Console.ReadLine() == "S") 
                {
                    hibrido = true;
                }
                if(Console.ReadLine() == "N")
                {
                    hibrido = false;
                }
                Console.WriteLine("Escriba la alimentacion si Grano o Pastura");
                Alimentacion alimentacion;
                if (!Enum.TryParse(Console.ReadLine(), true, out alimentacion))
                {
                    Console.WriteLine("Alimentacián inválida ingrese Grano o Pastura");
                }
                Bovino b16 = new Bovino(numeroCaravana, Sexo.Macho, raza, fechaNacimiento, costoAdq, peso, hibrido, alimentacion);
            };
            
            Console.ReadKey();
        }

        static void AltaBovino()
        {
            Console.Clear();
            Console.WriteLine("SISTEMA ALTA DE GANADO BOVINO\n\n");
            try
            {
                Console.WriteLine("Ingrese numero de carvana (alfanumerico de 8 digitos)");
                string numeroCaravana = Console.ReadLine();
                Console.WriteLine("Ternero es de sexo macho? (S/N)");
                string esMacho = Console.ReadLine();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
