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
        public DateTime FechaRealizacion { get; set; }
        public bool FueCompletada { get; set; }
        public DateTime FechaDeCierre{ get; set; }
        public string Comentario{ get; set; }


        public Tarea()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Tarea(string descripcion, DateTime fechaRealizacion, bool fueCompletada, DateTime fechaDeCierre, string comentario)
        {
            Id = UltimoId;
            UltimoId++;
            Descripcion = descripcion;
            FechaRealizacion = fechaRealizacion;
            FueCompletada = fueCompletada;
            FechaDeCierre = fechaDeCierre;
            Comentario = comentario;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripcion de la tarea debe existir");
            }
            if(FechaRealizacion > DateTime.Now)
            {
                throw new Exception("La fecha de realizacion tiene que ser anterior a la de ahora");
            }
            /*if(FechaDeCierre < FechaRealizacion)
            {
                throw new Exception ("La fecha de cierre no puede ser anterior a la fecha de inicio");
            }*/
        }




    }
}
