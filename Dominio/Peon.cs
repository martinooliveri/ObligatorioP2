using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Peon : Empleado, IValidable
    {
        public bool EsResidente { get; set; }
        private List<Tarea> _tareas { get; } = new List<Tarea>();

        public List<Tarea> GetTareas()
        {
            return _tareas;
        }
        public List<Tarea> GetTareasPendientes()
        {
            List<Tarea> resultado = new List<Tarea>();
            foreach(Tarea t in _tareas)
            {
                if(!t.FueCompletada) resultado.Add(t);
            }
            return resultado;
        }
        public Peon(){}

        public Peon(string email, string contrasenia, string nombre, DateTime fechaIngreso, bool esResidente) : base(nombre, email, contrasenia, fechaIngreso)
        {
            EsResidente = esResidente;
        }

        public override void Validar()
        {
            try
            {
                base.Validar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public override string GetTipo()
        {
            return "Peon";
        }

        // el CompareTo se depreca con bases de datos pudiendo ordenar por si mismas las listas,
        // pero con precarga de datos es util (se requiere implementar interfaz de comparacion)
        public int CompareTo(Peon? other)
        {
            return -Nombre.CompareTo(other.Nombre);
        }
    }
    
       
}
