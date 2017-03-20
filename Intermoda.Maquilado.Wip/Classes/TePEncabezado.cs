using System;
using System.Collections.Generic;

namespace Intermoda.Maquilado.Wip
{
    public class TePEncabezado
    {
        public string PlantaId { get; set; }
        public string PlantaNombre { get; set; }
        public string OrdenProduccion { get; set; }
        public string Referencia { get; set; }
        public string Color { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public TimeSpan TiempoPlanta { get; set; }
        public List<TePDetalle> Detalle { get; set; }
    }
}