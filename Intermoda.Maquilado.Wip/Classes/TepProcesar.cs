using System.Collections.Generic;
using Intermoda.Client.LbDatPro;

namespace Intermoda.Maquilado.Wip
{
    public static class TepProcesar
    {
        public static List<TePEncabezado> Procesar(List<MaquiladoTeP> input)
        {
            var lista = new List<TePEncabezado>();
            var ini = false;
            var ordenProduccion = "";
            var enc = new TePEncabezado();
            var det = new List<TePDetalle>();
            foreach (var item in input)
            {
                if (!ini)
                {
                    enc = new TePEncabezado
                    {
                        PlantaId = item.Planta.Id,
                        PlantaNombre = item.Planta.Descripcion,
                        OrdenProduccion = item.OrdenProduccion,
                        Referencia = item.Referencia,
                        Cantidad = item.Cantidad,
                        Color = item.ColorNombre,
                        Estado = item.Estado,
                        TiempoPlanta = item.TiempoPlanta,
                        Detalle = new List<TePDetalle>()
                    };

                    ini = true;
                    ordenProduccion = item.OrdenProduccion;
                }

                if (ordenProduccion != item.OrdenProduccion)
                {
                    enc.Detalle = det;
                    lista.Add(enc);

                    enc = new TePEncabezado
                    {
                        PlantaId = item.Planta.Id,
                        PlantaNombre = item.Planta.Descripcion,
                        OrdenProduccion = item.OrdenProduccion,
                        Referencia = item.Referencia,
                        Cantidad = item.Cantidad,
                        Color = item.ColorNombre,
                        Estado = item.Estado,
                        TiempoPlanta = item.TiempoPlanta,
                        Detalle = new List<TePDetalle>()
                    };
                    det = new List<TePDetalle>();
                    ordenProduccion = item.OrdenProduccion;
                }

                det.Add(new TePDetalle
                {
                    CentroTrabajo = item.CentroTrabajo.Nombre,
                    Entrada = item.Entrada,
                    Salida = item.Salida,
                    TiempoProceso = item.TiempoProceso
                });
            }
            enc.Detalle = det;
            lista.Add(enc);

            return lista;
        }
    }
}