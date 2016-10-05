using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
                    Mapper.Initialize(cfg => cfg.CreateMap<MaquiladoCaja, MaquiladoCajaBusiness>().ReverseMap());
                    var reg = client.Update(Mapper.Map<MaquiladoCajaBusiness>(maquiladoCaja));
                    action(Mapper.Map<MaquiladoCaja>(reg), null);
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
                    Mapper.Initialize(cfg => cfg.CreateMap<MaquiladoCaja, MaquiladoCajaBusiness>().ReverseMap());
                    var reg = client.Get(maquiladoCajaId);
                    action(Mapper.Map<MaquiladoCaja>(reg), null);
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
                    Mapper.Initialize(cfg => cfg.CreateMap<MaquiladoCaja, MaquiladoCajaBusiness>().ReverseMap());
                    var lista = client.GetByOrden(companiaId, ordenAno, ordenNumero).ToList();
                    action(Mapper.Map<List<MaquiladoCaja>>(lista), null);
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
                    Mapper.Initialize(cfg => cfg.CreateMap<MaquiladoCajaDetalle, MaquiladoCajaDetalleBusiness>().ReverseMap());
                    var reg = client.Update(Mapper.Map<MaquiladoCajaDetalleBusiness>(maquiladoCajaDetalle));
                    action(Mapper.Map<MaquiladoCajaDetalle>(reg), null);
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
                    Mapper.Initialize(cfg => cfg.CreateMap<MaquiladoCajaDetalle, MaquiladoCajaDetalleBusiness>().ReverseMap());
                    var reg = client.Get(maquiladoCajaDetalleId);
                    action(Mapper.Map<MaquiladoCajaDetalle>(reg), null);
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
                    Mapper.Initialize(cfg => cfg.CreateMap<MaquiladoCajaDetalle, MaquiladoCajaDetalleBusiness>().ReverseMap());
                    var lista = client.GetByMaquiladoCaja(maquiladoCajaId).ToList();
                    action(Mapper.Map<List<MaquiladoCajaDetalle>>(lista), null);
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
                    Mapper.Initialize(cfg => cfg.CreateMap<OrdenProduccionBulto, OrdenProduccionBultoBusiness>().ReverseMap());
                    var lista = client.GetBultos(companiaId, ordenAno, ordenNumero).ToList();
                    action(Mapper.Map<List<OrdenProduccionBulto>>(lista), null);
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
                    Mapper.Initialize(cfg => cfg.CreateMap<OrdenProduccionTalla, OrdenProduccionTallaBusiness>().ReverseMap());
                    var lista = client.GetTallas(companiaId, ordenAno, ordenNumero).ToList();
                    action(Mapper.Map<List<OrdenProduccionTalla>>(lista), null);
                }
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OrdenProduccionExterno

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
            string tipo, string usuario, Action<Exception> action)
        {
            try
            {
                await OrdenProduccionExterno.GrabarLectura(companiaId, ordenAno, ordenNumero, centroTrabajoId, tipo,
                    usuario);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
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
    }
}