using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions; //para evitar mantener codigo propio de validacion de emails

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

        public Empleado(string nombre, string email, string contrasenia, DateTime fechaIngreso)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
            FechaIngreso = fechaIngreso;
        }

        public virtual void Validar()
        {
            try
            {
                ValidarNombre();
                ValidarEmail(); //validar que no se repita
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


        //Cortesia de chatgpt
        public void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("Contraseña no puede ser vacia.");
            }

            // Largo minimo
            if (Contrasenia.Length < 8 || Contrasenia.Length > 20)
            {
                throw new Exception("La contraseña debe tener 8 caracteres de minimo y 20 de maximo.");
            }

            // Una letra minuscula
            if (!Regex.IsMatch(Contrasenia, "[a-z]"))
            {
                throw new Exception("La contraseña debe tener una letra minuscula.");
            }

            // Una letra mayuscula
            if (!Regex.IsMatch(Contrasenia, "[A-Z]"))
            {
                throw new Exception("La contraseña debe tener una letra mayuscula.");
            }

            // Caracter especial (!@#$%&)
            if (!Regex.IsMatch(Contrasenia, "[!@#$%&]"))
            {
                throw new Exception("La contraseña debe tener un caracter especial: !@#$%&");
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
    /*    public double VueltasAlSolDesdeQueTrabajaEnLaEstancia(DateTime fechaDeIngreso)
    {
        FechaIngreso = fechaDeIngreso;
        int aniosEnLaEstancia = 0;
        if(fechaDeIngreso > DateTime.Today)
        {
            throw new Exception("La fecha de ingreso debe ser anterior a la fecha de hoy");
        }
        aniosEnLaEstancia = FechaIngreso.Year - DateTime.Today.Year;

        return aniosEnLaEstancia;
    }
    */
}
