using Dominio;
using System.ComponentModel;
using System.Diagnostics;
using System.Formats.Tar;
using System.Text.RegularExpressions;

namespace IUConsola
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Sistema s = Sistema.GetInstancia();
            string option = " ";
            
            while(option != "0") 
            {
                Console.Clear();
                MostrarOpcionesConsola();
                option = Console.ReadLine();
                Console.Clear();

                switch(option)
                {
                    case "1":
                        MostrarListadoAnimales(s); 
                        break;
                    case "2":
                        MostrarListadosDePotreros(s);
                        break;
                    case "3":
                        CambiarPrecioKiloLanaOvinos(s);
                        break;
                    case "4":
                        AltaGanadoBovino(s);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("\nPor favor ingrese una de las opciones del menu");
                        break;

                }
                Console.WriteLine("\nPresione una tecla para ir al menu");
                Console.ReadKey(true);

            }

        }


        static void MostrarOpcionesConsola()
        {
            Console.WriteLine("***MENU DE LA INSTANCIA***");
            Console.WriteLine("Seleccione una opcion...");
            Console.WriteLine("1 - MOSTRAR LISTADO DE TODOS LOS ANIMALES");
            Console.WriteLine("2 - MOSTRAR POTREROS MAYORES A UN AREA Y CAPACIDAD INGRESADA");
            Console.WriteLine("3 - ASIGNAR PRECIO DE OVINOS POR KG");
            Console.WriteLine("4 - DAR DE ALTA UN BOVINO");
            Console.WriteLine("0 - Salir");
        }

        /*
         * Muestra listado de animales separando por tipo de animal
         */
        static void MostrarListadoAnimales(Sistema s)
        {
            Console.Clear();

            Console.WriteLine("LISTADO DE ANIMALES COMPLETO\n\n");
            if(s.GetOvinos().Count > 0)
            {
                Console.WriteLine("****ANIMALES OVINOS****\n");
                Console.WriteLine("NRO CARAVANA\tRAZA\tPESO(KG)\t SEXO");
                foreach (Ovino o in s.GetOvinos())
                {
                    Console.WriteLine(o.ToString());
                }

            }
            else
            {
                Console.WriteLine("No se encontraron Ovinos");
            }
            if(s.GetBovinos().Count > 0)
            {

                Console.WriteLine("\n\n****ANIMALES BOVINOS****\n");
                Console.WriteLine("NRO CARAVANA\tRAZA\tPESO(KG)\t SEXO");
                foreach (Bovino b in s.GetBovinos())
                {
                    Console.WriteLine(b.ToString());
                }
            }
            else
            {
                Console.WriteLine("No se encontraron Bovinos");
            }
        }


        /**
         * Se pide al usuario dos parametros para buscar los potreros que cumplan con el requerimiento
         */
        static void MostrarListadosDePotreros(Sistema s)
        {
            double hectareas = 0;
            int capacidad = 0;
            try
            {
                Console.WriteLine("LISTADO DE POTREROS\n\n");
                Console.WriteLine("Ingrese una cantidad de hectareas:");
                hectareas = Double.Parse(Console.ReadLine());
                Console.WriteLine("\nIngrese una capacidad maxima (solo valores enteros)");
                capacidad = Int32.Parse(Console.ReadLine());

                List<Potrero> potreros = s.GetPotrerosDeMayorAreaYCapacidad(hectareas, capacidad);
                if(potreros.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("ID\tDESCRIPCION\t\t\tCAPACIDAD\tHECTAREAS");
                    foreach (var p in potreros)
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"No se encontaron potreros con mas de {hectareas} hectareas\n y con capacidad mayor que {capacidad} cabezas de ganado");
                }                
            }
            catch (Exception)
            {
                Console.WriteLine("Por favor ingrese un numero valido");
            }
        }

        static void CambiarPrecioKiloLanaOvinos(Sistema s)
        {
            Console.WriteLine("CAMBIAR PRECIO DEL KILO DE LANA\n\n");
            Console.WriteLine("Precio actual del kilo de lana: "+s.GetPrecioKiloLana() );
            Console.WriteLine("Ingrese un valor:\n");
            try
            {
                double valor = Double.Parse(Console.ReadLine());
                Console.Clear();
                if (valor < 0)
                {
                    Console.WriteLine("No se ingreso un numero valido");
                }
                else
                {
                    s.CambiarPrecioKiloLana(valor);
                    Console.WriteLine("Valor guardado con exito");
                    Console.WriteLine("Precio actual del kilo de lana: " + s.GetPrecioKiloLana());
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("No se ingreso un numero valido");
            }
        }

        

        
        static void AltaGanadoBovino(Sistema s)
        {
            Console.Clear();
            Console.WriteLine("ALTA DE GANADO BOVINO\n\n");
            try
            {
                Console.WriteLine("Ingrese numero de caravana (alfanumerico de 8 digitos)");
                string numeroCaravana = Console.ReadLine();

                Console.WriteLine("Bovino es de sexo macho? (S/N)");
                string esMacho = Console.ReadLine();

                Console.WriteLine("Ingrese la raza del bovino");
                string raza = Console.ReadLine();

                Console.WriteLine("Ingrese la fecha de nacimiento (DDMMAAAA)");
                DateTime.TryParseExact(Console.ReadLine(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaNacimiento);

                Console.WriteLine("Ingrese el costo de adquisicion ($).");
                double costoAdq = Double.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el costo de alimentacion ($).");
                double costoAlimentacion = Double.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el peso actual del animal (KG).");
                double peso = Double.Parse(Console.ReadLine());

                Console.WriteLine("Bovino es hibrido? (S/N)");
                string esHibrido = Console.ReadLine();

                Console.WriteLine("Bovino de alimentacion a grano?");
                string alimentacionGrano = Console.ReadLine();
                

                //
                if (numeroCaravana == null || numeroCaravana.Length != 8 || string.IsNullOrEmpty(raza) || costoAdq < 0 || peso < 0 || (esMacho != "S" && esMacho != "N") || (esHibrido != "S" && esHibrido != "N") || (alimentacionGrano != "S" && alimentacionGrano != "N")) 
                {
                    Console.Clear();
                    Console.WriteLine("Se ingreso un dato invalido o vacio, por favor intentelo nuevamente");   
                }
                else
                {
                    Alimentacion alimentacion = alimentacionGrano == "S" ? Alimentacion.Grano : Alimentacion.Pastura;
                    Sexo sexo = esMacho == "S" ? Sexo.Macho : Sexo.Hembra;
                    Bovino bovino = new Bovino(numeroCaravana, sexo, raza, fechaNacimiento, costoAdq, costoAlimentacion, peso, esHibrido == "S", alimentacion);
                    s.AltaAnimal(bovino);
                    Console.WriteLine("\nBovino ingresado al sistema con exito!\n");
                }


            }
            catch(Exception)
            {
                Console.Clear();
                Console.WriteLine("Se ingreso un dato invalido, por favor intentelo nuevamente");
            }
        }
    }
}
