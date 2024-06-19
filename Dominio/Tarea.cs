using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tarea : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Descripcion { get; set; }
        public DateTime FechaRealizacion { get; set; } //se asume que esta es la fecha maxima para realizar la tarea
        public bool FueCompletada { get; set; }
        public DateTime FechaDeCierre{ get; set; } //se asume que esta es la fecha en la que se cierre la tarea
        public string Comentario{ get; set; }


        public Tarea()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Tarea(string descripcion, DateTime fechaRealizacion)
        {
            Id = UltimoId;
            UltimoId++;
            Descripcion = descripcion;
            FechaRealizacion = fechaRealizacion;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripcion de la tarea no puede estar vacia");
            }
            if(FechaRealizacion <= DateTime.Now)
            {
                throw new Exception("Fecha de realizacion invalida. Debe ser mayor que fecha actual");
            }
        }
        public void CerrarTarea(string comentario)
        {
            if ( FueCompletada == false ) 
            { 
                FueCompletada = true;
                Comentario = comentario;
                FechaDeCierre = DateTime.Now;
            }
        }
    }
}
