using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tarea
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
    }
}
