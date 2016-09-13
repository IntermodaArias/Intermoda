using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class OrdenProduccionLavanderiaBusiness
    {
        private static LavanderiaEntities _context;

        #region Propiedades

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public int PlantaId { get; set; }

        [DataMember]
        public int? CentroTrabajoId { get; set; }

        [DataMember]
        public short Ano { get; set; }

        [DataMember]
        public short Numero { get; set; }

        [DataMember]
        public string Patron { get; set; }

        [DataMember]
        public string Variante { get; set; }

        [DataMember]
        public string LavadoCodigoOld { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public DateTime? FechaInicioProgramada { get; set; }

        [DataMember]
        public DateTime? FechaFinalProgramada { get; set; }

        [DataMember]
        public string TelaProduccionCodigo { get; set; }

        [DataMember]
        public string TelaVentaCodigo { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public int? Cantidad { get; set; }

        [DataMember]
        public int? CantidadFinalEnsamble { get; set; }

        [DataMember]
        public int? CantidadEntradaLavanderia2 { get; set; }

        [DataMember]
        public int? CantidadPendiente { get; set; }

        [DataMember]
        public int LavadoId { get; set; }

        [DataMember]
        public string LavadoNombre { get; set; }

        [DataMember]
        public decimal PesoUnidad { get; set; }

        #endregion

        #region Methods

        public static OrdenProduccionLavanderiaBusiness[] Get(short companiaId, int plantaId, short centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return _context.OrdenesProduccionLavanderiaSet
                        .Select(item => new OrdenProduccionLavanderiaBusiness
                        {
                            CompaniaId = item.CompaniaId,
                            PlantaId = item.PlantaCodigo,
                            CentroTrabajoId = item.PrdCtNew,
                            Ano = item.Ano,
                            Numero = item.Numero,
                            Patron = item.Patron,
                            Variante = item.Variante,
                            LavadoCodigoOld = item.CodigoLavadoViejo,
                            Estado = item.PrdStsCor,
                            FechaInicioProgramada = item.InicioProgramado,
                            FechaFinalProgramada = item.FinalProgramado,
                            TelaProduccionCodigo = item.TelaProduccion,
                            TelaVentaCodigo = item.TelaVenta,
                            Usuario = item.Usuario,
                            Cantidad = item.Cantidad,
                            CantidadFinalEnsamble = item.UnidadesTerminadasEnsamble,
                            CantidadEntradaLavanderia2 = item.UnidadesIngresadasLavanderia2,
                            CantidadPendiente = item.UnidadesTerminadasEnsamble - item.UnidadesIngresadasLavanderia2,
                            LavadoId = item.LavadoId ?? 0,
                            LavadoNombre = item.LavadoNombre ?? "-- Aún no definido --"
                        })
                        .Where(r => r.CompaniaId == companiaId)
                        .Where(r => r.PlantaId == plantaId)
                        .Where(r => r.CentroTrabajoId == centroTrabajoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionLavanderiaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}