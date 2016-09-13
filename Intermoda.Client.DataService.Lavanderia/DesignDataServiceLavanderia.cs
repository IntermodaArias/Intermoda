using System;
using System.Collections.Generic;
using Intermoda.Client.Lavanderia;
using Intermoda.Common;
using Intermoda.Common.Enum;

namespace Intermoda.Client.DataService.Lavanderia
{
    public class DesignDataServiceLavanderia : IDataServiceLavanderia
    {
        #region ArchivoGlobal

        public void ArchivoGlobalUpdate(ArchivoGlobal archivoGlobal, Action<ArchivoGlobal, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ArchivoGlobalDelete(int archivoGlobalId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ArchivoGlobalGet(int archivoGlobalId, Action<ArchivoGlobal, Exception> action)
        {
            var reg = new ArchivoGlobal
            {
                Id = 1,
                PropietarioId = 1,
                Nombre = "Nombre del Archivo No. 000001",
                Tipo = "ARCH",
                Extension = "png",
                Orden = 10,
                Descripcion = "Descripción del Archivo No. 000001",
                Binario = null,
                PropietarioNombre = "Nombre del objeto propietario del archivo No. 000001",
                Fecha = new DateTime(2016, 1, 1),
                Version = "1.0",
                Lavado = new Lavado
                {
                    LavadoId = 1,
                    LavadoNombre = "Nombre del Lavado No. 000001",
                    ColorId = 1,
                    EsActivo = 1,
                    LavadoDescripcion = "Descripción del Lavado No. 000001",
                    LavadoFechaCreacion = new DateTime(2016, 1, 1),
                    LavadoFechaActualizacion = new DateTime(2016, 5, 30),
                    ColorIntermoda = new ColorIntermoda
                    {
                        Id = 1,
                        Nombre = "Color No. 001"
                    }
                }
            };
            action(reg, null);
        }

        public void ArchivoGlobalGetAll(Action<List<ArchivoGlobal>, Exception> action)
        {
            var lista = new List<ArchivoGlobal>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ArchivoGlobal
                {
                    Id = 1,
                    PropietarioId = 1,
                    Nombre = $"Nombre del Archivo No. {i.ToString("000000")}",
                    Tipo = "ARCH",
                    Extension = "png",
                    Orden = 10,
                    Descripcion = $"Descripción del Archivo No. {i.ToString("000000")}",
                    Binario = null,
                    PropietarioNombre = $"Nombre del objeto propietario del archivo No. {i.ToString("000000")}",
                    Fecha = new DateTime(2016, 1, 1),
                    Version = "1.0",
                    Lavado = new Lavado
                    {
                        LavadoId = 1,
                        LavadoNombre = $"Nombre del Lavado No. {i.ToString("000000")}",
                        ColorId = 1,
                        EsActivo = 1,
                        LavadoDescripcion = $"Descripción del Lavado No. {i.ToString("000000")}",
                        LavadoFechaCreacion = new DateTime(2016, 1, 1),
                        LavadoFechaActualizacion = new DateTime(2016, 5, 30),
                        ColorIntermoda = new ColorIntermoda
                        {
                            Id = 1,
                            Nombre = $"Color No. {i.ToString("000")}"
                        }
                    }
                });
            }
        }

        public void ArchivoGlobalGetByPropietario(int propietarioId, Action<ArchivoGlobal, Exception> action)
        {
            var bytes = Tools.FileToByteArray(@"..\images\intermodalogo.jpg");
            var reg = new ArchivoGlobal
            {
                Id = 1,
                PropietarioId = 1,
                Nombre = "Nombre del Archivo No. 000001",
                Tipo = "ARCH",
                Extension = "png",
                Orden = 10,
                Descripcion = "Descripción del Archivo No. 000001",
                Binario = bytes,
                PropietarioNombre = "Nombre del objeto propietario del archivo No. 000001",
                Fecha = new DateTime(2016, 1, 1),
                Version = "1.0",
                Lavado = new Lavado
                {
                    LavadoId = 1,
                    LavadoNombre = "Nombre del Lavado No. 000001",
                    ColorId = 1,
                    EsActivo = 1,
                    LavadoDescripcion = "Descripción del Lavado No. 000001",
                    LavadoFechaCreacion = new DateTime(2016, 1, 1),
                    LavadoFechaActualizacion = new DateTime(2016, 5, 30),
                    ColorIntermoda = new ColorIntermoda
                    {
                        Id = 1,
                        Nombre = "Color No. 001"
                    }
                }
            };
            action(reg, null);
        }

        #endregion

        #region Catalogo

        public void CatalogoUpdate(Catalogo catalogo, Action<Catalogo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CatalogoDelete(int ingredienteId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CatalogoGet(int ingredienteId, Action<Catalogo, Exception> action)
        {
            var reg = new Catalogo
            {
                Id = 1,
                Nombre = "Catalogo No. 000001",
                Descripcion = "Descripción del Catalogo No. 000001",
                MedidaCompraCodigo = "CMP",
                MedidaConsumoCodigo = "CNS",
                TipoRequisicionCodigo = "REQ",
                GrupoCodigo = "GRP",
                TelaCodigo = "TELA",
                CuentaContableCodigo = "CTACTB",
                CuentaVariableFija = "F",
                CuentaContableInventarioCodigo = "CTACTBINV",
                RepuestoNumero = "REPUESTO"
            };

            action(reg, null);
        }

        public void CatalogoGetAll(Action<List<Catalogo>, Exception> action)
        {
            var lista = new List<Catalogo>();

            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Catalogo
                {
                    Id = i,
                    Nombre = $"Ingrediente No. {i.ToString("000000")}",
                    Descripcion = $"Descripción del ingrediente No. {i.ToString("000000")}",
                    MedidaCompraCodigo = "CMP",
                    MedidaConsumoCodigo = "CNS",
                    TipoRequisicionCodigo = "REQ",
                    GrupoCodigo = "GRP",
                    TelaCodigo = "TELA",
                    CuentaContableCodigo = "CTACTB",
                    CuentaVariableFija = "F",
                    CuentaContableInventarioCodigo = "CTACTBINV",
                    RepuestoNumero = "REPUESTO"
                });

                action(lista, null);
            }
        }

        public void CatalogoGetByTela(string telaId, Action<Catalogo, Exception> action)
        {
            var reg = new Catalogo
            {
                Id = 1,
                Nombre = "Catalogo No. 000001",
                Descripcion = "Descripción del Catalogo No. 000001",
                MedidaCompraCodigo = "CMP",
                MedidaConsumoCodigo = "CNS",
                TipoRequisicionCodigo = "REQ",
                GrupoCodigo = "GRP",
                TelaCodigo = "TELA",
                CuentaContableCodigo = "CTACTB",
                CuentaVariableFija = "F",
                CuentaContableInventarioCodigo = "CTACTBINV",
                RepuestoNumero = "REPUESTO"
            };

            action(reg, null);
        }
        
        #endregion

        #region CentroTrabajo

        public void CentroTrabajoUpdate(CentroTrabajo centroTrabajo,
            Action<CentroTrabajo, Exception> action)
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

        public void CentroTrabajoGetActivos(Action<List<CentroTrabajo>, Exception> action)
        {
            var lista = new List<CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajo
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

        public void CentroTrabajoGetByOperacion(int operacionId, Action<List<CentroTrabajo>, Exception> action)
        {
            var lista = new List<CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajo
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

        public void CentroTrabajoGetAllLavanderia(Action<List<CentroTrabajo>, Exception> action)
        {
            var lista = new List<CentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajo
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

        #region CentroTrabajoOpcion

        public void CentroTrabajoOpcionUpdate(CentroTrabajoOpcion centroTrabajoOpcion,
            Action<CentroTrabajoOpcion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CentroTrabajoOpcionDelete(int centroTrabajoOpcionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void CentroTrabajoOpcionGet(int centroTrabajoOpcionId, Action<CentroTrabajoOpcion, Exception> action)
        {
            var reg = new CentroTrabajoOpcion
            {
                Id = 1,
                CentroTrabajoId = 1,
                CentroTrabajoNombre = "Centro de Trabajo No. 01",
                CentroTrabajoObservacion = "Observaciones del Centro de Trabajo No. 01",
                OpcionId = 1,
                Orden = 10,
                CentroTrabajo = new CentroTrabajo
                {
                    Codigo = 1,
                    Nombre = "Centro de Trabajo No. 01",
                    Orden = 10,
                    Observacion = "Observaciones del Centro de Trabajo No. 01",
                    TiempoEspera = 10,
                    TiempoProceso = 20,
                    LineaProduccionCodigo = 1,
                    EsActivo = true,
                    EsObligatorio = true
                },
                OpcionLavado = new OpcionLavado
                {
                    Id = 1,
                    Nombre = "Opción de Lavado No. 01",
                    Descripcion = "Descripción de la Opción de Lavado No. 01",
                    LavadoId = 1,
                    TelaId = "TL1",
                    IsDefault = 1,
                    Lavado = new Lavado
                    {
                        LavadoId = 1,
                        LavadoNombre = "Lavado No. 001",
                        LavadoDescripcion = "Descripción del Lavado No. 001",
                        ColorId = 1,
                        EsActivo = 1,
                        LavadoFechaCreacion = new DateTime(2016, 1, 1),
                        LavadoFechaActualizacion = new DateTime(2016, 2, 1),
                        ColorIntermoda = new ColorIntermoda
                        {
                            Id = 1,
                            Nombre = "Color Intermoda"
                        }
                    },
                    Tela = new Tela
                    {
                        TelaCodigo = "TL1",
                        TelaNombre = "Tela No. 001",
                        ComposicionNombre = "Composición de la Tela",
                        MaterialCodigo = 1,
                        TelaDescripcion = "Descripción de la Tela No. 001"
                    }
                }
            };
            action(reg, null);
        }

        public void CentroTrabajoOpcionGetAll(Action<List<CentroTrabajoOpcion>, Exception> action)
        {
            var lista = new List<CentroTrabajoOpcion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajoOpcion
                {
                    Id = i,
                    CentroTrabajoId = 1,
                    CentroTrabajoNombre = "Centro de Trabajo No. 01",
                    CentroTrabajoObservacion = "Observaciones del Centro de Trabajo No. 01",
                    OpcionId = 1,
                    Orden = 10,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Codigo = 1,
                        Nombre = "Centro de Trabajo No. 01",
                        Orden = 10,
                        Observacion = "Observaciones del Centro de Trabajo No. 01",
                        TiempoEspera = 10,
                        TiempoProceso = 20,
                        LineaProduccionCodigo = 1,
                        EsActivo = true,
                        EsObligatorio = true
                    },
                    OpcionLavado = new OpcionLavado
                    {
                        Id = 1,
                        Nombre = "Opción de Lavado No. 01",
                        Descripcion = "Descripción de la Opción de Lavado No. 01",
                        LavadoId = 1,
                        TelaId = "TL1",
                        IsDefault = 1,
                        Lavado = new Lavado
                        {
                            LavadoId = 1,
                            LavadoNombre = "Lavado No. 001",
                            LavadoDescripcion = "Descripción del Lavado No. 001",
                            ColorId = 1,
                            EsActivo = 1,
                            LavadoFechaCreacion = new DateTime(2016, 1, 1),
                            LavadoFechaActualizacion = new DateTime(2016, 2, 1),
                            ColorIntermoda = new ColorIntermoda
                            {
                                Id = 1,
                                Nombre = "Color Intermoda"
                            }
                        },
                        Tela = new Tela
                        {
                            TelaCodigo = "TL1",
                            TelaNombre = "Tela No. 001",
                            ComposicionNombre = "Composición de la Tela",
                            MaterialCodigo = 1,
                            TelaDescripcion = "Descripción de la Tela No. 001"
                        }
                    }
                });
            }
            action(lista, null);
        }

        public void CentroTrabajoOpcionGetByCentroTrabajo(int centroTrabajoId,
            Action<List<CentroTrabajoOpcion>, Exception> action)
        {
            var lista = new List<CentroTrabajoOpcion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajoOpcion
                {
                    Id = i,
                    CentroTrabajoId = 1,
                    CentroTrabajoNombre = "Centro de Trabajo No. 01",
                    CentroTrabajoObservacion = "Observaciones del Centro de Trabajo No. 01",
                    OpcionId = 1,
                    Orden = 10,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Codigo = 1,
                        Nombre = "Centro de Trabajo No. 01",
                        Orden = 10,
                        Observacion = "Observaciones del Centro de Trabajo No. 01",
                        TiempoEspera = 10,
                        TiempoProceso = 20,
                        LineaProduccionCodigo = 1,
                        EsActivo = true,
                        EsObligatorio = true
                    },
                    OpcionLavado = new OpcionLavado
                    {
                        Id = 1,
                        Nombre = "Opción de Lavado No. 01",
                        Descripcion = "Descripción de la Opción de Lavado No. 01",
                        LavadoId = 1,
                        TelaId = "TL1",
                        IsDefault = 1,
                        Lavado = new Lavado
                        {
                            LavadoId = 1,
                            LavadoNombre = "Lavado No. 001",
                            LavadoDescripcion = "Descripción del Lavado No. 001",
                            ColorId = 1,
                            EsActivo = 1,
                            LavadoFechaCreacion = new DateTime(2016, 1, 1),
                            LavadoFechaActualizacion = new DateTime(2016, 2, 1),
                            ColorIntermoda = new ColorIntermoda
                            {
                                Id = 1,
                                Nombre = "Color Intermoda"
                            }
                        },
                        Tela = new Tela
                        {
                            TelaCodigo = "TL1",
                            TelaNombre = "Tela No. 001",
                            ComposicionNombre = "Composición de la Tela",
                            MaterialCodigo = 1,
                            TelaDescripcion = "Descripción de la Tela No. 001"
                        }
                    }
                });
            }
            action(lista, null);
        }

        public void CentroTrabajoOpcionGetByOpcion(int opcionLavadoId,
            Action<List<CentroTrabajoOpcion>, Exception> action)
        {
            var lista = new List<CentroTrabajoOpcion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new CentroTrabajoOpcion
                {
                    Id = i,
                    CentroTrabajoId = 1,
                    CentroTrabajoNombre = "Centro de Trabajo No. 01",
                    CentroTrabajoObservacion = "Observaciones del Centro de Trabajo No. 01",
                    OpcionId = 1,
                    Orden = 10,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Codigo = 1,
                        Nombre = "Centro de Trabajo No. 01",
                        Orden = 10,
                        Observacion = "Observaciones del Centro de Trabajo No. 01",
                        TiempoEspera = 10,
                        TiempoProceso = 20,
                        LineaProduccionCodigo = 1,
                        EsActivo = true,
                        EsObligatorio = true
                    },
                    OpcionLavado = new OpcionLavado
                    {
                        Id = 1,
                        Nombre = "Opción de Lavado No. 01",
                        Descripcion = "Descripción de la Opción de Lavado No. 01",
                        LavadoId = 1,
                        TelaId = "TL1",
                        IsDefault = 1,
                        Lavado = new Lavado
                        {
                            LavadoId = 1,
                            LavadoNombre = "Lavado No. 001",
                            LavadoDescripcion = "Descripción del Lavado No. 001",
                            ColorId = 1,
                            EsActivo = 1,
                            LavadoFechaCreacion = new DateTime(2016, 1, 1),
                            LavadoFechaActualizacion = new DateTime(2016, 2, 1),
                            ColorIntermoda = new ColorIntermoda
                            {
                                Id = 1,
                                Nombre = "Color Intermoda"
                            }
                        },
                        Tela = new Tela
                        {
                            TelaCodigo = "TL1",
                            TelaNombre = "Tela No. 001",
                            ComposicionNombre = "Composición de la Tela",
                            MaterialCodigo = 1,
                            TelaDescripcion = "Descripción de la Tela No. 001"
                        }
                    }
                });
            }
            action(lista, null);
        }

        #endregion

        #region Clase

        public void ClaseUpdate(Clase clase, Action<Clase, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ClaseDelete(string claseCodigo, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ClaseGet(string claseCodigo, Action<Clase, Exception> action)
        {
            var reg = new Clase
            {
                CompaniaCodigo = 1,
                Codigo = "000001",
                Descripcion = "Clase No. 000001",
                AgrupacionCodigo = 1000,
                AgruparEnClaseCodigo = "000002",
                CuentaContable = "CTACTB",
                DetalleMaestra = "DETMST",
                DiasSinMovimiento = 10,
                Estado = "A",
                GrupoNombre = "Grupo",
                ManejaInventario = "S",
                RotacionBaja = 100,
                SinRotacion = 10
            };

            action(reg, null);
        }

        public void ClaseGetAll(Action<List<Clase>, Exception> action)
        {
            var lista = new List<Clase>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Clase
                {
                    CompaniaCodigo = 1,
                    Codigo = $"{i.ToString("000000")}",
                    Descripcion = $"Clase No. {i.ToString("000000")}",
                    AgrupacionCodigo = 1000,
                    AgruparEnClaseCodigo = "000002",
                    CuentaContable = "CTACTB",
                    DetalleMaestra = "DETMST",
                    DiasSinMovimiento = 10,
                    Estado = "A",
                    GrupoNombre = "Grupo",
                    ManejaInventario = "S",
                    RotacionBaja = 100,
                    SinRotacion = 10
                });
            }
        }

        #endregion

        #region ColorIntermoda

        public void ColorIntermodaUpdate(ColorIntermoda colorIntermoda, Action<ColorIntermoda, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ColorIntermodaDelete(int colorIntermodaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ColorIntermodaGet(int colorIntermodaId, Action<ColorIntermoda, Exception> action)
        {
            var reg = new ColorIntermoda
            {
                Id = 1,
                Nombre = "Color No. 001"
            };
            action(reg, null);
        }

        public void ColorIntermodaGetAll(Action<List<ColorIntermoda>, Exception> action)
        {
            var lista = new List<ColorIntermoda>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ColorIntermoda
                {
                    Id = i,
                    Nombre = $"Color No. {i.ToString("000")}"
                });
            }
        }

        #endregion

        #region IngredienteOperacion

        public void IngredienteOperacionUpdate(IngredienteOperacion ingredienteOperacion,
            Action<IngredienteOperacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void IngredienteOperacionDelete(int ingredienteOperacionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void IngredienteOperacionGet(int ingredienteOperacionId, Action<IngredienteOperacion, Exception> action)
        {
            var reg = new IngredienteOperacion
            {
                Id = 1,
                IngredienteId = 1,
                OperacionId = 1,
                OperacionProcesoId = 1,
                InstruccionOperacionId = 1,
                ClaseId = "CLA",
                SubClaseId = "SCL",
                Porcentaje = 60,
                Orden = 10,
                Ingrediente = new Catalogo
                {
                    Id = 1,
                    Nombre = "Ingrediente No. 0001"
                },
                Operacion = new Operacion
                {
                    Id = 1,
                    Nombre = "Operacion No. 0001"
                },
                OperacionProceso = new OperacionProceso
                {
                    Id = 1,
                },
                InstruccionOperacion = new InstruccionOperacion
                {
                    Id = 1,
                    Descripcion = "Instrucción de la Operación No. 0001"
                },
                Clase = new Clase
                {
                    CompaniaCodigo = 1,
                    Codigo = "CLA",
                    Descripcion = "Clase del material"
                },
                SubClase = new SubClase
                {
                    CompaniaCodigo = 1,
                    Codigo = "SCL",
                    Descripcion = "Sub clase del material"
                }
            };
            action(reg, null);
        }

        public void IngredienteOperacionGetAll(Action<List<IngredienteOperacion>, Exception> action)
        {
            var lista = new List<IngredienteOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredienteOperacion
                {
                    Id = i,
                    IngredienteId = 1,
                    OperacionId = 1,
                    OperacionProcesoId = 1,
                    InstruccionOperacionId = 1,
                    ClaseId = "CLA",
                    SubClaseId = "SCL",
                    Porcentaje = 60,
                    Orden = i*10,
                    Ingrediente = new Catalogo
                    {
                        Id = 1,
                        Nombre = "Ingrediente No. 0001"
                    },
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operacion No. 0001"
                    },
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    },
                    InstruccionOperacion = new InstruccionOperacion
                    {
                        Id = 1,
                        Descripcion = "Instrucción de la Operación No. 0001"
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "CLA",
                        Descripcion = "Clase del material"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "SCL",
                        Descripcion = "Sub clase del material"
                    }
                });
            }
            action(lista, null);
        }

        public void IngredienteOperacionGetByIngrediente(int ingredienteId,
            Action<List<IngredienteOperacion>, Exception> action)
        {
            var lista = new List<IngredienteOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredienteOperacion
                {
                    Id = i,
                    IngredienteId = 1,
                    OperacionId = 1,
                    OperacionProcesoId = 1,
                    InstruccionOperacionId = 1,
                    ClaseId = "CLA",
                    SubClaseId = "SCL",
                    Porcentaje = 60,
                    Orden = i * 10,
                    Ingrediente = new Catalogo
                    {
                        Id = 1,
                        Nombre = "Ingrediente No. 0001"
                    },
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operacion No. 0001"
                    },
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    },
                    InstruccionOperacion = new InstruccionOperacion
                    {
                        Id = 1,
                        Descripcion = "Instrucción de la Operación No. 0001"
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "CLA",
                        Descripcion = "Clase del material"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "SCL",
                        Descripcion = "Sub clase del material"
                    }
                });
            }
            action(lista, null);
        }

        public void IngredienteOperacionGetByOperacion(int operacionId, Action<List<IngredienteOperacion>, Exception> action)
        {
            var lista = new List<IngredienteOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredienteOperacion
                {
                    Id = i,
                    IngredienteId = 1,
                    OperacionId = 1,
                    OperacionProcesoId = 1,
                    InstruccionOperacionId = 1,
                    ClaseId = "CLA",
                    SubClaseId = "SCL",
                    Porcentaje = 60,
                    Orden = i * 10,
                    Ingrediente = new Catalogo
                    {
                        Id = 1,
                        Nombre = "Ingrediente No. 0001"
                    },
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operacion No. 0001"
                    },
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    },
                    InstruccionOperacion = new InstruccionOperacion
                    {
                        Id = 1,
                        Descripcion = "Instrucción de la Operación No. 0001"
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "CLA",
                        Descripcion = "Clase del material"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "SCL",
                        Descripcion = "Sub clase del material"
                    }
                });
            }
            action(lista, null);
        }

        public void IngredienteOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<IngredienteOperacion>, Exception> action)
        {
            var lista = new List<IngredienteOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredienteOperacion
                {
                    Id = i,
                    IngredienteId = 1,
                    OperacionId = 1,
                    OperacionProcesoId = 1,
                    InstruccionOperacionId = 1,
                    ClaseId = "CLA",
                    SubClaseId = "SCL",
                    Porcentaje = 60,
                    Orden = i * 10,
                    Ingrediente = new Catalogo
                    {
                        Id = 1,
                        Nombre = "Ingrediente No. 0001"
                    },
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operacion No. 0001"
                    },
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    },
                    InstruccionOperacion = new InstruccionOperacion
                    {
                        Id = 1,
                        Descripcion = "Instrucción de la Operación No. 0001"
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "CLA",
                        Descripcion = "Clase del material"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "SCL",
                        Descripcion = "Sub clase del material"
                    }
                });
            }
            action(lista, null);
        }

        public void IngredienteOperacionGetByClase(string claseId, Action<List<IngredienteOperacion>, Exception> action)
        {
            var lista = new List<IngredienteOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredienteOperacion
                {
                    Id = i,
                    IngredienteId = 1,
                    OperacionId = 1,
                    OperacionProcesoId = 1,
                    InstruccionOperacionId = 1,
                    ClaseId = "CLA",
                    SubClaseId = "SCL",
                    Porcentaje = 60,
                    Orden = i * 10,
                    Ingrediente = new Catalogo
                    {
                        Id = 1,
                        Nombre = "Ingrediente No. 0001"
                    },
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operacion No. 0001"
                    },
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    },
                    InstruccionOperacion = new InstruccionOperacion
                    {
                        Id = 1,
                        Descripcion = "Instrucción de la Operación No. 0001"
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "CLA",
                        Descripcion = "Clase del material"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "SCL",
                        Descripcion = "Sub clase del material"
                    }
                });
            }
            action(lista, null);
        }

        public void IngredienteOperacionGetBySubClase(string subClaseId, Action<List<IngredienteOperacion>, Exception> action)
        {
            var lista = new List<IngredienteOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredienteOperacion
                {
                    Id = i,
                    IngredienteId = 1,
                    OperacionId = 1,
                    OperacionProcesoId = 1,
                    InstruccionOperacionId = 1,
                    ClaseId = "CLA",
                    SubClaseId = "SCL",
                    Porcentaje = 60,
                    Orden = i * 10,
                    Ingrediente = new Catalogo
                    {
                        Id = 1,
                        Nombre = "Ingrediente No. 0001"
                    },
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operacion No. 0001"
                    },
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    },
                    InstruccionOperacion = new InstruccionOperacion
                    {
                        Id = 1,
                        Descripcion = "Instrucción de la Operación No. 0001"
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "CLA",
                        Descripcion = "Clase del material"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "SCL",
                        Descripcion = "Sub clase del material"
                    }
                });
            }
            action(lista, null);
        }

        public void IngredienteOperacionGetByInstruccionOperacion(int instruccionOperacionId,
            Action<List<IngredienteOperacion>, Exception> action)
        {
            var lista = new List<IngredienteOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredienteOperacion
                {
                    Id = i,
                    IngredienteId = 1,
                    OperacionId = 1,
                    OperacionProcesoId = 1,
                    InstruccionOperacionId = 1,
                    ClaseId = "CLA",
                    SubClaseId = "SCL",
                    Porcentaje = 60,
                    Orden = i * 10,
                    Ingrediente = new Catalogo
                    {
                        Id = 1,
                        Nombre = "Ingrediente No. 0001"
                    },
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operacion No. 0001"
                    },
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    },
                    InstruccionOperacion = new InstruccionOperacion
                    {
                        Id = 1,
                        Descripcion = "Instrucción de la Operación No. 0001"
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "CLA",
                        Descripcion = "Clase del material"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "SCL",
                        Descripcion = "Sub clase del material"
                    }
                });
            }
            action(lista, null);
        }
        
        #endregion

        #region IngredientePredefinido

        public void IngredientePredefinidoUpdate(IngredientePredefinido ingredientePredefinido,
            Action<IngredientePredefinido, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void IngredientePredefinidoDelete(int ingredientePredefinidoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void IngredientePredefinidoGet(int ingredientePredefinidoId,
            Action<IngredientePredefinido, Exception> action)
        {
            var reg = new IngredientePredefinido
            {
                Id = 1,
                IngredienteId = 1000,
                OperacionId = 2000,
                ClaseId = "3000",
                SubClaseId = "4000",
                Porcentaje = 60,
                Orden = 10,
                InstruccionPredefinidaId = 5000,
                Catalogo = new Catalogo
                {
                    Id = 1000,
                    Nombre = "Catalogo No. 001000",
                    Descripcion = "Descripción del Catalogo No. 001000",
                    MedidaCompraCodigo = "CMP",
                    MedidaConsumoCodigo = "CNS",
                    TipoRequisicionCodigo = "Tipo",
                    GrupoCodigo = "Grp",
                    TelaCodigo = "TELA",
                    CuentaContableCodigo = "CTACTB",
                    CuentaVariableFija = "F",
                    CuentaContableInventarioCodigo = "CTACTBINV",
                    RepuestoNumero = ""
                },
                Operacion = new Operacion
                {
                    Id = 2000,
                    Nombre = "Operación No. 002000",
                    Descripcion = "Descripción de la Operación No. 002000",
                    OperacionTipoId = 2100,
                    GrupoId = 2200,
                    LineaProduccionId = 2300
                },
                Clase = new Clase
                {
                    CompaniaCodigo = 1,
                    Codigo = "0001",
                    ManejaInventario = "S",
                    Descripcion = "Clase No. 0001",
                    CuentaContable = "CTACTB",
                    RotacionBaja = 1000,
                    SinRotacion = 100,
                    Estado = "A",
                    DetalleMaestra = "SS",
                    AgrupacionCodigo = 1000,
                    GrupoNombre = "Grupo No. 1000"
                },
                SubClase = new SubClase
                {
                    CompaniaCodigo = 1,
                    Codigo = "0001-001",
                    Descripcion = "Sub Clase No. 0001-001",
                    Estado = "A"
                },
                InstruccionPredefinida = new InstruccionPredefinida
                {
                    Id = 5000,
                    OperacionPredefinidaId = 6000,
                    Descripcion = "Instrucción Predefinida No. 6000",
                    Orden = 10,
                    TiempoMaximo = 20,
                    TiempoMinimo = 10,
                    Temperatura = 80
                }
            };
            action(reg, null);
        }

        public void IngredientePredefinidoGetAll(Action<List<IngredientePredefinido>, Exception> action)
        {
            var lista = new List<IngredientePredefinido>();

            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredientePredefinido
                {
                    Id = 1,
                    IngredienteId = 1000,
                    OperacionId = 2000,
                    ClaseId = "3000",
                    SubClaseId = "4000",
                    Porcentaje = 60,
                    Orden = 10,
                    InstruccionPredefinidaId = 5000,
                    Catalogo = new Catalogo
                    {
                        Id = 1000,
                        Nombre = "Catalogo No. 001000",
                        Descripcion = "Descripción del Catalogo No. 001000",
                        MedidaCompraCodigo = "CMP",
                        MedidaConsumoCodigo = "CNS",
                        TipoRequisicionCodigo = "Tipo",
                        GrupoCodigo = "Grp",
                        TelaCodigo = "TELA",
                        CuentaContableCodigo = "CTACTB",
                        CuentaVariableFija = "F",
                        CuentaContableInventarioCodigo = "CTACTBINV",
                        RepuestoNumero = ""
                    },
                    Operacion = new Operacion
                    {
                        Id = 2000,
                        Nombre = "Operación No. 002000",
                        Descripcion = "Descripción de la Operación No. 002000",
                        OperacionTipoId = 2100,
                        GrupoId = 2200,
                        LineaProduccionId = 2300
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "0001",
                        ManejaInventario = "S",
                        Descripcion = "Clase No. 0001",
                        CuentaContable = "CTACTB",
                        RotacionBaja = 1000,
                        SinRotacion = 100,
                        Estado = "A",
                        DetalleMaestra = "SS",
                        AgrupacionCodigo = 1000,
                        GrupoNombre = "Grupo No. 1000"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "0001-001",
                        Descripcion = "Sub Clase No. 0001-001",
                        Estado = "A"
                    },
                    InstruccionPredefinida = new InstruccionPredefinida
                    {
                        Id = 5000,
                        OperacionPredefinidaId = 6000,
                        Descripcion = "Instrucción Predefinida No. 6000",
                        Orden = 10,
                        TiempoMaximo = 20,
                        TiempoMinimo = 10,
                        Temperatura = 80
                    }
                });
            }
            action(lista, null);
        }

        public void IngredientePredefinidoGetByInstruccionPredefinida(int instruccionPredefinida,
            Action<List<IngredientePredefinido>, Exception> action)
        {
            var lista = new List<IngredientePredefinido>();

            for (var i = 1; i < 21; i++)
            {
                lista.Add(new IngredientePredefinido
                {
                    Id = 1,
                    IngredienteId = 1000,
                    OperacionId = 2000,
                    ClaseId = "3000",
                    SubClaseId = "4000",
                    Porcentaje = 60,
                    Orden = 10,
                    InstruccionPredefinidaId = 5000,
                    Catalogo = new Catalogo
                    {
                        Id = 1000,
                        Nombre = "Catalogo No. 001000",
                        Descripcion = "Descripción del Catalogo No. 001000",
                        MedidaCompraCodigo = "CMP",
                        MedidaConsumoCodigo = "CNS",
                        TipoRequisicionCodigo = "Tipo",
                        GrupoCodigo = "Grp",
                        TelaCodigo = "TELA",
                        CuentaContableCodigo = "CTACTB",
                        CuentaVariableFija = "F",
                        CuentaContableInventarioCodigo = "CTACTBINV",
                        RepuestoNumero = ""
                    },
                    Operacion = new Operacion
                    {
                        Id = 2000,
                        Nombre = "Operación No. 002000",
                        Descripcion = "Descripción de la Operación No. 002000",
                        OperacionTipoId = 2100,
                        GrupoId = 2200,
                        LineaProduccionId = 2300
                    },
                    Clase = new Clase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "0001",
                        ManejaInventario = "S",
                        Descripcion = "Clase No. 0001",
                        CuentaContable = "CTACTB",
                        RotacionBaja = 1000,
                        SinRotacion = 100,
                        Estado = "A",
                        DetalleMaestra = "SS",
                        AgrupacionCodigo = 1000,
                        GrupoNombre = "Grupo No. 1000"
                    },
                    SubClase = new SubClase
                    {
                        CompaniaCodigo = 1,
                        Codigo = "0001-001",
                        Descripcion = "Sub Clase No. 0001-001",
                        Estado = "A"
                    },
                    InstruccionPredefinida = new InstruccionPredefinida
                    {
                        Id = 5000,
                        OperacionPredefinidaId = 6000,
                        Descripcion = "Instrucción Predefinida No. 6000",
                        Orden = 10,
                        TiempoMaximo = 20,
                        TiempoMinimo = 10,
                        Temperatura = 80
                    }
                });
            }
            action(lista, null);
        }

        #endregion

        #region InstruccionOperacion

        public void InstruccionOperacionUpdate(InstruccionOperacion instruccionOperacion,
            Action<InstruccionOperacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void InstruccionOperacionDelete(int instruccionOperacionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void InstruccionOperacionGet(int instruccionOperacionId, Action<InstruccionOperacion, Exception> action)
        {
            var reg = new InstruccionOperacion
            {
                Id = 1,
                OperacionProcesoId = 1,
                Descripcion = "Descripción de la instrucción de la operación",
                TiempoMinimo = 10,
                TiempoMaximo = 20,
                TiempoEstandar = 15,
                Temperatura = 70,
                Orden = 10,
                OperacionProceso = new OperacionProceso
                {
                    Id = 1,
                }
            };
            action(reg, null);
        }

        public void InstruccionOperacionGetAll(Action<List<InstruccionOperacion>, Exception> action)
        {
            var lista = new List<InstruccionOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new InstruccionOperacion
                {
                    Id = i,
                    OperacionProcesoId = 1,
                    Descripcion = "Descripción de la instrucción de la operación",
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    TiempoEstandar = 15,
                    Temperatura = 70,
                    Orden = i*10,
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    }
                });
            }
            action(lista, null);
        }

        public void InstruccionOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<InstruccionOperacion>, Exception> action)
        {
            var lista = new List<InstruccionOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new InstruccionOperacion
                {
                    Id = i,
                    OperacionProcesoId = 1,
                    Descripcion = "Descripción de la instrucción de la operación",
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    TiempoEstandar = 15,
                    Temperatura = 70,
                    Orden = i * 10,
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    }
                });
            }
            action(lista, null);
        }

        #endregion

        #region InstruccionPredefinida

        public void InstruccionPredefinidaUpdate(InstruccionPredefinida instruccionPredefinida,
            Action<InstruccionPredefinida, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void InstruccionPredefinidaDelete(int instruccionPredefinidaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void InstruccionPredefinidaGet(int instruccionPredefinidaId,
            Action<InstruccionPredefinida, Exception> action)
        {
            var reg = new InstruccionPredefinida
            {
                Id = 1,
                Descripcion = "Instrucción predefinida No. 000001",
                OperacionPredefinidaId = 1000,
                Orden = 10,
                Temperatura = 80,
                TiempoMinimo = 10,
                TiempoMaximo = 20,
                OperacionPredefinida = new OperacionPredefinida
                {
                    Id = 1000,
                    OperacionId = 2000,
                    Ph = "7",
                    RelacionBano = 5,
                    Secuencia = 20,
                    Temperatura = 80,
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    Operacion = new Operacion
                    {
                        Id = 2000,
                        Descripcion = "Descripcion de la Operación No. 002000",
                        GrupoId = 3000,
                        LineaProduccionId = 4000,
                        Nombre = "Operacion No. 002000",
                        OperacionTipoId = 1,
                        OperacionPredefinida = null
                    }
                }
            };
            action(reg, null);
        }

        public void InstruccionPredefinidaGetAll(Action<List<InstruccionPredefinida>, Exception> action)
        {
            var lista = new List<InstruccionPredefinida>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new InstruccionPredefinida
                {
                    Id = 1,
                    Descripcion = $"Instrucción predefinida No. {i.ToString("000000")}",
                    OperacionPredefinidaId = 1000,
                    Orden = i*10,
                    Temperatura = 80,
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    OperacionPredefinida = new OperacionPredefinida
                    {
                        Id = 1000,
                        OperacionId = 2000,
                        Ph = "7",
                        RelacionBano = 5,
                        Secuencia = 20,
                        Temperatura = 80,
                        TiempoMinimo = 10,
                        TiempoMaximo = 20,
                        Operacion = new Operacion
                        {
                            Id = 2000,
                            Descripcion = "Descripcion de la Operación No. 002000",
                            GrupoId = 3000,
                            LineaProduccionId = 4000,
                            Nombre = "Operacion No. 002000",
                            OperacionTipoId = 1,
                            OperacionPredefinida = null
                        }
                    }
                });
            }
            action(lista, null);
        }

        public void InstruccionPredefinidaGetbyOperacionPredefinida(int operacionPredefinidaId,
            Action<List<InstruccionPredefinida>, Exception> action)
        {
            var lista = new List<InstruccionPredefinida>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new InstruccionPredefinida
                {
                    Id = 1,
                    Descripcion = $"Instrucción predefinida No. {i.ToString("000000")}",
                    OperacionPredefinidaId = 1000,
                    Orden = i * 10,
                    Temperatura = 80,
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    OperacionPredefinida = new OperacionPredefinida
                    {
                        Id = 1000,
                        OperacionId = 2000,
                        Ph = "7",
                        RelacionBano = 5,
                        Secuencia = 20,
                        Temperatura = 80,
                        TiempoMinimo = 10,
                        TiempoMaximo = 20,
                        Operacion = new Operacion
                        {
                            Id = 2000,
                            Descripcion = "Descripcion de la Operación No. 002000",
                            GrupoId = 3000,
                            LineaProduccionId = 4000,
                            Nombre = "Operacion No. 002000",
                            OperacionTipoId = 1,
                            OperacionPredefinida = null
                        }
                    }
                });
            }
            action(lista, null);
        }

        #endregion

        #region Lavado

        public void LavadoUpdate(Lavado lavado, Action<Lavado, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavadoDelete(int lavadoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavadoGet(int lavadoId, Action<Lavado, Exception> action)
        {
            var reg = new Lavado
            {
                LavadoId = 1,
                LavadoNombre = "Lavado No. 000001",
                LavadoDescripcion = "Descripción del Lavado No. 000001",
                ColorId = 1,
                EsActivo = 1,
                LavadoFechaCreacion = new DateTime(2016, 1, 1),
                LavadoFechaActualizacion = new DateTime(2016, 5, 20)
            };
            action(reg, null);
        }

        public void LavadoGetAll(Action<List<Lavado>, Exception> action)
        {
            var lista = new List<Lavado>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Lavado
                {
                    LavadoId = i,
                    LavadoNombre = $"Lavado No. {i.ToString("000000")}",
                    LavadoDescripcion = $"Descripción del Lavado No. {i.ToString("000000")}",
                    ColorId = 1,
                    EsActivo = 1,
                    LavadoFechaCreacion = new DateTime(2016, 1, 1),
                    LavadoFechaActualizacion = new DateTime(2016, 5, 20)
                });
            }
            action(lista, null);
        }

        public void LavadoGetByNombre(string lavadoNombre, Action<Lavado, Exception> action)
        {
            var reg = new Lavado
            {
                LavadoId = 1,
                LavadoNombre = "Lavado No. 000001",
                LavadoDescripcion = "Descripción del Lavado No. 000001",
                ColorId = 1,
                EsActivo = 1,
                LavadoFechaCreacion = new DateTime(2016, 1, 1),
                LavadoFechaActualizacion = new DateTime(2016, 5, 20)
            };
            action(reg, null);
        }

        #endregion

        #region Lavadora

        public void LavadoraUpdate(Lavadora lavadora, Action<Lavadora, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavadoraDelete(short lavadoraId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavadoraGet(short lavadoraId, Action<Lavadora, Exception> action)
        {
            var reg = new Lavadora
            {
                Id = 1,
                LavadoraCapacidadId = 1,
                LavadoraCapacidad = new LavadoraCapacidad
                {
                    Id = 1,
                    CapacidadMinimaKg = 100,
                    CapacidadMaximaKg = 200,
                    CapacidadCanastaLitro = 300
                },
                DireccionIp = "192.168.1,120",
                DireccionMac = "ABCDEFABCDEF",
                Estado = 1,
                Marca = "Secadora Marca Xxxx",
                Modelo = "Lavadora Modelo Yyyy",
                Nombre = "Nombre de la Lavadora No. 1",
                NumeroSerie = "ABC123456789XYZ"
            };
            action(reg, null);
        }

        public void LavadoraGetAll(Action<List<Lavadora>, Exception> action)
        {
            var lista = new List<Lavadora>();
            for (short i = 1; i < 21; i++)
            {
                lista.Add(new Lavadora
                {
                    Id = i,
                    LavadoraCapacidadId = 1,
                    LavadoraCapacidad = new LavadoraCapacidad
                    {
                        Id = 1,
                        CapacidadMinimaKg = 100,
                        CapacidadMaximaKg = 200,
                        CapacidadCanastaLitro = 300
                    },
                    DireccionIp = "192.168.1,120",
                    DireccionMac = "ABCDEFABCDEF",
                    Estado = 1,
                    Marca = "Secadora Marca Xxxx",
                    Modelo = "Lavadora Modelo Yyyy",
                    Nombre = $"Nombre de la Lavadora No. {i.ToString("00")}",
                    NumeroSerie = "ABC123456789XYZ"
                });
            }
            action(lista, null);
        }

        public void LavadoraGetByCapacidad(short lavadoraCapacidadId, Action<List<Lavadora>, Exception> action)
        {
            var lista = new List<Lavadora>();
            for (short i = 1; i < 21; i++)
            {
                lista.Add(new Lavadora
                {
                    Id = i,
                    LavadoraCapacidadId = 1,
                    LavadoraCapacidad = new LavadoraCapacidad
                    {
                        Id = 1,
                        CapacidadMinimaKg = 100,
                        CapacidadMaximaKg = 200,
                        CapacidadCanastaLitro = 300
                    },
                    DireccionIp = "192.168.1,120",
                    DireccionMac = "ABCDEFABCDEF",
                    Estado = 1,
                    Marca = "Secadora Marca Xxxx",
                    Modelo = "Lavadora Modelo Yyyy",
                    Nombre = $"Nombre de la Lavadora No. {i.ToString("00")}",
                    NumeroSerie = "ABC123456789XYZ"
                });
            }
            action(lista, null);
        }


        #endregion

        #region LavadoraCapacidad

        public void LavadoraCapacidadUpdate(LavadoraCapacidad lavadoraCapacidad, Action<LavadoraCapacidad, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavadoraCapacidadDelete(short lavadoraCapacidadId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void LavadoraCapacidadGet(short lavadoraCapacidadId, Action<LavadoraCapacidad, Exception> action)
        {
            var reg = new LavadoraCapacidad
            {
                Id = 1,
                CapacidadMinimaKg = 100,
                CapacidadMaximaKg = 200,
                CapacidadCanastaLitro = 300
            };
            action(reg, null);
        }

        public void LavadoraCapacidadGetAll(Action<List<LavadoraCapacidad>, Exception> action)
        {
            var lista = new List<LavadoraCapacidad>();
            for (short i = 1; i < 21; i++)
            {
                lista.Add(new LavadoraCapacidad
                {
                    Id = 1,
                    CapacidadMinimaKg = 100,
                    CapacidadMaximaKg = 200,
                    CapacidadCanastaLitro = 300
                });
            }
            action(lista, null);
        }


        #endregion

        #region Maquina

        public void MaquinaUpdate(Maquina maquina, Action<Maquina, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquinaDelete(MaquinaTipo tipo, int maquinaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquinaGet(MaquinaTipo tipo, int maquinaId, Action<Maquina, Exception> action)
        {
            var reg = new Maquina
            {
                Tipo = MaquinaTipo.Lavadora,
                Id = 1,
                CapacidadId = 1,
                Capacidad = new MaquinaCapacidad
                {
                    Id = 1,
                    CapacidadMinimaKg = 100,
                    CapacidadMaximaKg = 200,
                    CapacidadCanastaLitro = 300
                },
                DireccionIp = "192.168.1,120",
                DireccionMac = "ABCDEFABCDEF",
                Estado = 1,
                Marca = "Secadora Marca Xxxx",
                Modelo = "Lavadora Modelo Yyyy",
                Nombre = "Nombre de la Lavadora No. 1",
                NumeroSerie = "ABC123456789XYZ"
            };
            action(reg, null);
        }

        public void MaquinaGetAll(Action<List<Maquina>, Exception> action)
        {
            var lista = new List<Maquina>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Maquina
                {
                    Tipo = MaquinaTipo.Lavadora,
                    Id = (short)i,
                    CapacidadId = 1,
                    Capacidad = new MaquinaCapacidad
                    {
                        Id = 1,
                        CapacidadMinimaKg = 100,
                        CapacidadMaximaKg = 200,
                        CapacidadCanastaLitro = 300
                    },
                    DireccionIp = "192.168.1,120",
                    DireccionMac = "ABCDEFABCDEF",
                    Estado = 1,
                    Marca = "Secadora Marca Xxxx",
                    Modelo = "Lavadora Modelo Yyyy",
                    Nombre = "Nombre de la Lavadora No. 1",
                    NumeroSerie = "ABC123456789XYZ"
                });
            }
            action(lista, null);
        }

        public void MaquinaGetByTipo(MaquinaTipo tipo, Action<List<Maquina>, Exception> action)
        {
            var lista = new List<Maquina>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Maquina
                {
                    Tipo = MaquinaTipo.Lavadora,
                    Id = (short)i,
                    CapacidadId = 1,
                    Capacidad = new MaquinaCapacidad
                    {
                        Id = 1,
                        CapacidadMinimaKg = 100,
                        CapacidadMaximaKg = 200,
                        CapacidadCanastaLitro = 300
                    },
                    DireccionIp = "192.168.1,120",
                    DireccionMac = "ABCDEFABCDEF",
                    Estado = 1,
                    Marca = "Secadora Marca Xxxx",
                    Modelo = "Lavadora Modelo Yyyy",
                    Nombre = "Nombre de la Lavadora No. 1",
                    NumeroSerie = "ABC123456789XYZ"
                });
            }
            action(lista, null);
        }

        public void MaquinaGetByTipoCapcacidad(MaquinaTipo tipo, int capacidadId, Action<List<Maquina>, Exception> action)
        {
            var lista = new List<Maquina>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Maquina
                {
                    Tipo = MaquinaTipo.Lavadora,
                    Id = (short)i,
                    CapacidadId = 1,
                    Capacidad = new MaquinaCapacidad
                    {
                        Id = 1,
                        CapacidadMinimaKg = 100,
                        CapacidadMaximaKg = 200,
                        CapacidadCanastaLitro = 300
                    },
                    DireccionIp = "192.168.1,120",
                    DireccionMac = "ABCDEFABCDEF",
                    Estado = 1,
                    Marca = "Secadora Marca Xxxx",
                    Modelo = "Lavadora Modelo Yyyy",
                    Nombre = "Nombre de la Lavadora No. 1",
                    NumeroSerie = "ABC123456789XYZ"
                });
            }
            action(lista, null);
        }

        #endregion

        #region MaquinaCapacidad

        public void MaquinaCapacidadUpdate(MaquinaCapacidad maquinaCapacidad, Action<MaquinaCapacidad, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquinaCapacidadDelete(MaquinaTipo tipo, int maquinaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquinaCapacidadGet(MaquinaTipo tipo, int maquinaId, Action<MaquinaCapacidad, Exception> action)
        {
            var reg = new MaquinaCapacidad
            {
                Id = 1,
                CapacidadMinimaKg = 100,
                CapacidadMaximaKg = 200,
                CapacidadCanastaLitro = 300
            };
            action(reg, null);
        }

        public void MaquinaCapacidadGetAll(Action<List<MaquinaCapacidad>, Exception> action)
        {
            var lista = new List<MaquinaCapacidad>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new MaquinaCapacidad
                {
                    Id = (short)i,
                    CapacidadMinimaKg = 100,
                    CapacidadMaximaKg = 200,
                    CapacidadCanastaLitro = 300
                });
            }
            action(lista, null);
        }

        public void MaquinaCapacidadGetByTipo(MaquinaTipo tipo, Action<List<MaquinaCapacidad>, Exception> action)
        {
            var lista = new List<MaquinaCapacidad>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new MaquinaCapacidad
                {
                    Id = (short)i,
                    CapacidadMinimaKg = 100,
                    CapacidadMaximaKg = 200,
                    CapacidadCanastaLitro = 300
                });
            }
            action(lista, null);
        }

        #endregion

        #region ObservacionPredefinida

        public void ObservacionPredefinidaUpdate(ObservacionPredefinida observacionPredefinida,
            Action<ObservacionPredefinida, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ObservacionPredefinidaDelete(int observacionPredefinidaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ObservacionPredefinidaGet(int observacionPredefinidaId,
            Action<ObservacionPredefinida, Exception> action)
        {
            var reg = new ObservacionPredefinida
            {
                Id = 1,
                Descripcion = "Observación Predefinida No. 000001",
                Orden = 10,
                Posicion = 20,
                OperacionId = 1000,
                Operacion = new Operacion
                {
                    Id = 1000,
                    Descripcion = "Descripción de la Operación No. 001000",
                    GrupoId = 2000,
                    LineaProduccionId = 3000,
                    Nombre = "Operacion No. 001000",
                    OperacionTipoId = 4000,
                    OperacionPredefinida = new OperacionPredefinida
                    {
                        Id = 5000,
                        Operacion = null,
                        OperacionId = 1000,
                        Ph = "7",
                        RelacionBano = 3,
                        Secuencia = 10,
                        Temperatura = 60,
                        TiempoMaximo = 10,
                        TiempoMinimo = 5
                    }
                }
            };

            action(reg, null);
        }

        public void ObservacionPredefinidaGetAll(Action<List<ObservacionPredefinida>, Exception> action)
        {
            var lista = new List<ObservacionPredefinida>();

            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ObservacionPredefinida
                {
                    Id = i,
                    Descripcion = $"Observación Predefinida No. {i.ToString("000000")}",
                    Orden = 10,
                    Posicion = 20,
                    OperacionId = 1000,
                    Operacion = new Operacion
                    {
                        Id = 1000,
                        Descripcion = "Descripción de la Operación No. 001000",
                        GrupoId = 2000,
                        LineaProduccionId = 3000,
                        Nombre = "Operacion No. 001000",
                        OperacionTipoId = 4000,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = 5000,
                            Operacion = null,
                            OperacionId = 1000,
                            Ph = "7",
                            RelacionBano = 3,
                            Secuencia = 10,
                            Temperatura = 60,
                            TiempoMaximo = 10,
                            TiempoMinimo = 5
                        }
                    }
                });
                action(lista, null);
            }
        }

        public void ObservacionPredefinidaGetByOperacion(int operacionId,
            Action<List<ObservacionPredefinida>, Exception> action)
        {
            var lista = new List<ObservacionPredefinida>();

            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ObservacionPredefinida
                {
                    Id = i,
                    Descripcion = $"Observación Predefinida No. {i.ToString("000000")}",
                    Orden = 10,
                    Posicion = 20,
                    OperacionId = 1000,
                    Operacion = new Operacion
                    {
                        Id = 1000,
                        Descripcion = "Descripción de la Operación No. 001000",
                        GrupoId = 2000,
                        LineaProduccionId = 3000,
                        Nombre = "Operacion No. 001000",
                        OperacionTipoId = 4000,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = 5000,
                            Operacion = null,
                            OperacionId = 1000,
                            Ph = "7",
                            RelacionBano = 3,
                            Secuencia = 10,
                            Temperatura = 60,
                            TiempoMaximo = 10,
                            TiempoMinimo = 5
                        }
                    }
                });
                action(lista, null);
            }
        }

        #endregion

        #region ObservacionOperacion

        public void ObservacionOperacionUpdate(ObservacionOperacion observacionOperacion,
            Action<ObservacionOperacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ObservacionOperacionDelete(int observacionOperacionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ObservacionOperacionGet(int observacionOperacionId, Action<ObservacionOperacion, Exception> action)
        {
            var reg = new ObservacionOperacion
            {
                Id = 1,
                OperacionProcesoId = 1,
                Descripcion = "Descripción de la observación de la operación",
                Orden = 10,
                Posicion = 15,
                OperacionProceso = new OperacionProceso
                {
                    Id = 1,
                }
            };
            action(reg, null);
        }

        public void ObservacionOperacionGetAll(Action<List<ObservacionOperacion>, Exception> action)
        {
            var lista = new List<ObservacionOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ObservacionOperacion
                {
                    Id = i,
                    OperacionProcesoId = 1,
                    Descripcion = "Descripción de la observación de la operación",
                    Orden = i * 10,
                    Posicion = i * 10 + 5,

                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    }
                });
            }
            action(lista, null);
        }

        public void ObservacionOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<ObservacionOperacion>, Exception> action)
        {
            var lista = new List<ObservacionOperacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new ObservacionOperacion
                {
                    Id = i,
                    OperacionProcesoId = 1,
                    Descripcion = "Descripción de la observación de la operación",
                    Orden = i * 10,
                    Posicion = i*10+5,
                    OperacionProceso = new OperacionProceso
                    {
                        Id = 1,
                    }
                });
            }
            action(lista, null);
        }

        #endregion

        #region OpcionLavado

        public void OpcionLavadoUpdate(OpcionLavado opcionLavado, Action<OpcionLavado, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OpcionLavadoDelete(int opcionLavadoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OpcionLavadoGet(int opcionLavadoId, Action<OpcionLavado, Exception> action)
        {
            var reg = new OpcionLavado
            {
                Id = 1,
                Descripcion = "Descripción de la Opción de Lavado No. 000001",
                IsDefault = 0,
                Lavado = new Lavado
                {
                    LavadoId = 1,
                    LavadoNombre = "Nombre del Lavado No. 000001",
                    LavadoDescripcion = "Descripción del Lavado No. 000001",
                    ColorId = 1,
                    ColorIntermoda = new ColorIntermoda
                    {
                        Id = 1,
                        Nombre = "Nombre del Color No. 001"
                    },
                    EsActivo = 1,
                    LavadoFechaActualizacion = new DateTime(2016, 1, 1),
                    LavadoFechaCreacion = new DateTime(2016, 1, 1),
                },
                LavadoId = 1,
                Nombre = "Nombre de la Opción de Lavado No. 000001",
                Tela = new Tela
                {
                    TelaCodigo = "TELA",
                    ComposicionNombre = "Composición",
                    MaterialCodigo = 1,
                    TelaDescripcion = "Descripción de la Tela",
                    TelaNombre = "Nombre de la Tela"
                },
                TelaId = "TELA"
            };

            action(reg, null);
        }

        public void OpcionLavadoGetAll(Action<List<OpcionLavado>, Exception> action)
        {
            var lista = new List<OpcionLavado>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OpcionLavado
                {
                    Id = i,
                    Descripcion = "Descripción de la Opción de Lavado No. 000001",
                    IsDefault = 0,
                    Lavado = new Lavado
                    {
                        LavadoId = 1,
                        LavadoNombre = "Nombre del Lavado No. 000001",
                        LavadoDescripcion = "Descripción del Lavado No. 000001",
                        ColorId = 1,
                        ColorIntermoda = new ColorIntermoda
                        {
                            Id = 1,
                            Nombre = "Nombre del Color No. 001"
                        },
                        EsActivo = 1,
                        LavadoFechaActualizacion = new DateTime(2016, 1, 1),
                        LavadoFechaCreacion = new DateTime(2016, 1, 1),
                    },
                    LavadoId = 1,
                    Nombre = "Nombre de la Opción de Lavado No. 000001",
                    Tela = new Tela
                    {
                        TelaCodigo = "TELA",
                        ComposicionNombre = "Composición",
                        MaterialCodigo = 1,
                        TelaDescripcion = "Descripción de la Tela",
                        TelaNombre = "Nombre de la Tela"
                    },
                    TelaId = "TELA"
                });
            }
            action(lista, null);
        }

        public void OpcionLavadoGetByLavado(int lavadoId, Action<List<OpcionLavado>, Exception> action)
        {
            var lista = new List<OpcionLavado>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OpcionLavado
                {
                    Id = i,
                    Descripcion = "Descripción de la Opción de Lavado No. 000001",
                    IsDefault = 0,
                    Lavado = new Lavado
                    {
                        LavadoId = 1,
                        LavadoNombre = "Nombre del Lavado No. 000001",
                        LavadoDescripcion = "Descripción del Lavado No. 000001",
                        ColorId = 1,
                        ColorIntermoda = new ColorIntermoda
                        {
                            Id = 1,
                            Nombre = "Nombre del Color No. 001"
                        },
                        EsActivo = 1,
                        LavadoFechaActualizacion = new DateTime(2016, 1, 1),
                        LavadoFechaCreacion = new DateTime(2016, 1, 1),
                    },
                    LavadoId = 1,
                    Nombre = "Nombre de la Opción de Lavado No. 000001",
                    Tela = new Tela
                    {
                        TelaCodigo = "TELA",
                        ComposicionNombre = "Composición",
                        MaterialCodigo = 1,
                        TelaDescripcion = "Descripción de la Tela",
                        TelaNombre = "Nombre de la Tela"
                    },
                    TelaId = "TELA"
                });
            }
            action(lista, null);
        }

        public void OpcionLavadoGetByTela(string telaId, Action<List<OpcionLavado>, Exception> action)
        {
            var lista = new List<OpcionLavado>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OpcionLavado
                {
                    Id = i,
                    Descripcion = "Descripción de la Opción de Lavado No. 000001",
                    IsDefault = 0,
                    Lavado = new Lavado
                    {
                        LavadoId = 1,
                        LavadoNombre = "Nombre del Lavado No. 000001",
                        LavadoDescripcion = "Descripción del Lavado No. 000001",
                        ColorId = 1,
                        ColorIntermoda = new ColorIntermoda
                        {
                            Id = 1,
                            Nombre = "Nombre del Color No. 001"
                        },
                        EsActivo = 1,
                        LavadoFechaActualizacion = new DateTime(2016, 1, 1),
                        LavadoFechaCreacion = new DateTime(2016, 1, 1),
                    },
                    LavadoId = 1,
                    Nombre = "Nombre de la Opción de Lavado No. 000001",
                    Tela = new Tela
                    {
                        TelaCodigo = "TELA",
                        ComposicionNombre = "Composición",
                        MaterialCodigo = 1,
                        TelaDescripcion = "Descripción de la Tela",
                        TelaNombre = "Nombre de la Tela"
                    },
                    TelaId = "TELA"
                });
            }
            action(lista, null);
        }

        #endregion

        #region Operacion

        public void OperacionUpdate(Operacion operacion, Action<Operacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionDelete(int operacionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionGet(int operacionId, Action<Operacion, Exception> action)
        {
            var reg = new Operacion
            {
                Id = 1000,
                Descripcion = "Descripción de la Operación No. 001000",
                GrupoId = 2000,
                LineaProduccionId = 3000,
                Nombre = "Operacion No. 001000",
                OperacionPredefinida = new OperacionPredefinida
                {
                    Id = 4000,
                    Operacion = null,
                    OperacionId = 1000,
                    Ph = "7",
                    RelacionBano = 5,
                    Secuencia = 20,
                    Temperatura = 80,
                    TiempoMinimo = 20,
                    TiempoMaximo = 30
                }
            };
            action(reg, null);
        }

        public void OperacionGetAll(Action<List<Operacion>, Exception> action)
        {
            var lista = new List<Operacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Operacion
                {
                    Id = (short)i,
                    Nombre = $"Operacion No. {i.ToString("000000")}",
                    Descripcion = $"Descripción de la Operación No. {i.ToString("000000")}",
                    GrupoId = 1000,
                    LineaProduccionId = 2000,
                    OperacionTipoId = 3000,
                    OperacionPredefinida = new OperacionPredefinida
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

        public void OperacionGetAllLavanderia(Action<List<Operacion>, Exception> action)
        {
            var lista = new List<Operacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Operacion
                {
                    Id = (short)i,
                    Nombre = $"Operacion No. {i.ToString("000000")}",
                    Descripcion = $"Descripción de la Operación No. {i.ToString("000000")}",
                    GrupoId = 1000,
                    LineaProduccionId = 2000,
                    OperacionTipoId = 3000,
                    OperacionPredefinida = new OperacionPredefinida
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

        public void OperacionGetOperacionesHumedas(int centrotrabajoId, Action<List<Operacion>, Exception> action)
        {
            var lista = new List<Operacion>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Operacion
                {
                    Id = (short)i,
                    Nombre = $"Operacion No. {i.ToString("000000")}",
                    Descripcion = $"Descripción de la Operación No. {i.ToString("000000")}",
                    GrupoId = 1000,
                    LineaProduccionId = 2000,
                    OperacionTipoId = 3000,
                    OperacionPredefinida = new OperacionPredefinida
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

        public void OperacionCentroTrabajoUpdate(OperacionCentroTrabajo operacionCentroTrabajo,
            Action<OperacionCentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionCentroTrabajoDelete(int opeacionCentroTrabajoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionCentroTrabajoGet(int opeacionCentroTrabajoId,
            Action<OperacionCentroTrabajo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionCentroTrabajoGetAll(
            Action<List<OperacionCentroTrabajo>, Exception> action)
        {
            var lista = new List<OperacionCentroTrabajo>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OperacionCentroTrabajo
                {
                    Id = 1,
                    CentroTrabajo = new CentroTrabajo
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
                    Operacion = new Operacion
                    {
                        Id = 20,
                        Descripcion = "Descripción de la Operación No. 000020",
                        GrupoId = 200,
                        LineaProduccionId = 100,
                        Nombre = "Nombre de la Operacion No. 000020",
                        OperacionTipoId = 300,
                        OperacionPredefinida = new OperacionPredefinida
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

        public void OperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = new List<OperacionCentroTrabajo>();
                for (var i = 1; i < 21; i++)
                {
                    lista.Add(new OperacionCentroTrabajo
                    {
                        Id = 1,
                        CentroTrabajo = new CentroTrabajo
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
                        Operacion = new Operacion
                        {
                            Id = 20,
                            Descripcion = "Descripción de la Operación No. 000020",
                            GrupoId = 200,
                            LineaProduccionId = 100,
                            Nombre = "Nombre de la Operacion No. 000020",
                            OperacionTipoId = 300,
                            OperacionPredefinida = new OperacionPredefinida
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

        public void OperacionCentroTrabajoGetByOperacion(short opeacionId,
            Action<List<OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = new List<OperacionCentroTrabajo>();
                for (var i = 1; i < 21; i++)
                {
                    lista.Add(new OperacionCentroTrabajo
                    {
                        Id = 1,
                        CentroTrabajo = new CentroTrabajo
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
                        Operacion = new Operacion
                        {
                            Id = 20,
                            Descripcion = "Descripción de la Operación No. 000020",
                            GrupoId = 200,
                            LineaProduccionId = 100,
                            Nombre = "Nombre de la Operacion No. 000020",
                            OperacionTipoId = 300,
                            OperacionPredefinida = new OperacionPredefinida
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

        #region OperacionPredefinida

        public void OperacionPredefinidaUpdate(OperacionPredefinida operacionPredefinida,
            Action<OperacionPredefinida, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionPredefinidaDelete(int operacionPredefinidaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionPredefinidaGet(int operacionPredefinidaId,
            Action<OperacionPredefinida, Exception> action)
        {
            var reg = new OperacionPredefinida
            {
                Id = 1,
                OperacionId = 1000,
                Ph = "7",
                Temperatura = 80,
                RelacionBano = 5,
                Secuencia = 10,
                TiempoMinimo = 10,
                TiempoMaximo = 20,
                Operacion = new Operacion
                {
                    Id = 1000,
                    Descripcion = "Descripción de la Operacion No. 001000",
                    GrupoId = 2000,
                    LineaProduccionId = 3000,
                    Nombre = "Operacion No. 001000",
                    OperacionPredefinida = null,
                    OperacionTipoId = 4000
                }
            };
            action(reg, null);
        }

        public void OperacionPredefinidaGetSingle(int operacionPredefinidaId,
            Action<OperacionPredefinida, Exception> action)
        {
            var reg = new OperacionPredefinida
            {
                Id = 1,
                OperacionId = 1000,
                Ph = "7",
                Temperatura = 80,
                RelacionBano = 5,
                Secuencia = 10,
                TiempoMinimo = 10,
                TiempoMaximo = 20,
                Operacion = new Operacion
                {
                    Id = 1000,
                    Descripcion = "Descripción de la Operacion No. 001000",
                    GrupoId = 2000,
                    LineaProduccionId = 3000,
                    Nombre = "Operacion No. 001000",
                    OperacionPredefinida = null,
                    OperacionTipoId = 4000
                }
            };
            action(reg, null);
        }

        public void OperacionPredefinidaGetAll(Action<List<OperacionPredefinida>, Exception> action)
        {
            var lista = new List<OperacionPredefinida>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OperacionPredefinida
                {
                    Id = i,
                    OperacionId = 1000,
                    Ph = "7",
                    Temperatura = 80,
                    RelacionBano = 5,
                    Secuencia = i * 10,
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    Operacion = new Operacion
                    {
                        Id = 1000,
                        Descripcion = "Descripción de la Operacion No. 001000",
                        GrupoId = 2000,
                        LineaProduccionId = 3000,
                        Nombre = "Operacion No. 001000",
                        OperacionPredefinida = null,
                        OperacionTipoId = 4000
                    }
                });
                action(lista, null);
            }
        }

        #endregion

        #region OperacionProceso

        public void OperacionProcesoUpdate(OperacionProceso operacionProceso, Action<OperacionProceso, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionProcesoDelete(int operacionProcesoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OperacionProcesoGet(int operacionProcesoId, Action<OperacionProceso, Exception> action)
        {
            var reg = new OperacionProceso
            {
                Id = 1,
                OperacionId = 1,
                ProcesoId = 1,
                ProcesoCentroTrabajoId = 1,
                Temperatura = 70,
                Ph = "7",
                TiempoMinimo = 10,
                TiempoMaximo = 20,
                TiempoEstandar = 15,
                RelacionBano = 3,
                Orden = 10,
                Operacion = new Operacion
                {
                    Id = 1,
                    Nombre = "Operación No. 001",
                    Descripcion = "Descripción de la Operación No. 001",
                    GrupoId = 1,
                    LineaProduccionId = 1,
                    OperacionTipoId = 1
                },
                Proceso = new Proceso
                {
                    Id = 1,
                    Nombre = "Nombre del Proceso No. 001",
                    Descripcion = "Descripción del Proceso No. 001",
                    Secuencia = 10,
                    EsActivo = true,
                    EsObligatorio = true,
                    CentroTrabajoId = 1,
                    TiempoEstandar = 15
                },
                ProcesoCentroTrabajo = new ProcesoCentroTrabajo
                {
                    Id = 1,
                    ProcesoId = 1,
                    CentroTrabajoId = 1,
                    CentroTrabajoOpcionId = 1,
                    Orden = 10
                }
            };
            action(reg, null);
        }

        public void OperacionProcesoGetAll(Action<List<OperacionProceso>, Exception> action)
        {
            var lista = new List<OperacionProceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OperacionProceso
                {
                    Id = 1,
                    OperacionId = 1,
                    ProcesoId = 1,
                    ProcesoCentroTrabajoId = 1,
                    Temperatura = 70,
                    Ph = "7",
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    TiempoEstandar = 15,
                    RelacionBano = 3,
                    Orden = 10,
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operación No. 001",
                        Descripcion = "Descripción de la Operación No. 001",
                        GrupoId = 1,
                        LineaProduccionId = 1,
                        OperacionTipoId = 1
                    },
                    Proceso = new Proceso
                    {
                        Id = 1,
                        Nombre = "Nombre del Proceso No. 001",
                        Descripcion = "Descripción del Proceso No. 001",
                        Secuencia = 10,
                        EsActivo = true,
                        EsObligatorio = true,
                        CentroTrabajoId = 1,
                        TiempoEstandar = 15
                    },
                    ProcesoCentroTrabajo = new ProcesoCentroTrabajo
                    {
                        Id = 1,
                        ProcesoId = 1,
                        CentroTrabajoId = 1,
                        CentroTrabajoOpcionId = 1,
                        Orden = 10
                    }
                });
            }
            action(lista, null);
        }

        public void OperacionProcesoGetByOperacion(int operacionId, Action<List<OperacionProceso>, Exception> action)
        {
            var lista = new List<OperacionProceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OperacionProceso
                {
                    Id = 1,
                    OperacionId = 1,
                    ProcesoId = 1,
                    ProcesoCentroTrabajoId = 1,
                    Temperatura = 70,
                    Ph = "7",
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    TiempoEstandar = 15,
                    RelacionBano = 3,
                    Orden = 10,
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operación No. 001",
                        Descripcion = "Descripción de la Operación No. 001",
                        GrupoId = 1,
                        LineaProduccionId = 1,
                        OperacionTipoId = 1
                    },
                    Proceso = new Proceso
                    {
                        Id = 1,
                        Nombre = "Nombre del Proceso No. 001",
                        Descripcion = "Descripción del Proceso No. 001",
                        Secuencia = 10,
                        EsActivo = true,
                        EsObligatorio = true,
                        CentroTrabajoId = 1,
                        TiempoEstandar = 15
                    },
                    ProcesoCentroTrabajo = new ProcesoCentroTrabajo
                    {
                        Id = 1,
                        ProcesoId = 1,
                        CentroTrabajoId = 1,
                        CentroTrabajoOpcionId = 1,
                        Orden = 10
                    }
                });
            }
            action(lista, null);
        }

        public void OperacionProcesoGetByProceso(int procesoId, Action<List<OperacionProceso>, Exception> action)
        {
            var lista = new List<OperacionProceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OperacionProceso
                {
                    Id = 1,
                    OperacionId = 1,
                    ProcesoId = 1,
                    ProcesoCentroTrabajoId = 1,
                    Temperatura = 70,
                    Ph = "7",
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    TiempoEstandar = 15,
                    RelacionBano = 3,
                    Orden = 10,
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operación No. 001",
                        Descripcion = "Descripción de la Operación No. 001",
                        GrupoId = 1,
                        LineaProduccionId = 1,
                        OperacionTipoId = 1
                    },
                    Proceso = new Proceso
                    {
                        Id = 1,
                        Nombre = "Nombre del Proceso No. 001",
                        Descripcion = "Descripción del Proceso No. 001",
                        Secuencia = 10,
                        EsActivo = true,
                        EsObligatorio = true,
                        CentroTrabajoId = 1,
                        TiempoEstandar = 15
                    },
                    ProcesoCentroTrabajo = new ProcesoCentroTrabajo
                    {
                        Id = 1,
                        ProcesoId = 1,
                        CentroTrabajoId = 1,
                        CentroTrabajoOpcionId = 1,
                        Orden = 10
                    }
                });
            }
            action(lista, null);
        }

        public void OperacionProcesoGetByProcesoCentroTrabajo(int procesoCentroTrabajoId,
            Action<List<OperacionProceso>, Exception> action)
        {
            var lista = new List<OperacionProceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OperacionProceso
                {
                    Id = 1,
                    OperacionId = 1,
                    ProcesoId = 1,
                    ProcesoCentroTrabajoId = 1,
                    Temperatura = 70,
                    Ph = "7",
                    TiempoMinimo = 10,
                    TiempoMaximo = 20,
                    TiempoEstandar = 15,
                    RelacionBano = 3,
                    Orden = 10,
                    Operacion = new Operacion
                    {
                        Id = 1,
                        Nombre = "Operación No. 001",
                        Descripcion = "Descripción de la Operación No. 001",
                        GrupoId = 1,
                        LineaProduccionId = 1,
                        OperacionTipoId = 1
                    },
                    Proceso = new Proceso
                    {
                        Id = 1,
                        Nombre = "Nombre del Proceso No. 001",
                        Descripcion = "Descripción del Proceso No. 001",
                        Secuencia = 10,
                        EsActivo = true,
                        EsObligatorio = true,
                        CentroTrabajoId = 1,
                        TiempoEstandar = 15
                    },
                    ProcesoCentroTrabajo = new ProcesoCentroTrabajo
                    {
                        Id = 1,
                        ProcesoId = 1,
                        CentroTrabajoId = 1,
                        CentroTrabajoOpcionId = 1,
                        Orden = 10
                    }
                });
            }
            action(lista, null);
        }

        #endregion

        #region OrdenProduccionLavanderia

        public void OrdenProduccionLavanderiaGet(short companiaId, int plantaId, short centroTrabajoId,
            Action<List<OrdenProduccionLavanderia>, Exception> action)
        {
            var lista = new List<OrdenProduccionLavanderia>();
            for (var i = 1; i < 41; i++)
            {
                lista.Add(new OrdenProduccionLavanderia
                {
                    CompaniaId = 1,
                    PlantaId = 1,
                    CentroTrabajoId = 1,
                    Ano = 16,
                    Numero = (short)i,
                    Patron = "VI812",
                    Variante = $"V{i.ToString("00")}",
                    LavadoCodigoOld = $"L{i.ToString("00")}",
                    Estado = "A",
                    FechaInicioProgramada = new DateTime(2016,1,1),
                    FechaFinalProgramada = new DateTime(2016,1,15),
                    TelaProduccionCodigo = "TPR",
                    TelaVentaCodigo = "TVT",
                    Usuario = "USER",
                    Cantidad = 500,
                    CantidadFinalEnsamble = 500,
                    CantidadEntradaLavanderia2 = 350,
                    CantidadPendiente = 150,
                    LavadoId = i,
                    LavadoNombre = $"Lavado No. {i.ToString("000")}",
                    PesoUnidad = (decimal)1.35
                });
            }
            action(lista, null);
        }

        #endregion

        #region Planta

        public void PlantaUpdate(Planta planta, Action<Planta, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void PlantaDelete(int plantaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void PlantaGet(int plantaId, Action<Planta, Exception> action)
        {
            var reg = new Planta
            {
                Id = 1,
                Nombre = "Nombre de la Planta No. 1",
                Observacion = "Observaciones de la Planta No. 1",
                Propietaria = true,
                CompaniaId = 1
            };
            action(reg, null);
        }

        public void PlantaGetAll(Action<List<Planta>, Exception> action)
        {
            var lista = new List<Planta>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Planta
                {
                    Id = i,
                    Nombre = $"Nombre de la Planta No. {i.ToString("00")}",
                    Observacion = $"Observaciones de la Planta No. {i.ToString("00")}",
                    Propietaria = true,
                    CompaniaId = 1
                });
            }
            action(lista, null);
        }

        public void PlantaGetByCompania(int companiaId, Action<List<Planta>, Exception> action)
        {
            var lista = new List<Planta>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Planta
                {
                    Id = i,
                    Nombre = $"Nombre de la Planta No. {i.ToString("00")}",
                    Observacion = $"Observaciones de la Planta No. {i.ToString("00")}",
                    Propietaria = true,
                    CompaniaId = 1
                });
            }
            action(lista, null);
        }

        #endregion

        #region Proceso

        public void ProcesoUpdate(Proceso proceso, Action<Proceso, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ProcesoDelete(int procesoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ProcesoGet(int procesoId, Action<Proceso, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ProcesoGetAll(Action<List<Proceso>, Exception> action)
        {
            var lista = new List<Proceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Proceso
                {
                    Id = i,
                    Nombre = $"Proceso No. {i.ToString("000000")}",
                    Descripcion = $"Descripción del Proceso No. {i.ToString("000000")}",
                    CentroTrabajoId = 1000,
                    CentroTrabajo = new CentroTrabajo
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

        public void ProcesoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<Proceso>, Exception> action)
        {
            var lista = new List<Proceso>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Proceso
                {
                    Id = i,
                    Nombre = $"Proceso No. {i.ToString("000000")}",
                    Descripcion = $"Descripción del Proceso No. {i.ToString("000000")}",
                    CentroTrabajoId = 1000,
                    CentroTrabajo = new CentroTrabajo
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

        #region ProcesoCentroTrabajo

        public void ProcesoCentroTrabajoUpdate(ProcesoCentroTrabajo procesoCentroTrabajo,
            Action<ProcesoCentroTrabajo, Exception> action)
        {
            
        }

        public void ProcesoCentroTrabajoDelete(int procesoCentroTrabajoId, Action<Exception> action)
        {
            
        }

        public void ProcesoCentroTrabajoGet(int procesoCentroTrabajoId, Action<ProcesoCentroTrabajo, Exception> action)
        {
            
        }

        public void ProcesoCentroTrabajoGetAll(Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            
        }

        public void ProcesoCentroTrabajoGetByProceso(int procesoId, Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            
        }

        public void ProcesoCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            
        }

        public void ProcesoCentroTrabajoGetByCentroTrabajoOpcion(int centroTrabajoOpcionId,
            Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            
        }

        #endregion

        #region Secadora

        public void SecadoraUpdate(Secadora secadora, Action<Secadora, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void SecadoraDelete(short secadoraId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void SecadoraGet(short secadoraId, Action<Secadora, Exception> action)
        {
            var reg = new Secadora
            {
                Id = 1,
                Nombre = "Nombre de la Secadora No. 1",
                SecadoraCapacidadId = 1,
                SecadoraCapacidad = new SecadoraCapacidad
                {

                    Id = 1,
                    CapacidadMinimaKg = 100,
                    CapacidadMaximaKg = 200
                },
                Estado = 1,
                DireccionIp = "192.168.1.123",
                DireccionMac = "1234567890ABCDEF",
                Marca = "Marca de la secadora Xxxxx",
                Modelo = "Modelo de la secadora Yyyyy",
                NumeroSerie = "ABC1234567890XYZ"
            };
            action(reg, null);
        }

        public void SecadoraGetAll(Action<List<Secadora>, Exception> action)
        {
            var lista = new List<Secadora>();
            for (short i = 1; i < 21; i++)
            {
                lista.Add(new Secadora
                {
                    Id = i,
                    Nombre = $"Nombre de la Secadora No. {i.ToString("00")}",
                    SecadoraCapacidadId = 1,
                    SecadoraCapacidad = new SecadoraCapacidad
                    {

                        Id = 1,
                        CapacidadMinimaKg = 100,
                        CapacidadMaximaKg = 200
                    },
                    Estado = 1,
                    DireccionIp = "192.168.1.123",
                    DireccionMac = "1234567890ABCDEF",
                    Marca = "Marca de la secadora Xxxxx",
                    Modelo = "Modelo de la secadora Yyyyy",
                    NumeroSerie = "ABC1234567890XYZ"
                });
            }
            action(lista, null);
        }

        public void SecadoraGetByCapacidad(short secadoraCapacidadId, Action<List<Secadora>, Exception> action)
        {
            var lista = new List<Secadora>();
            for (short i = 1; i < 21; i++)
            {
                lista.Add(new Secadora
                {
                    Id = i,
                    Nombre = $"Nombre de la Secadora No. {i.ToString("00")}",
                    SecadoraCapacidadId = 1,
                    SecadoraCapacidad = new SecadoraCapacidad
                    {

                        Id = 1,
                        CapacidadMinimaKg = 100,
                        CapacidadMaximaKg = 200
                    },
                    Estado = 1,
                    DireccionIp = "192.168.1.123",
                    DireccionMac = "1234567890ABCDEF",
                    Marca = "Marca de la secadora Xxxxx",
                    Modelo = "Modelo de la secadora Yyyyy",
                    NumeroSerie = "ABC1234567890XYZ"
                });
            }
            action(lista, null);
        }

        #endregion

        #region SecadoraCapacidad

        public void SecadoraCapacidadUpdate(SecadoraCapacidad secadoraCapacidad, Action<SecadoraCapacidad, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void SecadoraCapacidadDelete(short secadoraCapacidadId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void SecadoraCapacidadGet(short secadoraCapacidadId, Action<SecadoraCapacidad, Exception> action)
        {
            var reg = new SecadoraCapacidad
            {

                Id = 1,
                CapacidadMinimaKg = 100,
                CapacidadMaximaKg = 200
            };
            action(reg, null);
        }

        public void SecadoraCapacidadGetAll(Action<List<SecadoraCapacidad>, Exception> action)
        {
            var lista = new List<SecadoraCapacidad>();
            for (short i = 1; i < 21; i++)
            {
                lista.Add(new SecadoraCapacidad
                {

                    Id = 1,
                    CapacidadMinimaKg = 100,
                    CapacidadMaximaKg = 200
                });
            }
            action(lista, null);
        }

        #endregion

        #region SubClase

        public void SubClaseUpdate(SubClase subClase, Action<SubClase, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void SubClaseDelete(string subClaseCodigo, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void SubClaseGet(string subClaseCodigo, Action<SubClase, Exception> action)
        {
            var reg = new SubClase
            {
                CompaniaCodigo = 1,
                Codigo = "000001",
                Descripcion = "Sub Clase No. 000001",
                Estado = "A"
            };
            action(reg, null);
        }

        public void SubClaseGetAll(Action<List<SubClase>, Exception> action)
        {
            var lista = new List<SubClase>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new SubClase
                {
                    CompaniaCodigo = 1,
                    Codigo = $"{i.ToString("000000")}",
                    Descripcion = $"Sub Clase No. {i.ToString("000000")}",
                    Estado = "A"
                });
            }
        }

        #endregion

        #region Tela

        public void TelaGet(string telaCodigo, Action<Tela, Exception> action)
        {
            var reg = new Tela
            {
                TelaCodigo = "001",
                TelaNombre = "Tela No. 001",
                ComposicionNombre = "Composición de la tela",
                MaterialCodigo = 1,
                TelaDescripcion = "Descripción de la Tela No. 001"
            };
            action(reg, null);
        }

        public void TelaGetAll(Action<List<Tela>, Exception> action)
        {
            var lista = new List<Tela>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Tela
                {
                    TelaCodigo = i.ToString("000"),
                    TelaNombre = $"Tela No. {i.ToString("000")}",
                    ComposicionNombre = "Composición de la tela",
                    MaterialCodigo = 1,
                    TelaDescripcion = $"Descripción de la Tela No. {i.ToString("000")}"
                });
            }
            action(lista, null);
        }

        public void TelaGetCombo(Action<List<Tela>, Exception> action)
        {
            var lista = new List<Tela>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Tela
                {
                    TelaCodigo = i.ToString("000"),
                    TelaNombre = $"Tela No. {i.ToString("000")}",
                    ComposicionNombre = "Composición de la tela",
                    MaterialCodigo = 1,
                    TelaDescripcion = $"Descripción de la Tela No. {i.ToString("000")}"
                });
            }
            action(lista, null);
        }

        public void TelaGetComposicionCodigo(string telaCodigo, Action<string, Exception> action)
        {
            action("CMP01", null);
        }

        #endregion

        #region TelaColorIntermoda

        public void TelaColorIntermodaUpdate(TelaColorIntermoda telaColorIntermoda,
            Action<TelaColorIntermoda, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TelaColorIntermodaDelete(int telaColorIntermodaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void TelaColorIntermodaGet(int telaColorIntermodaId, Action<TelaColorIntermoda, Exception> action)
        {
            var reg = new TelaColorIntermoda
            {
                Id = 1,
                ColorIntermodaId = 1,
                TelaId = "001",
                MaterialId = 1,
                ColorIntermoda = new ColorIntermoda
                {
                    Id = 1,
                    Nombre = "Color No. 001"
                },
                Tela = new Tela
                {
                    TelaCodigo = "001",
                    TelaNombre = "Tela No. 001",
                    ComposicionNombre = "Composición de la Tela",
                    TelaDescripcion = "Descripción de la Tela No. 001",
                    MaterialCodigo = 1
                },
                Catalogo = new Catalogo
                {
                    Id = 1,
                    Nombre = "Material No. 000001",
                    Descripcion = "Descripción del Material No. 000001",
                    MedidaCompraCodigo = "MEDCMP",
                    MedidaConsumoCodigo = "MEDCNS",
                    TipoRequisicionCodigo = "REQ001",
                    GrupoCodigo = "GRP",
                    TelaCodigo = "001",
                    CuentaContableCodigo = "CTACTB",
                    CuentaVariableFija = "F",
                    CuentaContableInventarioCodigo = "CTACTBINV",
                    RepuestoNumero = "REP001"
                }
            };
            action(reg, null);
        }

        public void TelaColorIntermodaGetAll(Action<List<TelaColorIntermoda>, Exception> action)
        {
            var lista = new List<TelaColorIntermoda>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new TelaColorIntermoda
                {
                    Id = i,
                    ColorIntermodaId = i,
                    TelaId = i.ToString("000"),
                    MaterialId = i,
                    ColorIntermoda = new ColorIntermoda
                    {
                        Id = 1,
                        Nombre = $"Color No. {i.ToString("000")}"
                    },
                    Tela = new Tela
                    {
                        TelaCodigo = i.ToString("000"),
                        TelaNombre = $"Tela No. {i.ToString("000")}",
                        ComposicionNombre = "Composición de la Tela",
                        TelaDescripcion = $"Descripción de la Tela No. {i.ToString("000")}",
                        MaterialCodigo = 1
                    },
                    Catalogo = new Catalogo
                    {
                        Id = 1,
                        Nombre = $"Material No. {i.ToString("000000")}",
                        Descripcion = $"Descripción del Material No. {i.ToString("000000")}",
                        MedidaCompraCodigo = "MEDCMP",
                        MedidaConsumoCodigo = "MEDCNS",
                        TipoRequisicionCodigo = $"REQ{i.ToString("000")}",
                        GrupoCodigo = "GRP",
                        TelaCodigo = i.ToString("000"),
                        CuentaContableCodigo = "CTACTB",
                        CuentaVariableFija = "F",
                        CuentaContableInventarioCodigo = "CTACTBINV",
                        RepuestoNumero = $"REP{i.ToString("000")}"
                    }
                });
            }
            action(lista, null);
        }

        public void TelaColorIntermodaGetByColorIntermoda(int colorIntermodaId,
            Action<List<TelaColorIntermoda>, Exception> action)
        {
            var lista = new List<TelaColorIntermoda>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new TelaColorIntermoda
                {
                    Id = i,
                    ColorIntermodaId = i,
                    TelaId = i.ToString("000"),
                    MaterialId = i,
                    ColorIntermoda = new ColorIntermoda
                    {
                        Id = 1,
                        Nombre = $"Color No. {i.ToString("000")}"
                    },
                    Tela = new Tela
                    {
                        TelaCodigo = i.ToString("000"),
                        TelaNombre = $"Tela No. {i.ToString("000")}",
                        ComposicionNombre = "Composición de la Tela",
                        TelaDescripcion = $"Descripción de la Tela No. {i.ToString("000")}",
                        MaterialCodigo = 1
                    },
                    Catalogo = new Catalogo
                    {
                        Id = 1,
                        Nombre = $"Material No. {i.ToString("000000")}",
                        Descripcion = $"Descripción del Material No. {i.ToString("000000")}",
                        MedidaCompraCodigo = "MEDCMP",
                        MedidaConsumoCodigo = "MEDCNS",
                        TipoRequisicionCodigo = $"REQ{i.ToString("000")}",
                        GrupoCodigo = "GRP",
                        TelaCodigo = i.ToString("000"),
                        CuentaContableCodigo = "CTACTB",
                        CuentaVariableFija = "F",
                        CuentaContableInventarioCodigo = "CTACTBINV",
                        RepuestoNumero = $"REP{i.ToString("000")}"
                    }
                });
            }
            action(lista, null);
        }

        #endregion
    }
}