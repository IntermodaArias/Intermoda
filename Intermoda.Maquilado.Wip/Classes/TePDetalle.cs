using System;

namespace Intermoda.Maquilado.Wip
{
    public class TePDetalle
    {
        public string CentroTrabajo { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public TimeSpan TiempoProceso { get; set; } 
    }
}