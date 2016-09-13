using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDetalleProductoDataService : ICarteraDocumentoDetalleProductoDataService
    {
        public void Update(CarteraDocumentoDetalleProducto carteraDocumentoDetalleProducto, Action<CarteraDocumentoDetalleProducto, Exception> action)
        {
            try
            {
                var reg = carteraDocumentoDetalleProducto.Id == 0
                    ? CarteraDocumentoDetalleProductoRepository.Insert(carteraDocumentoDetalleProducto)
                    : CarteraDocumentoDetalleProductoRepository.Update(carteraDocumentoDetalleProducto);
                action(reg, null);

            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int carteraDocumentoDetalleProductoId, Action<Exception> action)
        {
            try
            {
                CarteraDocumentoDetalleProductoRepository.Delete(carteraDocumentoDetalleProductoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int carteraDocumentoDetalleProductoId, Action<CarteraDocumentoDetalleProducto, Exception> action)
        {
            try
            {
                var reg = CarteraDocumentoDetalleProductoRepository.Get(carteraDocumentoDetalleProductoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<CarteraDocumentoDetalleProducto>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetalleProductoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCarteraDocumento(int carteraDocumentoId, Action<List<CarteraDocumentoDetalleProducto>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetalleProductoRepository.GetByCarteraDocumento(carteraDocumentoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByProducto(int productoId, Action<List<CarteraDocumentoDetalleProducto>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetalleProductoRepository.GetByProducto(productoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}