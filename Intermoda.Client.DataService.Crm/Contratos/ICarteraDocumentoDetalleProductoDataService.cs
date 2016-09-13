using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ICarteraDocumentoDetalleProductoDataService
    {

        void Update(CarteraDocumentoDetalleProducto carteraDocumentoDetalleProducto,
            Action<CarteraDocumentoDetalleProducto, Exception> action);

        void Delete(int carteraDocumentoDetalleProductoId, Action<Exception> action);

        void Get(int carteraDocumentoDetalleProductoId,
            Action<CarteraDocumentoDetalleProducto, Exception> action);

        void GetAll(Action<List<CarteraDocumentoDetalleProducto>, Exception> action);

        void GetByCarteraDocumento(int carteraDocumentoId,
            Action<List<CarteraDocumentoDetalleProducto>, Exception> action);

        void GetByProducto(int productoId, Action<List<CarteraDocumentoDetalleProducto>, Exception> action);
    }
}