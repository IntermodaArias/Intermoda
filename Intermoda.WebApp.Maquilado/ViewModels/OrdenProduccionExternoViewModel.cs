using System.ComponentModel.DataAnnotations;

namespace Intermoda.WebApp.Maquilado.ViewModels
{
    public class OrdenProduccionExternoViewModel
    {
        [Display(Name = "Orden de Producción")]
        public string OrdenProduccion { get; set; }

        public string Referencia { get; set; }

        [Display(Name="Color")]
        public string ColorDescripcion { get; set; }
        
        public int Cantidad { get; set; }

        [Display(Name="Tipo")]
        public string SiguienteLecturaTipo { get; set; }

        public string OrdenEstadoDescripcion { get; set; }

        [Display(Name = "Centro Trabajo")]
        public string CentroTrabajoUltimaLecturaNombre { get; set; }

        public string CentroTrabajoSiguienteNombre { get; set; }

        [Display(Name = "Estado")]
        public string EstadoLeyenda { get; set; }
    }
}