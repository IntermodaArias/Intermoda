using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Intermoda.Client.LbDatPro;
using Intermoda.ClientProxy.LbDatPro.MaquiladoCajaDetalleServiceReference;
using Intermoda.ClientProxy.LbDatPro.MaquiladoCajaServiceReference;
using Intermoda.ClientProxy.LbDatPro.OrdenProduccionDetalleServiceReference;

namespace Intermoda.Client.DataService.LbDatPro
{
    public class DataServiceLbDatPro : IDataServiceLbDatPro
    {
        #region Empleado

        public async void EmpleadoGet(short companiaCodigo, int empleadoId, Action<Empleado, Exception> action)
        {
            try
            {
                var reg = await Empleado.Get(companiaCodigo, empleadoId);

                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void EmpleadoGetAllActivos(Action<List<Empleado>, Exception> action)
        {
            try
            {
                var lista = await Empleado.GetAllActivos();

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion
        
        #region Inasistencias

        public async void InasistenciaGetByFecha(DateTime fechaInicial, DateTime fechaFinal,
            Action<List<Inasistencia>, Exception> action)
        {
            try
            {
                var lista = await Inasistencia.GetByFecha(fechaInicial, fechaFinal);

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InasistenciaGetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fechaInicial,
            DateTime fechaFinal, Action<List<Inasistencia>, Exception> action)
        {
            try
            {
                var lista = await
                    Inasistencia.GetByEmpleadoFecha(companiaCodigo, empleadoCodigo, fechaInicial, fechaFinal);

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region MaquiladoCaja

        public void MaquiladoCajaUpdate(MaquiladoCaja maquiladoCaja, Action<MaquiladoCaja, Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaClient())
                {
                    var regBusiness = MaquiladoCajaClientToBusiness(maquiladoCaja);
                    regBusiness = client.Update(regBusiness);
                    var reg = MaquiladoCajaBusinessToClient(regBusiness);
                    action(reg, null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void MaquiladoCajaDelete(int maquiladoCajaId, Action<Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaClient())
                {
                    client.Delete(maquiladoCajaId);
                    action(null);
                }
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void MaquiladoCajaGet(int maquiladoCajaId, Action<MaquiladoCaja, Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaClient())
                {
                    var regBusiness = client.Get(maquiladoCajaId);
                    var reg = MaquiladoCajaBusinessToClientDetalle(regBusiness);
                    action(reg, null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void MaquiladoCajaGetByOrden(short companiaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCaja>, Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaClient())
                {
                    var listaBusiness = client.GetByOrden(companiaId, ordenAno, ordenNumero).ToList();
                    var lista = listaBusiness.Select(MaquiladoCajaBusinessToClientDetalle).ToList();
                    action(lista, null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void MaquiladoEmpaqueGet(short companiaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCaja>, Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaClient())
                {
                    var lista = client.GetDetalleByOrden(companiaId, ordenAno, ordenNumero).ToList();
                    var retorno = new List<MaquiladoCaja>();
                    foreach (var item in lista)
                    {
                        var detalle = new List<MaquiladoCajaDetalle>();
                        foreach (var det in item.Detalle)
                        {
                            detalle.Add(new MaquiladoCajaDetalle
                            {
                                Id = det.Id,
                                MaquiladoCajaId = det.MaquiladoCajaId,
                                CompaniaId = det.CompaniaId,
                                TallaId = det.TallaId,
                                Cantidad = det.Cantidad,
                                Talla = new Talla
                                {
                                    CompaniaId = det.Talla.CompaniaId,
                                    Codigo = det.Talla.Codigo,
                                    Nombre = det.Talla.Nombre,
                                    Secuencia = det.Talla.Secuencia
                                }
                            });
                        }
                        retorno.Add(new MaquiladoCaja
                        {
                            Id = item.Caja.Id,
                            CompaniaId = item.Caja.CompaniaId,
                            OrdenAno = item.Caja.OrdenAno,
                            OrdenNumero = item.Caja.OrdenNumero,
                            Numero = item.Caja.Numero,
                            FechaApertura = item.Caja.FechaApertura,
                            FechaCierre = item.Caja.FechaCierre,
                            Estado = item.Caja.Estado,
                            Detalle = new ObservableCollection<MaquiladoCajaDetalle>(detalle)
                        });
                    }
                    
                    action(retorno, null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region MaquiladoCajaDetalle

        public void MaquiladoCajaDetalleUpdate(MaquiladoCajaDetalle maquiladoCajaDetalle, Action<MaquiladoCajaDetalle, Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaDetalleClient())
                {
                    var reg = client.Update(MaquiladoCajaDetalleClientToBusiness(maquiladoCajaDetalle));
                    action(MaquiladoCajaDetalleBusinessToClient(reg), null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void MaquiladoCajaDetalleDelete(int maquiladoCajaDetalleId, Action<Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaDetalleClient())
                {
                    client.Delete(maquiladoCajaDetalleId);
                    action(null);
                }
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void MaquiladoCajaDetalleGet(int maquiladoCajaDetalleId, Action<MaquiladoCajaDetalle, Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaDetalleClient())
                {
                    var reg = client.Get(maquiladoCajaDetalleId);
                    action(MaquiladoCajaDetalleBusinessToClient(reg), null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void MaquiladoCajaDetalleGetByMaquiladoCaja(int maquiladoCajaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCajaDetalle>, Exception> action)
        {
            try
            {
                using (var client = new MaquiladoCajaDetalleClient())
                {
                    var listaBusiness = client.GetByMaquiladoCaja(maquiladoCajaId).ToList();
                    var lista = listaBusiness.Select(MaquiladoCajaDetalleBusinessToClient).ToList();
                    action(lista, null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OrdenProduccionDetalle

        public void OrdenProduccionDetalleGetBultos(short companiaId, short ordenAno, short ordenNumero,
            Action<List<OrdenProduccionBulto>, Exception> action)
        {
            try
            {
                using (var client = new OrdenProduccionDetalleClient())
                {
                    var listaBusiness = client.GetBultos(companiaId, ordenAno, ordenNumero).ToList();
                    var lista = listaBusiness.Select(OrdenProduccionBultoBusinessToClient).ToList();
                    action(lista, null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void OrdenProduccionDetalleGetTallas(short companiaId, short ordenAno, short ordenNumero,
            Action<List<OrdenProduccionTalla>, Exception> action)
        {
            try
            {
                using (var client = new OrdenProduccionDetalleClient())
                {
                    var listaBusiness = client.GetTallas(companiaId, ordenAno, ordenNumero).ToList();
                    var lista = listaBusiness.Select(OrdenProduccionTallaBusinessToClient).ToList();
                    action(lista, null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OrdenProduccionExterno

        public async void OrdenProduccionExternoGet(Action<List<MaquiladoTeP>, Exception> action)
        {
            try
            {
                var lista = await OrdenProduccionExterno.GetMaquiladoTrabajoEnProceso();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OrdenProduccionExternoGetByUsuarioPlanta(string usuario,
            Action<List<OrdenProduccionExterno>, Exception> action)
        {
            try
            {
                var lista = await OrdenProduccionExterno.GetByUsuarioPlanta(usuario);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OrdenProduccionExternoSetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId,
            Action<Exception> action)
        {
            try
            {
                await OrdenProduccionExterno.SetEstado(companiaId, ordenAno, ordenNumero, estadoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void OrdenProduccionExternoGrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId,
            string tipo, string usuario, Action<OrdenProduccionExterno, Exception> action)
        {
            try
            {
                var reg = await OrdenProduccionExterno.GrabarLectura(companiaId, ordenAno, ordenNumero, centroTrabajoId, tipo, usuario);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OrdenProduccionExternoSerEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero, Action<Exception> action)
        {
            try
            {
                await OrdenProduccionExterno.SetEstadoEnviarIntermoda(companiaId, ordenAno, ordenNumero);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        #endregion

        #region Planta

        public async void PlantaGetByUsuario(string usuario, string clave, Action<Planta, Exception> action)
        {
            try
            {
                var reg = Planta.GetByUsuario(usuario, clave);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void PlantaGetContratistas(Action<List<Planta>, Exception> action)
        {
            try
            {
                var reg = Planta.GetContratistas();
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void PlantaUpdateClave(string plantaId, string claveOld, string claveNew, Action<Exception> action)
        {
            try
            {
                Planta.UpdateClave(plantaId, claveOld, claveNew);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        #endregion

        private MaquiladoCajaBusiness MaquiladoCajaClientToBusiness(MaquiladoCaja caja)
        {
            return new MaquiladoCajaBusiness
            {
                Id = caja.Id,
                CompaniaId = caja.CompaniaId,
                OrdenAno = caja.OrdenAno,
                OrdenNumero = caja.OrdenNumero,
                Numero = caja.Numero,
                FechaApertura = caja.FechaApertura,
                FechaCierre = caja.FechaCierre,
                Estado = caja.Estado
            };
        }

        private MaquiladoCaja MaquiladoCajaBusinessToClient(MaquiladoCajaBusiness caja)
        {
            return new MaquiladoCaja
            {
                Id = caja.Id,
                CompaniaId = caja.CompaniaId,
                OrdenAno = caja.OrdenAno,
                OrdenNumero = caja.OrdenNumero,
                Numero = caja.Numero,
                FechaApertura = caja.FechaApertura,
                FechaCierre = caja.FechaCierre,
                Estado = caja.Estado
            };
        }

        private MaquiladoCaja MaquiladoCajaBusinessToClientDetalle(MaquiladoCajaBusiness caja)
        {
            var detalle = new List<MaquiladoCajaDetalle>();
            using (var client = new MaquiladoCajaDetalleClient())
            {
                var detalleBusiness = client.GetByMaquiladoCaja(caja.Id).ToList();

                detalle.AddRange(detalleBusiness.Select(MaquiladoCajaDetalleBusinessToClient));
            }

            return new MaquiladoCaja
            {
                Id = caja.Id,
                CompaniaId = caja.CompaniaId,
                OrdenAno = caja.OrdenAno,
                OrdenNumero = caja.OrdenNumero,
                Numero = caja.Numero,
                FechaApertura = caja.FechaApertura,
                FechaCierre = caja.FechaCierre,
                Estado = caja.Estado,
                Detalle = new ObservableCollection<MaquiladoCajaDetalle>(detalle)
            };
        }

        private ClientProxy.LbDatPro.MaquiladoCajaDetalleServiceReference.MaquiladoCajaDetalleBusiness MaquiladoCajaDetalleClientToBusiness(MaquiladoCajaDetalle caja)
        {
            return new ClientProxy.LbDatPro.MaquiladoCajaDetalleServiceReference.MaquiladoCajaDetalleBusiness
            {
                Id = caja.Id,
                MaquiladoCajaId = caja.MaquiladoCajaId,
                CompaniaId = caja.CompaniaId,
                TallaId = caja.TallaId,
                Cantidad = caja.Cantidad,
                Talla = new ClientProxy.LbDatPro.MaquiladoCajaDetalleServiceReference.TallaBusiness
                {
                    CompaniaId = (short)caja.Talla.CompaniaId,
                    Codigo = caja.Talla.Codigo,
                    Nombre = caja.Talla.Nombre,
                    Secuencia = caja.Talla.Secuencia
                }
            };
        }

        private MaquiladoCajaDetalle MaquiladoCajaDetalleBusinessToClient(ClientProxy.LbDatPro.MaquiladoCajaDetalleServiceReference.MaquiladoCajaDetalleBusiness caja)
        {
            return new MaquiladoCajaDetalle
            {
                Id = caja.Id,
                MaquiladoCajaId = caja.MaquiladoCajaId,
                CompaniaId = caja.CompaniaId,
                TallaId = caja.TallaId,
                Cantidad = caja.Cantidad,
                Talla = new Talla
                {
                    CompaniaId = caja.Talla.CompaniaId,
                    Codigo = caja.Talla.Codigo,
                    Nombre = caja.Talla.Nombre,
                    Secuencia = caja.Talla.Secuencia
                }
            };
        }

        private OrdenProduccionTalla OrdenProduccionTallaBusinessToClient(OrdenProduccionTallaBusiness orden)
        {
            return new OrdenProduccionTalla
            {
                CompaniaId = orden.CompaniaId,
                OrdenAno = orden.OrdenAno,
                OrdenNumero = orden.OrdenNumero,
                TallaCodigo = orden.TallaCodigo,
                Cantidad = orden.Cantidad,
                Talla = new Talla
                {
                    CompaniaId = orden.Talla.CompaniaId,
                    Codigo = orden.Talla.Codigo,
                    Nombre = orden.Talla.Nombre,
                    Secuencia = orden.Talla.Secuencia
                }
            };
        }

        private OrdenProduccionBulto OrdenProduccionBultoBusinessToClient(OrdenProduccionBultoBusiness orden)
        {
            return new OrdenProduccionBulto
            {
                CompaniaId = orden.CompaniaId,
                OrdenAno = orden.OrdenAno,
                OrdenNumero = orden.OrdenNumero,
                Numero = orden.Numero,
                TallaCodigo = orden.TallaCodigo,
                Cantidad = orden.Cantidad,
                Talla = new Talla
                {
                    CompaniaId = orden.Talla.CompaniaId,
                    Codigo = orden.Talla.Codigo,
                    Nombre = orden.Talla.Nombre,
                    Secuencia = orden.Talla.Secuencia
                }
            };
        }
    }
}