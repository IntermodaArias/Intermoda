using System;
using System.Runtime.Serialization;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class MaquiladoTrabajoEnProceso
    {
        [DataMember]
        public PlantaBusiness Planta { get; set; }
        [DataMember]
        public CentroTrabajoBusiness CentroTrabajo { get; set; }
        [DataMember]
        public short OrdenAno { get; set; }
        [DataMember]
        public short OrdenNumero { get; set; }
        //[DataMember]
        //public string OrdenProduccion => $"{OrdenNumero.ToString("0000")}-{OrdenNumero.ToString("00")}";
        [DataMember]
        public string Patron { get; set; }
        [DataMember]
        public string Variante { get; set; }
        [DataMember]
        public string Tela { get; set; }
        [DataMember]
        public string Lavado { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string ColorNombre { get; set; }
        //[DataMember]
        //public string Referencia => $"{Patron.Trim()}-{Variante.Trim()}-{Tela.Trim()}-{Lavado.Trim()}-{Color.Trim()}";
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public TimeSpan TiempoProceso { get; set; }
        [DataMember]
        public TimeSpan TiempoPlanta { get; set; }
        [DataMember]
        public DateTime? Entrada { get; set; }
        [DataMember]
        public DateTime? Salida { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}