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
