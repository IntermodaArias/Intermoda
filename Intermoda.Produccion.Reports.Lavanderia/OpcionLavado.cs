using System.ComponentModel;

namespace Intermoda.Produccion.Reports.Lavanderia
{
    public class OpcionLavado
    {
        public int LavadoId { get; set; }
        public string LavodoNombre { get; set; }
        public string LavadoDescripcion { get; set; }

        public int ColorId { get; set; }
        public string ColorNombre { get; set; }

        public int OpcionLavadoId { get; set; }
        public string OpcionLavadoNombre { get; set; }
        public string OpcionLavadoDescripcion { get; set; }
        public bool IsDefault { get; set; }

        public string TelaCodigo { get; set; }
        public string TelaNombre { get; set; }
        public string TelaComposicion { get; set; }

        public int CentroTrabajoOpcionId { get; set; }
        public int CentroTrabajoId { get; set; }
        public string CentroTrabajoNombre { get; set; }
        public int CentroTrabajoSecuencia { get; set; }

        public int Proceso { get; set; }
        public int ProcesoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ProcesoSecuencia { get; set; }
        public bool EsObligatorio { get; set; }
        public decimal? TiempoEstandar { get; set; }


    }
}