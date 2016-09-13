using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDetalleProductoDesignDataService : ICarteraDocumentoDetalleProductoDataService
    {
        public void Update(CarteraDocumentoDetalleProducto carteraDocumentoDetalleProducto, Action<CarteraDocumentoDetalleProducto, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int carteraDocumentoDetalleProductoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int carteraDocumentoDetalleProductoId, Action<CarteraDocumentoDetalleProducto, Exception> action)
        {

            var reg = MockData.CarteraDocumentoDetalleProducto();
            action(reg, null);
        }

        public void GetAll(Action<List<CarteraDocumentoDetalleProducto>, Exception> action)
        {

            var lista = new List<CarteraDocumentoDetalleProducto>();
            var reg = MockData.CarteraDocumentoDetalleProducto();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCarteraDocumento(int carteraDocumentoId, Action<List<CarteraDocumentoDetalleProducto>, Exception> action)
        {
            var lista = new List<CarteraDocumentoDetalleProducto>();
            var reg = MockData.CarteraDocumentoDetalleProducto();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByProducto(int productoId, Action<List<CarteraDocumentoDetalleProducto>, Exception> action)
        {
            var lista = new List<CarteraDocumentoDetalleProducto>();
            var reg = MockData.CarteraDocumentoDetalleProducto();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}