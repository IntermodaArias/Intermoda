using System;

namespace Intermoda.Client.LbDatPro
{
    public class MaquiladoTeP
    {
        public Planta Planta { get; set; }
        public CentroTrabajo CentroTrabajo { get; set; }
        public short OrdenAno { get; set; }
        public short OrdenNumero { get; set; }
        public string OrdenProduccion => $"{OrdenNumero.ToString("0000")}-{OrdenAno.ToString("00")}";
        public string Patron { get; set; }
        public string Variante { get; set; }
        public string Tela { get; set; }
        public string Lavado { get; set; }
        public string Color { get; set; }
        public string ColorNombre { get; set; }
        public string Referencia => $"{Patron.Trim()}-{Variante.Trim()}-{Tela.Trim()}-{Lavado.Trim()}-{Color.Trim()}";
        public int Cantidad { get; set; }
        public TimeSpan TiempoProceso { get; set; }
        public TimeSpan TiempoPlanta { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public string Estado { get; set; }
    }
}