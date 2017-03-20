using System;

namespace Intermoda.Client.LbDatPro
{
    public class MaquiladoLeadTime
    {
        public string Planta { get; set; }
        public int Secuencia { get; set; }
        public string CentroTrabajo { get; set; }
        public string OrdenProduccion { get; set; }
        public string Referencia { get; set; }
        public int Cantidad { get; set; }
        public TimeSpan? TiempoEnProceso { get; set; }
        public TimeSpan? TiempoEnPlanta { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public string Estado { get; set; }
    }
}