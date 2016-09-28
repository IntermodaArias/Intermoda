using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class TrabajoEnProcesoBusiness
    {
        #region Properties

        [DataMember]
        public OrdenProduccionSpBusiness OrdenProduccion { get; set; }

        [DataMember]
        public int EnPlaneacion { get; set; }

        [DataMember]
        public TrabajoEnProcesoDetalleBusiness[] Detalle { get; set; }

        #endregion

        #region Methods

        public static TrabajoEnProcesoBusiness[] GetTeP()
        {
            try
            {
                var centros = CentroTrabajoBusiness.GetAll().ToList();
                var ordenes = OrdenProduccionSpBusiness.Get().ToList();
                var estados = OrdenEstadoBusiness.GetAll().ToList();

                var retorno = new List<TrabajoEnProcesoBusiness>
                {
                    new TrabajoEnProcesoBusiness
                    {
                        OrdenProduccion = null,
                        Detalle = centros.Select(r =>
                            new TrabajoEnProcesoDetalleBusiness
                            {
                                CentroTrabajoId = r.Id,
                                CentroTrabajoNombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                EnEspera = 0,
                                EnProceso = 0
                            }).ToArray()
                    }
                };

                foreach (var orden in ordenes)
                {
                    var enPlaneacion = 0;
                    if (estados.FirstOrDefault(r=>r.Id == orden.EstadoId)?.Secuencia <= 37)
                    {
                        enPlaneacion = 1;
                    }

                    var detalle = centros.Select(centro => new TrabajoEnProcesoDetalleBusiness
                    {
                        CentroTrabajoId = centro.Id,
                        CentroTrabajoNombre = centro.Nombre,
                        Secuencia = centro.Secuencia,
                        EnEspera = 0,
                        EnProceso = 0,
                    }).ToList();

                    var rutaOrden = OrdenProduccionRutaBusiness.GetByOrden(orden.CompaniaId, orden.Ano, orden.Numero);
                    var lecturas = OrdenProduccionLecturaBusiness.GetByOrden(orden.CompaniaId, orden.Ano, orden.Numero);
                    foreach (var paso in rutaOrden)
                    {
                        var lectPaso = lecturas
                            .Where(r => r.CentroTrabajoId == paso.CentroTrabajoId);
                        foreach (var lect in lectPaso)
                        {
                            var salioPrevios = paso.Previos.Select(previo =>
                                lecturas.FirstOrDefault(r => r.CentroTrabajoId == previo &&
                                                             r.Bulto == lect.Bulto))
                                .All(lectPrevio => lectPrevio?.Salida != null);

                            if (!salioPrevios) continue;

                            if (lect.Entrada == null && lect.Salida == null)
                            {
                                var det = detalle.FirstOrDefault(r => r.CentroTrabajoId == lect.CentroTrabajoId);
                                if (det != null)
                                    det.EnEspera += (short) lect.Cantidad;
                            } else if (lect.Entrada != null && lect.Salida == null)
                            {
                                var det = detalle.FirstOrDefault(r => r.CentroTrabajoId == lect.CentroTrabajoId);
                                if (det != null)
                                    det.EnProceso += (short)lect.Cantidad;
                            }
                        }
                    }

                    retorno.Add(new TrabajoEnProcesoBusiness
                    {
                        OrdenProduccion = new OrdenProduccionSpBusiness
                        {
                            CompaniaId = orden.CompaniaId,
                            CompaniaNombre = orden.CompaniaNombre,
                            Ano = orden.Ano,
                            Numero = orden.Numero,
                            Base = orden.Base,
                            Variante = orden.Variante,
                            Tela = orden.Tela,
                            Lavado = orden.Lavado,
                            Color = orden.Color,
                            EstadoId = orden.EstadoId,
                            Usuario = orden.Usuario,
                            Prioriodad = orden.Prioriodad,
                            TelaProduccion = orden.TelaProduccion,
                            Cantidad = orden.Cantidad,
                            ModuloEnsamble = orden.ModuloEnsamble,
                            ConTela = orden.ConTela,
                        },
                        Detalle = detalle.ToArray(),
                        EnPlaneacion = enPlaneacion
                    });
                }
                return retorno.ToArray();
            }
            catch (Exception exception)
            {
                throw new Exception("TrabajoEnProcesoBusiness / Get", exception);
            }
        }

        #endregion
    }

    [DataContract]
    public class TrabajoEnProcesoDetalleBusiness
    {
        [DataMember]
        public string CentroTrabajoId { get; set; }

        [DataMember]
        public string CentroTrabajoNombre { get; set; }

        [DataMember]
        public short Secuencia { get; set; }

        [DataMember]
        public short EnEspera { get; set; }

        [DataMember]
        public short EnProceso { get; set; }
    }
}