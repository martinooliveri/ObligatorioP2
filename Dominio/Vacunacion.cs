using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vacunacion
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Vacuna Vacuna { get; set; }
        public DateTime FechaVacunacion { get; set; } = DateTime.Now;
        public DateTime FechaVencimiento { get; set; }


        public Vacunacion()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Vacunacion(Vacuna vacuna)
        {
            Id = UltimoId;
            UltimoId++;
            Vacuna = vacuna;
            FechaVencimiento = FechaVacunacion.AddYears(2);
        }
    }
}
