using System;
using System.Collections.Generic;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;
using lb = Intermoda.Client.LbDatPro;
using lv = Intermoda.Produccion.Lecturas.Client.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Client.DataServices
{
    public class DesignDataService : IDataService
    {
        #region Lavanderia

        #region CentroTrabajo

        public void LavanderiaCentroTrabajoUpdate(lv.CentroTrabajo centroTrabajo,
            Action<lv.CentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaCentroTrabajoDelete(int centroTrabajoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaCentroTrabajoGet(int centroTrabajoId, Action<lv.CentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaCentroTrabajoGetAll(Action<List<lv.CentroTrabajo>, Exception> action)
        {
            var lista = new List<lv.CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.CentroTrabajo
                {
                    Codigo = i,
                    Nombre = $"Centro de Trabajo No. {i.ToString("000000")}",
                    Orden = i * 10,
                    Observacion = $"Observaciones del Centro de Trabajo No. {i.ToString("000000")}",
                    EsObligatorio = true,
                    EsActivo = true
                });
            }
            action(lista, null);
        }

        public void LavanderiaCentroTrabajoGetActivos(Action<List<lv.CentroTrabajo>, Exception> action)
        {
            var lista = new List<lv.CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.CentroTrabajo
                {
                    Codigo = i,
                    Nombre = $"Centro de Trabajo No. {i.ToString("000000")}",
                    Orden = i * 10,
                    Observacion = $"Observaciones del Centro de Trabajo No. {i.ToString("000000")}",
                    EsObligatorio = true,
                    EsActivo = true
                });
            }
            action(lista, null);
        }

        public void LavanderiaCentroTrabajoGetByOperacion(int operacionId, Action<List<lv.CentroTrabajo>, Exception> action)
        {
            var lista = new List<lv.CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.CentroTrabajo
                {
                    Codigo = i,
                    Nombre = $"Centro de Trabajo No. {i.ToString("000000")}",
                    Orden = i * 10,
                    Observacion = $"Observaciones del Centro de Trabajo No. {i.ToString("000000")}",
                    EsObligatorio = true,
                    EsActivo = true
                });
            }
            action(lista, null);
        }

        public void LavanderiaCentroTrabajoGetAllLavanderia(Action<List<lv.CentroTrabajo>, Exception> action)
        {
            var lista = new List<lv.CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.CentroTrabajo
                {
                    Codigo = i,
                    Nombre = $"Centro de Trabajo No. {i.ToString("000000")}",
                    Orden = i * 10,
                    Observacion = $"Observaciones del Centro de Trabajo No. {i.ToString("000000")}",
                    EsObligatorio = true,
                    EsActivo = true
                });
            }
            action(lista, null);
        }

        #endregion

        #region Proceso

        public  void LavanderiaProcesoUpdate(lv.Proceso proceso, Action<lv.Proceso, Exception> action)
        {
            throw new NotImplementedException();
        }

        public  void LavanderiaProcesoDelete(int procesoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public  void LavanderiaProcesoGet(int procesoId, Action<lv.Proceso, Exception> action)
        {
            throw new NotImplementedException();
        }

        public  void LavanderiaProcesoGetAll(Action<List<lv.Proceso>, Exception> action)
        {
            var lista = new List<lv.Proceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.Proceso
                {
                    Id = i,
                    Nombre = $"Proceso No. {i.ToString("000000")}",
                    Descripcion = $"Descripción del Proceso No. {i.ToString("000000")}",
                    CentroTrabajoId = 1000,
                    CentroTrabajo = new lv.CentroTrabajo
                    {
                        Codigo = 1000,
                        Nombre = "Centro de Trabajo No. 001000",
                        EsObligatorio = true,
                        EsActivo = true,
                        LineaProduccionCodigo = 2000,
                        Observacion = "Observaciones del Centro de Trabajo No. 001000",
                        Orden = 1000,
                        TiempoEspera = 0,
                        TiempoProceso = 0
                    },
                    EsActivo = true,
                    EsObligatorio = true,
                    Secuencia = i*10,
                    TiempoEstandar = 30
                });
            }
            action(lista, null);

        }

        public  void LavanderiaProcesoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<lv.Proceso>, Exception> action)
        {
            var lista = new List<lv.Proceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.Proceso
                {
                    Id = i,
                    Nombre = $"Proceso No. {i.ToString("000000")}",
                    Descripcion = $"Descripción del Proceso No. {i.ToString("000000")}",
                    CentroTrabajoId = 1000,
                    CentroTrabajo = new lv.CentroTrabajo
                    {
                        Codigo = 1000,
                        Nombre = "Centro de Trabajo No. 001000",
                        EsObligatorio = true,
                        EsActivo = true,
                        LineaProduccionCodigo = 2000,
                        Observacion = "Observaciones del Centro de Trabajo No. 001000",
                        Orden = 1000,
                        TiempoEspera = 0,
                        TiempoProceso = 0
                    },
                    EsActivo = true,
                    EsObligatorio = true,
                    Secuencia = i * 10,
                    TiempoEstandar = 30
                });
            }
            action(lista, null);
        }

        #endregion

        #region Operacion

        public void LavanderiaOperacionUpdate(lv.Operacion operacion, Action<lv.Operacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaOperacionDelete(int operacionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaOperacionGet(int operacionId, Action<lv.Operacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaOperacionGetAll(Action<List<lv.Operacion>, Exception> action)
        {
            var lista = new List<lv.Operacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.Operacion
                {
                    Id = (short)i,
                    Nombre = $"Operacion No. {i.ToString("000000")}",
                    Descripcion = $"Descripción de la Operación No. {i.ToString("000000")}",
                    GrupoId = 1000,
                    LineaProduccionId = 2000,
                    OperacionTipoId = 3000,
                    OperacionPredefinida = new lv.OperacionPredefinida
                    {
                        Id = i*10,
                        OperacionId = i,
                        Temperatura = 80,
                        Ph = "10",
                        TiempoMinimo = 10,
                        TiempoMaximo = 20,
                        RelacionBano = 5,
                        Secuencia = i*10
                    }
                });
            }
        }

        public void LavanderiaOperacionGetAllLavanderia(Action<List<lv.Operacion>, Exception> action)
        {
            var lista = new List<lv.Operacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.Operacion
                {
                    Id = (short)i,
                    Nombre = $"Operacion No. {i.ToString("000000")}",
                    Descripcion = $"Descripción de la Operación No. {i.ToString("000000")}",
                    GrupoId = 1000,
                    LineaProduccionId = 2000,
                    OperacionTipoId = 3000,
                    OperacionPredefinida = new lv.OperacionPredefinida
                    {
                        Id = i * 10,
                        OperacionId = i,
                        Temperatura = 80,
                        Ph = "10",
                        TiempoMinimo = 10,
                        TiempoMaximo = 20,
                        RelacionBano = 5,
                        Secuencia = i * 10
                    }
                });
            }
        }

        public void LavanderiaOperacionGetOperacionesHumedas(int centrotrabajoId, Action<List<lv.Operacion>, Exception> action)
        {
            var lista = new List<lv.Operacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.Operacion
                {
                    Id = (short)i,
                    Nombre = $"Operacion No. {i.ToString("000000")}",
                    Descripcion = $"Descripción de la Operación No. {i.ToString("000000")}",
                    GrupoId = 1000,
                    LineaProduccionId = 2000,
                    OperacionTipoId = 3000,
                    OperacionPredefinida = new lv.OperacionPredefinida
                    {
                        Id = i * 10,
                        OperacionId = i,
                        Temperatura = 80,
                        Ph = "10",
                        TiempoMinimo = 10,
                        TiempoMaximo = 20,
                        RelacionBano = 5,
                        Secuencia = i * 10
                    }
                });
            }
        }

        #endregion

        #region OperacionCentroTrabajo

        public void LavanderiaOperacionCentroTrabajoUpdate(lv.OperacionCentroTrabajo operacionCentroTrabajo,
            Action<lv.OperacionCentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaOperacionCentroTrabajoDelete(int opeacionCentroTrabajoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaOperacionCentroTrabajoGet(int opeacionCentroTrabajoId,
            Action<lv.OperacionCentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavanderiaOperacionCentroTrabajoGetAll(
            Action<List<lv.OperacionCentroTrabajo>, Exception> action)
        {
            var lista = new List<lv.OperacionCentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lv.OperacionCentroTrabajo
                {
                    Id = 1,
                    CentroTrabajo = new lv.CentroTrabajo
                    {
                        Codigo = 10,
                        EsActivo = true,
                        EsObligatorio = true,
                        LineaProduccionCodigo = 100,
                        Nombre = "Centro de Trabajo No. 000010",
                        Observacion = "Observaciones del Centro de Trabajo No. 000010",
                        Orden = 10,
                        TiempoEspera = 10,
                        TiempoProceso = 20
                    },
                    CentroTrabajoCodigo = 10,
                    CentroTrabajoNombre = "Centro de Trabajo No. 000010",
                    EsRepetible = 1,
                    OperacionCodigo = 20,
                    Operacion = new lv.Operacion
                    {
                        Id = 20,
                        Descripcion = "Descripción de la Operación No. 000020",
                        GrupoId = 200,
                        LineaProduccionId = 100,
                        Nombre = "Nombre de la Operacion No. 000020",
                        OperacionTipoId = 300,
                        OperacionPredefinida = new lv.OperacionPredefinida
                        {
                            Id = 30,
                            OperacionId = 20,
                            Ph = "7",
                            RelacionBano = 5,
                            Secuencia = 30,
                            Temperatura = 80,
                            TiempoMinimo = 10,
                            TiempoMaximo = 20
                        }
                    }
                });
            }
            action(lista, null);
        }

        public void LavanderiaOperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<lv.OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = new List<lv.OperacionCentroTrabajo>();
                for (var i = 1; i < 21; i++)
                {
                    lista.Add(new lv.OperacionCentroTrabajo
                    {
                        Id = 1,
                        CentroTrabajo = new lv.CentroTrabajo
                        {
                            Codigo = 10,
                            EsActivo = true,
                            EsObligatorio = true,
                            LineaProduccionCodigo = 100,
                            Nombre = "Centro de Trabajo No. 000010",
                            Observacion = "Observaciones del Centro de Trabajo No. 000010",
                            Orden = 10,
                            TiempoEspera = 10,
                            TiempoProceso = 20
                        },
                        CentroTrabajoCodigo = 10,
                        CentroTrabajoNombre = "Centro de Trabajo No. 000010",
                        EsRepetible = 1,
                        OperacionCodigo = 20,
                        Operacion = new lv.Operacion
                        {
                            Id = 20,
                            Descripcion = "Descripción de la Operación No. 000020",
                            GrupoId = 200,
                            LineaProduccionId = 100,
                            Nombre = "Nombre de la Operacion No. 000020",
                            OperacionTipoId = 300,
                            OperacionPredefinida = new lv.OperacionPredefinida
                            {
                                Id = 30,
                                OperacionId = 20,
                                Ph = "7",
                                RelacionBano = 5,
                                Secuencia = 30,
                                Temperatura = 80,
                                TiempoMinimo = 10,
                                TiempoMaximo = 20
                            }
                        }
                    });
                }
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public void LavanderiaOperacionCentroTrabajoGetByOperacion(short opeacionId,
            Action<List<lv.OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = new List<lv.OperacionCentroTrabajo>();
                for (var i = 1; i < 21; i++)
                {
                    lista.Add(new lv.OperacionCentroTrabajo
                    {
                        Id = 1,
                        CentroTrabajo = new lv.CentroTrabajo
                        {
                            Codigo = 10,
                            EsActivo = true,
                            EsObligatorio = true,
                            LineaProduccionCodigo = 100,
                            Nombre = "Centro de Trabajo No. 000010",
                            Observacion = "Observaciones del Centro de Trabajo No. 000010",
                            Orden = 10,
                            TiempoEspera = 10,
                            TiempoProceso = 20
                        },
                        CentroTrabajoCodigo = 10,
                        CentroTrabajoNombre = "Centro de Trabajo No. 000010",
                        EsRepetible = 1,
                        OperacionCodigo = 20,
                        Operacion = new lv.Operacion
                        {
                            Id = 20,
                            Descripcion = "Descripción de la Operación No. 000020",
                            GrupoId = 200,
                            LineaProduccionId = 100,
                            Nombre = "Nombre de la Operacion No. 000020",
                            OperacionTipoId = 300,
                            OperacionPredefinida = new lv.OperacionPredefinida
                            {
                                Id = 30,
                                OperacionId = 20,
                                Ph = "7",
                                RelacionBano = 5,
                                Secuencia = 30,
                                Temperatura = 80,
                                TiempoMinimo = 10,
                                TiempoMaximo = 20
                            }
                        }
                    });
                }
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        #endregion

        #endregion

        #region CentroTrabajo

        public void CentroTrabajoUpdate(CentroTrabajo centroTrabajo, Action<CentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CentroTrabajoDelete(int centroTrabajoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CentroTrabajoGet(int centroTrabajoId, Action<CentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CentroTrabajoGetAll(Action<List<CentroTrabajo>, Exception> action)
        {
            var lista = new List<CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajo
                {
                    Id = i,
                    Codigo = i.ToString("000000"),
                    Nombre = $"Centro de Trabajo No. {i.ToString("000000")}",
                    Secuencia = i*10,
                    Estado = true
                });
            }
            action(lista, null);
        }

        public void CentroTrabajoGetActivos(Action<List<CentroTrabajo>, Exception> action)
        {
            var lista = new List<CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajo
                {
                    Id = i,
                    Codigo = i.ToString("000000"),
                    Nombre = $"Centro de Trabajo No. {i.ToString("000000")}",
                    Secuencia = i * 10,
                    Estado = true
                });
            }
            action(lista, null);
        }

        #endregion

        #region CentroTrabajoClasificacion

        public void CentroTrabajoClasificacionUpdate(CentroTrabajoClasificacion centroTrabajoClasificacion,
            Action<CentroTrabajoClasificacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CentroTrabajoClasificacionDelete(int centroTrabajoClasificacionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CentroTrabajoClasificacionGetAll(int centroTrabajoId,
            Action<List<CentroTrabajoClasificacion>, Exception> action)
        {
            var lista = new List<CentroTrabajoClasificacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajoClasificacion
                {
                    Id = i,
                    Codigo = i.ToString("000001"),
                    Nombre = $"Clasificacion No. {i.ToString("000001")}",
                    Secuencia = i*10,
                    Estado = true,
                    Tipo = CentroTrabajoClasificacionTipo.Titular,
                    CentroTrabajoId = 1000
                });
            }
        }

        public void CentroTrabajoClasificacionGetAllActive(int centroTrabajoId,
            Action<List<CentroTrabajoClasificacion>, Exception> action)
        {
            var lista = new List<CentroTrabajoClasificacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajoClasificacion
                {
                    Id = i,
                    Codigo = i.ToString("000001"),
                    Nombre = $"Clasificacion No. {i.ToString("000001")}",
                    Secuencia = i * 10,
                    Estado = true,
                    Tipo = CentroTrabajoClasificacionTipo.Titular,
                    CentroTrabajoId = 1000
                });
            }
        }

        #endregion

        #region Empleado

        public void EmpleadoGet(short companiaCodigo, int empleadoId, Action<lb.Empleado, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void EmpleadoGetAllActivos(Action<List<lb.Empleado>, Exception> action)
        {
            var lista = new List<lb.Empleado>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new lb.Empleado
                {
                    CompaniaCodigo = 1,
                    Codigo = i,
                    Nombres = $"Nombre {i.ToString("000")}",
                    Apellidos = $"Apellido {i.ToString("000")}",
                    Alias = $"Alias {i.ToString("000")}",
                    Estado = "A"
                });
            }
        }

        #endregion

        #region Grupo

        public void GrupoUpdate(Grupo grupo, Action<Grupo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void GrupoDelete(int grupoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void GrupoGet(int grupoId, Action<Grupo, Exception> action)
        {
            try
            {
                var fecha = new DateTime(2016, 1, 4);
                var reg = new Grupo
                {
                    Id = 1,
                    FechaInicio = fecha,
                    FechaFinal = fecha.AddDays(7),
                    Codigo = "000001",
                    Nombre = "Grupo No. 000001",
                    Secuencia = 10,
                    Estado = true
                };
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GrupoGetAll(Action<List<Grupo>, Exception> action)
        {
            var lista = new List<Grupo>();
            var fecha = new DateTime(2016,1,4);
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Grupo
                {
                    Id = i,
                    FechaInicio = fecha,
                    FechaFinal = fecha.AddDays(7),
                    Codigo = i.ToString("000000"),
                    Nombre = $"Grupo No. {i.ToString("000000")}",
                    Secuencia = i*10,
                    Estado = true
                });
            }
            action(lista, null);
        }

        public void GrupoGetAllActivos(Action<List<Grupo>, Exception> action)
        {
            var lista = new List<Grupo>();
            var fecha = new DateTime(2016, 1, 4);
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Grupo
                {
                    Id = i,
                    FechaInicio = fecha,
                    FechaFinal = fecha.AddDays(7),
                    Codigo = i.ToString("000000"),
                    Nombre = $"Grupo No. {i.ToString("000000")}",
                    Secuencia = i * 10,
                    Estado = true
                });
            }
            action(lista, null);
        }

        public void GrupoGetByLinea(int lineaId, Action<Grupo, Exception> action)
        {
            var grupo = new Grupo
            {
                Id = 1,
                Codigo = "000001",
                Nombre = "Grupo No. 000001",
                Estado = true,
                FechaInicio = new DateTime(2016, 1, 4),
                FechaFinal = new DateTime(2016, 1, 11),
                Secuencia = 10
            };
            action(grupo, null);
        }

        public void GrupoCopiarSemana(DateTime desde, DateTime hasta, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void GrupoHayDataSemana(DateTime fecha, Action<bool, Exception> action)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Jornada

        public void JornadaUpdate(Jornada jornada, Action<Jornada, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void JornadaDelete(int jornadaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void JornadaGet(int jornadaId, Action<Jornada, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void JornadaGetAll(Action<List<Jornada>, Exception> action)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region JornadaDetalle

        public void JornadaDetalleUpdate(JornadaDetalle jornadaDetalle, Action<JornadaDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void JornadaDetalleDelete(int jornadaDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void JornadaDetalleGet(int jornadaDetalleId, Action<JornadaDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void JornadaDetalleGetByJornada(int jornadaId, Action<List<JornadaDetalle>, Exception> action)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Linea

        public void LineaUpdate(Linea linea, Action<Linea, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LineaDelete(int lineaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LineaGetByGrupo(int grupoId, Action<List<Linea>, Exception> action)
        {
            var lista = new List<Linea>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Linea
                {
                    Id = i,
                    GrupoId = 10,
                    Codigo = i.ToString("000000"),
                    Nombre = $"Linea No. {i.ToString("00000")}",
                    Secuencia = i*10,
                    Tipo = LineaTipo.SalidaMultiple,
                    Estado = true
                });
            }
            action(lista, null);
        }

        public void LineaGetByGrupoActivas(int grupoId, Action<List<Linea>, Exception> action)
        {
            var lista = new List<Linea>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Linea
                {
                    Id = i,
                    GrupoId = 10,
                    Codigo = i.ToString("000000"),
                    Nombre = $"Linea No. {i.ToString("00000")}",
                    Secuencia = i * 10,
                    Tipo = LineaTipo.SalidaMultiple,
                    Estado = true
                });
            }
            action(lista, null);
        }

        #endregion

        #region LineaDetalle

        public void LineaDetalleUpdate(LineaDetalle lineaDetalle, Action<LineaDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LineaDetalleDelete(int lineaDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LineaDetalleGetByLinea(int lineaId, Action<List<LineaDetalle>, Exception> action)
        {
            var lista = new List<LineaDetalle>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new LineaDetalle
                {
                    Id = i,
                    LineaId = 10,
                    CentroTrabajoId = 1,
                    ModuloId = 1,
                    EsSalidaUnica = true,
                    Secuencia = i*10
                });
            }
            action(lista, null);
        }

        #endregion

        #region Modulo

        public void ModuloUpdate(Modulo modulo, Action<Modulo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloDelete(int moduloId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloGetAll(int centroTrabajoId, Action<List<Modulo>, Exception> action)
        {
            var lista = new List<Modulo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Modulo
                {
                    Id = i,
                    Codigo = i.ToString("000000"),
                    Nombre = $"Módulo No. {i.ToString("000000")}",
                    Secuencia = i*10,
                    Estado = true,
                    CentroTrabajoId = centroTrabajoId
                });
            }
            action(lista, null);
        }

        #endregion

        #region ModuloSemana

        public void ModuloSemanaUpdate(ModuloSemana moduloSemana, Action<ModuloSemana, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloSemanaDelete(int moduloSemanaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloSemanaGet(int moduloSemanaId, Action<ModuloSemana, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloSemanaGetByFecha(DateTime fechaInicio, Action<List<ModuloSemana>, Exception> action)
        {
            var lista = new List<ModuloSemana>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ModuloSemana
                {
                    Id = i,
                    FechaInicio = new DateTime(2016,1,4),
                FechaFinal = new DateTime(2016,1,10),
                    CentroTrabajoId = 1000,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = 1000,
                        Codigo = "001000",
                        Nombre = "Centro de Trabajo No. 001000",
                        Secuencia = 10
                    },
                    ModuloId = 2000,
                    Modulo = new Modulo
                    {
                        Id = 2000,
                        Codigo = "002000",
                        Nombre = "Modulo No. 002000",
                        Secuencia = 10
                    },
                    Curva = 100,
                    MetaPiezasPorHora = 150,
                    MetaProduccion = 25000,
                    MinutosBase = 26400,
                    MinutosEntrenamiento = 2000,
                    MinutosTitular = 24400,
                    MinutosUtilitario = 2640,
                    TransferenciaMinutos = 1000
                });
            }
            action(lista, null);
        }

        public void ModuloSemanaGetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId, Action<List<ModuloSemana>, Exception> action)
        {
            var lista = new List<ModuloSemana>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ModuloSemana
                {
                    Id = i,
                    FechaInicio = new DateTime(2016, 1, 4),
                    FechaFinal = new DateTime(2016, 1, 10),
                    CentroTrabajoId = 1000,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = 1000,
                        Codigo = "001000",
                        Nombre = "Centro de Trabajo No. 001000",
                        Secuencia = 10
                    },
                    ModuloId = 2000,
                    Modulo = new Modulo
                    {
                        Id = 2000,
                        Codigo = "002000",
                        Nombre = "Modulo No. 002000",
                        Secuencia = 10
                    },
                    Curva = 100,
                    MetaPiezasPorHora = 150,
                    MetaProduccion = 25000,
                    MinutosBase = 26400,
                    MinutosEntrenamiento = 2000,
                    MinutosTitular = 24400,
                    MinutosUtilitario = 2640,
                    TransferenciaMinutos = 1000
                });
            }
            action(lista, null);

        }

        public void ModuloSemanaGetByFechaModulo(DateTime fechaInicio, int moduloId, Action<List<ModuloSemana>, Exception> action)
        {
            var lista = new List<ModuloSemana>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ModuloSemana
                {
                    Id = i,
                    FechaInicio = new DateTime(2016, 1, 4),
                    FechaFinal = new DateTime(2016, 1, 10),
                    CentroTrabajoId = 1000,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = 1000,
                        Codigo = "001000",
                        Nombre = "Centro de Trabajo No. 001000",
                        Secuencia = 10
                    },
                    ModuloId = 2000,
                    Modulo = new Modulo
                    {
                        Id = 2000,
                        Codigo = "002000",
                        Nombre = "Modulo No. 002000",
                        Secuencia = 10
                    },
                    Curva = 100,
                    MetaPiezasPorHora = 150,
                    MetaProduccion = 25000,
                    MinutosBase = 26400,
                    MinutosEntrenamiento = 2000,
                    MinutosTitular = 24400,
                    MinutosUtilitario = 2640,
                    TransferenciaMinutos = 1000
                });
            }
            action(lista, null);

        }

        #endregion

        #region ModuloSemanaOperario

        public void ModuloSemanaOperarioUpdate(ModuloSemanaOperario moduloSemanaOperario,
            Action<ModuloSemanaOperario, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloSemanaOperarioDelete(int moduloSemanaOperarioId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloSemanaOperarioGet(int moduloSemanaOperarioId, Action<ModuloSemanaOperario, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ModuloSemanaOperarioGetByModuloSemana(int moduloSemanaId,
            Action<List<ModuloSemanaOperario>, Exception> action)
        {
            var lista = new List<ModuloSemanaOperario>();
            for (var i = 1; i < 11; i++)
            {
                lista.Add(new ModuloSemanaOperario
                {
                    Id = i,
                    ClasificacionId = 1000,
                    Clasificacion = new CentroTrabajoClasificacion
                    {
                        Id = 1000,
                        Codigo = "001000",
                        Nombre = "Clasificación No. 001000",
                        Estado = true,
                        Secuencia = 10,
                        Tipo = CentroTrabajoClasificacionTipo.Titular
                    }
                });
            }
            for (var i = 1; i < 5; i++)
            {
                lista.Add(new ModuloSemanaOperario
                {
                    Id = i,
                    ClasificacionId = 1000,
                    Clasificacion = new CentroTrabajoClasificacion
                    {
                        Id = 1000,
                        Codigo = "002000",
                        Nombre = "Clasificación No. 002000",
                        Estado = true,
                        Secuencia = 10,
                        Tipo = CentroTrabajoClasificacionTipo.Entrenamiento
                    }
                });
            }
            for (var i = 1; i < 3; i++)
            {
                lista.Add(new ModuloSemanaOperario
                {
                    Id = i,
                    ClasificacionId = 1000,
                    Clasificacion = new CentroTrabajoClasificacion
                    {
                        Id = 1000,
                        Codigo = "003000",
                        Nombre = "Clasificación No. 003000",
                        Estado = true,
                        Secuencia = 10,
                        Tipo = CentroTrabajoClasificacionTipo.Utilitario
                    }
                });
            }
            action(lista, null);
        }

        #endregion

        #region Turno

        public void TurnoUpdate(Turno turno, Action<Turno, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TurnoDelete(int turnoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TurnoGet(int turnoId, Action<Turno, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TurnoGetAll(Action<List<Turno>, Exception> action)
        {
            var lista = new List<Turno>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Turno
                {
                    Id = i,
                    Codigo = i.ToString("000000"),
                    Nombre = $"Turno No. {i.ToString("000000")}"
                });
            }
            action(lista, null);
        }

        #endregion

        #region TurnoDetalle

        public void TurnoDetalleUpdate(TurnoDetalle turnoDetalle, Action<TurnoDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TurnoDetalleDelete(int turnoDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TurnoDetalleGet(int turnoDetalleId, Action<TurnoDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TurnoDetalleGetByTurno(int turnoId, Action<List<TurnoDetalle>, Exception> action)
        {
            var lista = new List<TurnoDetalle>();
            for (var i = 1; i < 8; i++)
            {
                lista.Add(new TurnoDetalle
                {
                    Id = i,
                    TurnoId = 1000,
                    Dia = (DiaSemana)i,
                    JornadaId = 2000,
                    Jornada = new Jornada
                    {
                        Id = 2000,
                        Codigo = "002000",
                        Nombre = "Jornada No. 002000"
                    },
                    Horas = 9,
                    Minutos = 0
                });
            }
            action(lista, null);
        }

        #endregion
    }
}