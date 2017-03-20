using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Intermoda.Client.LbDatPro; 

namespace Intermoda.Client.DataService.LbDatPro
{
    public class DesignDataServiceLbDatPro : IDataServiceLbDatPro
    {
        #region Empleado

        public void EmpleadoGet(short companiaCodigo, int empleadoId, Action<Empleado, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void EmpleadoGetAllActivos(Action<List<Empleado>, Exception> action)
        {
            var lista = new List<Empleado>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Empleado
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

        #region Inasistencias

        public void InasistenciaGetByFecha(DateTime fechaInicial, DateTime fechaFinal,
            Action<List<Inasistencia>, Exception> action)
        {
            var lista = new List<Inasistencia>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Inasistencia
                {
                    CompaniaCodigo = 1,
                    EmpleadoCodigo = i,
                    Fecha = new DateTime(2015, 1, i),
                    MinutosConPermiso = 100,
                    MinutosSinPermiso = 1000
                });
            }
            action(lista, null);
        }

        public void InasistenciaGetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fechaInicial,
            DateTime fechaFinal, Action<List<Inasistencia>, Exception> action)
        {
            var lista = new List<Inasistencia>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new Inasistencia
                {
                    CompaniaCodigo = 1,
                    EmpleadoCodigo = i,
                    Fecha = new DateTime(2015, 1, i),
                    MinutosConPermiso = 100,
                    MinutosSinPermiso = 1000
                });
            }
            action(lista, null);
        }

        #endregion

        #region MaquiladoCaja

        public void MaquiladoCajaUpdate(MaquiladoCaja maquiladoCaja, Action<MaquiladoCaja, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquiladoCajaDelete(int maquiladoCajaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquiladoCajaGet(int maquiladoCajaId, Action<MaquiladoCaja, Exception> action)
        {
            action(GetMaquiladoCaja(1), null);
        }

        public void MaquiladoCajaGetByOrden(short companiaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCaja>, Exception> action)
        {
            var lista = new List<MaquiladoCaja>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(GetMaquiladoCaja(i));
            }
            action(lista, null);
        }

        public void MaquiladoEmpaqueGet(short companiaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCaja>, Exception> action)
        {
            var lista = new List<MaquiladoCaja>();
            for (var i = 1; i < 21; i++)
            {
                var detalle = new List<MaquiladoCajaDetalle>();
                for (var j = 1; j < 11; j++)
                {
                    detalle.Add(GetMaquiladoCajaDetalle(j));
                }
                var item = GetMaquiladoCaja(i);
                item.Detalle = new ObservableCollection<MaquiladoCajaDetalle>(detalle);
                lista.Add(item);
            }
            action(lista, null);
        }

        private MaquiladoCaja GetMaquiladoCaja(int i)
        {
            return new MaquiladoCaja
            {
                Id = i,
                CompaniaId = 1,
                OrdenAno = 16,
                OrdenNumero = (short)(1000 + i),
                Numero = i
            };
        }

        #endregion

        #region MaquiladoCajaDetalle

        public void MaquiladoCajaDetalleUpdate(MaquiladoCajaDetalle maquiladoCajaDetalle, Action<MaquiladoCajaDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquiladoCajaDetalleDelete(int maquiladoCajaDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void MaquiladoCajaDetalleGet(int maquiladoCajaDetalleId, Action<MaquiladoCajaDetalle, Exception> action)
        {
            action(GetMaquiladoCajaDetalle(1), null);
        }

        public void MaquiladoCajaDetalleGetByMaquiladoCaja(int maquiladoCajaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCajaDetalle>, Exception> action)
        {
            var lista = new List<MaquiladoCajaDetalle>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(GetMaquiladoCajaDetalle(i));
            }
        }

        private MaquiladoCajaDetalle GetMaquiladoCajaDetalle(int i)
        {
            return new MaquiladoCajaDetalle
            {
                Id = i,
                MaquiladoCajaId = 1000,
                CompaniaId = 1,
                TallaId = "030",
                Talla = new Talla {CompaniaId = 1, Codigo = "030", Nombre = "30", Secuencia = 4},
                Cantidad = i + 8
            };
        }

        #endregion

        #region OrdenProduccionDetalle

        public void OrdenProduccionDetalleGetBultos(short companiaId, short ordenAno, short ordenNumero,
            Action<List<OrdenProduccionBulto>, Exception> action)
        {
            var lista = new List<OrdenProduccionBulto>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OrdenProduccionBulto
                {
                    CompaniaId = 1,
                    OrdenAno = 16,
                    OrdenNumero = (short)(2000 + i),
                    Numero = (short)i,
                    TallaCodigo = "030",
                    Talla = new Talla { CompaniaId = 1, Codigo = "030", Nombre = "30", Secuencia = 4 },
                    Cantidad = (short)(7+i)
                });
            }
            action(lista, null);
        }

        public void OrdenProduccionDetalleGetTallas(short companiaId, short ordenAno, short ordenNumero,
            Action<List<OrdenProduccionTalla>, Exception> action)
        {
            var lista = new List<OrdenProduccionTalla>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(new OrdenProduccionTalla
                {
                    CompaniaId = 1,
                    OrdenAno = 16,
                    OrdenNumero = (short)(2000 + i),
                    TallaCodigo = "030",
                    Talla = new Talla { CompaniaId = 1, Codigo = "030", Nombre = "30", Secuencia = 4 },
                    Cantidad = (short)(7 + i)
                });
            }
            action(lista, null);
        }

        #endregion

        #region OrdenProduccionExterno

        public void OrdenProduccionExternoGet(Action<List<MaquiladoTeP>, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OrdenProduccionExternoGetByUsuarioPlanta(string usuario,
            Action<List<OrdenProduccionExterno>, Exception> action)
        {
            var lista = new List<OrdenProduccionExterno>();
            for (var i = 1; i < 201; i++)
            {
                string estadoLeyenda;
                var j = i/3;
                var l = i/2;
                decimal k = (decimal) i/3;
                if (k == j)
                {
                    estadoLeyenda = "En Espera";
                }
                else if (l == (decimal) i/2)
                {
                    estadoLeyenda = "En Proceso";
                }
                else
                {
                    estadoLeyenda = "En Espera de enviar";
                }
                lista.Add(new OrdenProduccionExterno
                {
                    CompaniaId = 1,
                    Ano = 16,
                    Numero = (short) i,
                    Patron = "PR001",
                    Variante = "VAR",
                    Tela = "TEL",
                    Lavado = "LAV",
                    Color = "CO",
                    EstadoId = "X",
                    EstadoLeyenda = estadoLeyenda,
                    Cantidad = 500,
                    OrdenProduccion = $"{i.ToString("0000")}-16",
                    Referencia = "PR001-VAR-TEL-LAV-CO",
                    Estado = new OrdenEstado
                    {
                        Id = "X",
                        Secuencia = 10,
                        Descripcion = "Estado de la Orden",
                        Area = "Area",
                        CentroCostoAlias = "Centro de Costo",
                        CentroTrabajoId = "03"
                    },
                    Ruta = new List<PasoRuta>
                    {
                        new PasoRuta
                        {
                            CompaniaId = 1,
                            Ano = 16,
                            Numero = (short) i,
                            CentroTrabajoId = "02",
                            PlantaId = "XX",
                            Secuencia = 10
                        },
                        new PasoRuta
                        {
                            CompaniaId = 1,
                            Ano = 16,
                            Numero = (short) i,
                            CentroTrabajoId = "03",
                            PlantaId = "YY",
                            Secuencia = 20
                        },
                        new PasoRuta
                        {
                            CompaniaId = 1,
                            Ano = 16,
                            Numero = (short) i,
                            CentroTrabajoId = "04",
                            PlantaId = "ZZ",
                            Secuencia = 30
                        }
                    }
                });
            }
            action(lista, null);
        }

        public void OrdenProduccionExternoSetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId,
            Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OrdenProduccionExternoGrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId,
            string tipo, string usuario, Action<OrdenProduccionExterno, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void OrdenProduccionExternoSerEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Planta

        public void PlantaGetByUsuario(string usuario, string clave, Action<Planta, Exception> action)
        {
            var reg = new Planta
            {
                Id = "01",
                Iniciales = "ABC",
                Descripcion = "Planta ABC, S.A. de C.V.",
                GeneraTicket = "N",
                Tipo = "E",
                BodegaId = 01,
                Estado = "A",
                Habilitar = 1,
                NuevoId = 1,
                CompaniaId = 1,
                Usuario = "USUARIO",
                Clave = "*********"
            };
            action(reg, null);
        }

        public void PlantaGetContratistas(Action<List<Planta>, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void PlantaUpdateClave(string plantaId, string claveOld, string claveNew, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}