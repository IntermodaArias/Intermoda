using System;
using System.Collections.Generic;
using Intermoda.Business.LbDatPro;

namespace Intermoda.Produccion.Planeacion.DataService
{
    public class DesignDataService : IDataService
    {
        public void TrabajoEnProcesoGet(Action<List<TrabajoEnProcesoBusiness>, Exception> action)
        {
            try
            {
                var resp = new List<TrabajoEnProcesoBusiness>();
                for (var i = 1; i < 41; i++)
                {
                    var detalle = new List<TrabajoEnProcesoDetalleBusiness>();
                    for (var j = 1; j < 31; j++)
                    {
                        detalle.Add(GetDetalle());
                    }
                    resp.Add(new TrabajoEnProcesoBusiness
                    {
                        OrdenProduccion = GetOrden(),
                        Detalle = detalle.ToArray()
                    });
                }
                action(resp, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        private OrdenProduccionSpBusiness GetOrden()
        {
            return new OrdenProduccionSpBusiness
            {
                CompaniaId = 1,
                CompaniaNombre = "Intermoda, S.A. de C.V.",
                Ano = 2016,
                Numero = 1234,
                Base = "VI812",
                Variante = "VAR",
                Tela = "TEL",
                Lavado = "LAV",
                Color = "COL",
                EstadoId = "Z",
                Usuario = "USUARIO",
                Prioriodad = 10,
                TelaProduccion = "TPR",
                Cantidad = 1234,
                ModuloEnsamble = 1,
                ConTela = true
            };
        }

        private TrabajoEnProcesoDetalleBusiness GetDetalle()
        {
            return new TrabajoEnProcesoDetalleBusiness
            {
                CentroTrabajoId = "01",
                CentroTrabajoNombre = "Centro de Trabajo",
                Secuencia = 10,
                EnEspera = 100,
                EnProceso = 100
            };
        }
    }
}