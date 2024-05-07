using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Peon : Empleado
    {
        public bool EsResidente { get; set; }
        public Tarea Tarea { get; set; }
        private List<Tarea> _tareas { get; } = new List<Tarea>();

        public List<Tarea> GetTareas()
        {
            return _tareas;
        }

        public Peon() { }

        public Peon(string email, string nombre, DateTime fechaIngreso, bool esResidente) : base(email, nombre, fechaIngreso)
        {
            EsResidente = esResidente;
        }

        public override void Validar()
        {
            try
            {
                ValidarEmail();
                ValidarNombre();
                ValidarContrasenia();
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("La direccion de correo eletronico no puede estar vacia");
            }
            if (!Email.Contains('@') || !Email.Contains('.'))
            {
                throw new Exception("La direccion de correo electronico no es valida");
            }
        }
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }
        private void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("La contraseña debe existir");
            }
        }
        // el CompareTo se depreca con bases de datos pudiendo ordenar por si mismas las listas,
        // pero con precarga de datos es util (se requiere implementar interfaz de comparacion)
        public int CompareTo(Peon? other)
        {
            return -Nombre.CompareTo(other.Nombre);
        }
    }
    
       
}
