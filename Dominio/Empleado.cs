using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //para evitar mantener codigo propio de validacion de emails

namespace Dominio
{
    public abstract class Empleado: IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Email { get; set; } = "HOLA123@GMAIL.COM";
        public string Contrasenia { get; set; } = "HOLA1234@#m";
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; } = true;

        public Empleado() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Empleado(string email, string nombre, DateTime fechaIngreso)
        {
            Id = UltimoId;
            UltimoId++;
            Email = email;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
        }

        public virtual void Validar()
        {
            try
            {
                ValidarNombre();
                ValidarEmail();
                ValidarContrasenia();
                ValidarFechaIngreso();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarNombre()
        {
            if(string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }

        private void ValidarFechaIngreso()
        {
            if (FechaIngreso == DateTime.MinValue || FechaIngreso.Year < 1980 || FechaIngreso.Month > 12 || FechaIngreso.Month < 0 || FechaIngreso.Day > 31 || FechaIngreso.Day < 1)
            {
                throw new Exception("Fecha ingresada no es valida");
            }
        }

        public void ValidarContrasenia()
        {
            if (string.IsNullOrWhiteSpace(Contrasenia))
            {
                throw new Exception("La contraseña no puede ser vacía.");
            }

            if (Contrasenia.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            }

            if (!Contrasenia.Any(char.IsUpper))
            {
                throw new Exception("La contraseña debe contener al menos una letra mayúscula.");
            }

            if (!Contrasenia.Any(char.IsLower))
            {
                throw new Exception("La contraseña debe contener al menos una letra minúscula.");
            }

            if (!Contrasenia.Any(char.IsDigit))
            {
                throw new Exception("La contraseña debe contener al menos un dígito.");
            }

            if (!Contrasenia.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new Exception("La contraseña debe contener al menos un carácter especial.");
            }
        }

        private void ValidarEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new Exception("El email no puede ser vacío.");
            }

            EmailAddressAttribute emailAttribute = new EmailAddressAttribute();
            if (!emailAttribute.IsValid(Email))
            {
                throw new Exception("El email no es válido.");
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Empleado empleado &&
                   Id == empleado.Id &&
                   Nombre == empleado.Nombre;
        }

        public bool ContraseniaCorrecta(string contrasenia)
        {
            return Contrasenia == contrasenia;
        }

        public bool EmailCorrecto(string email)
        {
            return Email == email;
        }

        public abstract string GetTipo();
    }
}
